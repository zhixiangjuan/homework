using System;
using System.Collections.Generic;

public class Order
{
    public string OrderId { get; set; }
    public string Customer { get; set; }
    public List<OrderDetails> Details { get; set; } = new List<OrderDetails>();

    public double TotalAmount => CalculateTotalAmount();

    // 计算订单的总金额
    private double CalculateTotalAmount()
    {
        double total = 0;
        foreach (var detail in Details)
        {
            total += detail.Amount;
        }
        return total;
    }

    public override string ToString()
    {
        return $"订单号: {OrderId}, 客户: {Customer}, 总金额: {TotalAmount}";
    }

    public override bool Equals(object obj)
    {
        return obj is Order order && this.OrderId == order.OrderId;
    }

    public override int GetHashCode()
    {
        return OrderId.GetHashCode();
    }
}
public class OrderDetails
{
    public string ProductName { get; set; }
    public double Amount { get; set; }

    public override string ToString()
    {
        return $"商品名称: {ProductName}, 金额: {Amount}";
    }

    public override bool Equals(object obj)
    {
        return obj is OrderDetails details && this.ProductName == details.ProductName;
    }

    public override int GetHashCode()
    {
        return ProductName.GetHashCode();
    }
}

public class OrderService
{
    private List<Order> orders = new List<Order>();

    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new InvalidOperationException("订单已存在！");
        }
        orders.Add(order);
    }
    public void DeleteOrder(string orderId)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            throw new InvalidOperationException("订单不存在！");
        }
        orders.Remove(order);
    }
    public void UpdateOrder(string orderId, string newCustomer)
    {
        var order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order == null)
        {
            throw new InvalidOperationException("订单不存在！");
        }
        order.Customer = newCustomer;
    }
    public List<Order> QueryOrders(string keyword = "", double? minAmount = null, double? maxAmount = null)
    {
        var query = orders.AsQueryable();

        if (!string.IsNullOrEmpty(keyword))
        {
            query = query.Where(o => o.OrderId.Contains(keyword) || o.Customer.Contains(keyword));
        }
        if (minAmount.HasValue)
        {
            query = query.Where(o => o.TotalAmount >= minAmount);
        }
        if (maxAmount.HasValue)
        {
            query = query.Where(o => o.TotalAmount <= maxAmount);
        }

        return query.OrderBy(o => o.TotalAmount).ToList();
    }
}
class Program
{
    static void Main()
    {
        var orderService = new OrderService();
        //以下为测试

        // 添加订单1
        var order1 = new Order { OrderId = "O001", Customer = "Alice" };
        order1.Details.Add(new OrderDetails { ProductName = "Laptop", Amount = 1500 });
        order1.Details.Add(new OrderDetails { ProductName = "Mouse", Amount = 30 });
        orderService.AddOrder(order1);

        // 添加订单2
        var order2 = new Order { OrderId = "O002", Customer = "Bob" };
        order2.Details.Add(new OrderDetails { ProductName = "Keyboard", Amount = 120 });
        orderService.AddOrder(order2);

        // 查询订单
        Console.WriteLine("查询所有订单（按总金额排序）:");
        var orders = orderService.QueryOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }

        // 修改订单
        Console.WriteLine("修改订单 O001 客户为 John:");
        try
        {
            orderService.UpdateOrder("O001", "John");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // 查询订单
        Console.WriteLine("查询所有订单（按总金额排序）:");
        orders = orderService.QueryOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }

        // 删除订单
        Console.WriteLine("删除订单 O002:");
        try
        {
            orderService.DeleteOrder("O002");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // 查询订单
        Console.WriteLine("查询所有订单（按总金额排序）:");
        orders = orderService.QueryOrders();
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}
