﻿using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ServiceLayer.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public Order AddOrder(OrderModel orderData)
        {
            _context.Orders.Add(orderData.Order);
            _context.SaveChanges();

            foreach (OrderItem item in orderData.OrderItems)
            {
                item.OrderID = orderData.Order.ID;
            }

            _context.OrderItems.AddRange(orderData.OrderItems);
            _context.SaveChanges();

            return orderData.Order;
        }

        public Order DeleteOrder(long id)
        {
            var orderItems = _context.OrderItems.Where(i => i.OrderID == id);
            if (orderItems != null || orderItems.ToList().Count > 0)
            {
                _context.OrderItems.RemoveRange(orderItems);
            }

            var order = _context.Orders.Where(o => o.ID == id).FirstOrDefault();
            if (order == null)
            {
                return null;
            }

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return order;
        }

        public Order GetOrderByID(long id)
        {
            return _context.Orders.Where(order => order.ID == id)
                .Include(order => order.OrderItems)
                    .ThenInclude(item => item.Product)
                .FirstOrDefault();
        }

        public IEnumerable<Order> GetOrders()
        {
            return _context.Orders
                .Include(order => order.OrderItems)
                    .ThenInclude(i => i.Product);

        }

        public Order UpdateOrder(UpdateOrderModel model)
        {
            var order = _context.Orders.Where(o => o.ID == model.OrderID)
                .FirstOrDefault();
            if (order == null)
            {
                return null;
            }

            order.Status = model.Status;

            if (order.Status == 3) // order is finished
            {
                // decrease quantity of products corresponding ordered items
                var orderItems = _context.OrderItems.Where(i => i.OrderID == order.ID).ToList();
                foreach (var item in orderItems)
                {
                    var updatingProductVolume = _context.ProductVolumes
                        .Where(pv => pv.ProductID == item.ProductID && pv.VolumeValue == item.VolumeValue).FirstOrDefault();
                    updatingProductVolume.Quantity = updatingProductVolume.Quantity - item.Quantity;
                    _context.ProductVolumes.Update(updatingProductVolume);
                }
            }

            _context.Orders.Update(order);
            _context.SaveChanges();

            return order;
        }
    }
}
