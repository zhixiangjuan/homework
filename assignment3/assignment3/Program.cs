using System;
using System.Collections.Generic;
namespace Shape
{
    public interface Ishape
    {
        double Area();
        bool Valid();
    }
    public abstract class Shapes : Ishape
    {
        public abstract double Area();
        public abstract bool Valid();
    }
    public class Rectangle : Shapes
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }
        public override double Area()
        {
            return Length * Width;
        }
        public override bool Valid()
        {
            if (Length > 0 && Width > 0)
            {
                return true;
            }
            return false;
        }
    }
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }
    public class Circle : Shapes
    {
        public double Radius { get; set; }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public override double Area()
        {
            return 3.14 * Radius * Radius;
        }
        public override bool Valid()
        {
            if (Radius > 0)
            {
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalareas = 0;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                int shapetype = random.Next(0, 3);
                switch (shapetype)
                {
                    case 0:
                        Ishape shape0 = new Rectangle(random.Next(1, 11), random.Next(1, 11));
                        if (shape0.Valid())
                        {
                            totalareas += shape0.Area();
                        }
                        break;
                    case 1:
                        Ishape shape1 = new Square(random.Next(1, 11));
                        if (shape1.Valid())
                        {
                            totalareas += shape1.Area();
                        }
                        break;
                    case 2:
                        Ishape shape2 = new Circle(random.Next(1, 8));
                        if (shape2.Valid())
                        {
                            totalareas += shape2.Area();
                        }
                        break;
                }
            }
            Console.WriteLine($"所有图形的总面积为:{totalareas:F2}");

        }
    }
}