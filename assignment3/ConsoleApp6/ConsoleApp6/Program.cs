using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
namespace ConsoleApp6
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract bool IsValid();
    }

    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle(double width,double length)
        {
            Length = length;
            Width = width;
        }
        public override double Area()
        {
            if (!IsValid())
                throw new InvalidOperationException("形状不合法");
            return Length * Width;
        }
        public override bool IsValid()
        {
            return Length > 0 && Width > 0;
        }
        public override string ToString()
        {
            return $"长为{Length:F2}宽为{Width:F2}的长方形";
        }
    }
    class Triangle : Shape
    {
        public double LineA { get; set; }
        public double LineB { get; set; }
        public double LineC { get; set; }

        public Triangle(double linea, double lineb, double linec)
        {
            LineA = linea;
            LineB = lineb;
            LineC = linec;
        }
        public override double Area()
        {
            if (!IsValid())
                throw new InvalidOperationException("形状不合法");
            double p = (LineA + LineB + LineC) / 2;
            return Math.Sqrt(p * (p - LineA) * (p - LineB) * (p - LineC));
        }
        public override bool IsValid()
        {
            return ((LineA + LineB) > LineC) && ((LineC + LineB) > LineA) && ((LineA + LineC) > LineB);
        }
        public override string ToString()
        {
            return $"三边长分别为{LineA:F2} {LineB:F2} {LineC:F2}的三角形";
        }
    }

    public class ShapeFactory
    {
        private static Random _random = new Random();
        public static Shape CreateShape(string shapeType,params double[]dimensions)
        {
            switch (shapeType .ToLower ())
            {
                case "rectangle":
                    if (dimensions.Length != 2)
                        throw new ArgumentException("长方形需要两个参数");
                    return new Rectangle(dimensions[0], dimensions[1]);
                case "triangle":
                    if (dimensions.Length != 3)
                        throw new ArgumentException("三角形需要三个参数");
                    return new Triangle(dimensions[0], dimensions[1], dimensions[2]);
                default:throw new ArgumentException("不支持的形状类型");
            }
        }
        public static Shape CreateRandomShape(int seed)
        {
            _random = new Random(seed);
            if(_random.Next(2)==0)
            {
                return CreateRandomRectangle();
            }
            else
            {
                return CreateRandomTriangle();
            }
        }
        private static Rectangle CreateRandomRectangle()
        {
            return new Rectangle(
                width: _random.NextDouble() * 9 + 1,
                length: _random.NextDouble() * 9 + 1
                );
        }
        private static Triangle CreateRandomTriangle()
        {
            double a, b, c;
            do
            {
                a = _random.NextDouble() * 9 + 1;
                b = _random.NextDouble() * 9 + 1;
                c = _random.NextDouble() * 9 + 1;
            } while (!IsValidTriangle(a, b, c));
            return new Triangle(a, b, c);
        }

        private static bool IsValidTriangle(double a,double b,double c)
        {
            return new Triangle(a, b, c).IsValid();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Random random = new Random();
            for(int i=0;i<10;i++)
            {
                Shape shape = ShapeFactory.CreateRandomShape(random.Next());
                shapes.Add(shape);
                Console.WriteLine($"{i + 1}.{shape}");
            }

            double TotalArea = 0;
            foreach(var shape in shapes)
            {
                if (shape.IsValid())
                    TotalArea += shape.Area();
            }
            Console.WriteLine($"\n有效形状的总面积为{TotalArea:F2}");
        }
    }
}