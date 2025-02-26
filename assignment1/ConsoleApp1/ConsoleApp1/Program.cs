using System;
namespace ConsoleApp1
{
    class program
    {
        static void Main()
        {
 
            Console.WriteLine("第一个数");
            string a = Console.ReadLine();
            Console.WriteLine("运算符");
            string c = Console.ReadLine();
            Console.WriteLine("第二个数");
            string b = Console.ReadLine();
            int a1 = int.Parse(a);
            int b1 = int.Parse(b);
            int result = 0;
            bool flag = true;
            switch(c)
            {
                case "+": result = a1 + b1; break;
                case "-": result = a1 - b1; break;
                case "*": result = a1 * b1; break;
                case "/": if (b1 == 0) { flag = false; break; }
                    else { result = a1 / b1; break; }
                default:flag = false;break;
            }
            if(flag)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("错误");
            }
        }
    }
}