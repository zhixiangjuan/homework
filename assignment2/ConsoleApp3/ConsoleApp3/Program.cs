using System;
class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        do
        {
            Console.WriteLine("请输入数组长度");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);
        int[] arr = new int[n];
        Console.WriteLine("请输入数组元素，以空格隔开");
        string[] str = Console.ReadLine().Split(' ');
        int max = Convert.ToInt32(str[0]);
        int min = Convert.ToInt32(str[0]);
        int sum = 0;
        for (int i=0;i<n;i++)
        {
            arr[i] = Convert.ToInt32(str[i]);
            if (arr[i] < min) min = arr[i];
            if (arr[i] > max) max = arr[i];
            sum += arr[i];
        }
        int aver = sum / n;
        Console.WriteLine("最大值：" + max + " 最小值：" + min + " 平均值：" + aver + " 总和：" + sum);
    }
}