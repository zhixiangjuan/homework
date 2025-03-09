using System;
namespace ConsoleApp2
{
    class Program
    {
        bool IsPrime(int n)
        {
            if (n < 2)
                return false;
            for (int i = 2; i <= n / i; i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        void f(int n)
        {
            if (IsPrime(n))
            {
                Console.WriteLine(n);
                return;
            }
            for (int i=2;i<=n/i;i++)
            {
                if(n%i==0&&IsPrime(i))
                {
                    Console.WriteLine(i);
                    f(n / i);
                    return;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个正整数");
            int num = int.Parse(Console.ReadLine());
            if(num<2)
            {
                Console.WriteLine(num + "没有质数因子");
                return;
            }
            var pro = new Program();
            pro.f(num);
        }
    }
}