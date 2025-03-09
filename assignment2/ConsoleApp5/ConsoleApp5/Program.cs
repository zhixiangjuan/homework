using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("请输入矩阵的高");
        int m = int.Parse(Console.ReadLine());
        Console.WriteLine("请输入矩阵的宽");
        int n = int.Parse(Console.ReadLine());
        int[][] num = new int[m][];
        for(int i=0;i<m;i++)
        {
            num[i] = new int[n];
            string[] str = Console.ReadLine().Split(' ');
            for (int j = 0; j < n; j++)
                num[i][j] = int.Parse(str[j]);
        }
        if (m != n) { Console.WriteLine("false"); return; }
        for (int i = 0; i < m-1; i++)
            if (num[i][i] != num[i + 1][i+1]) { Console.WriteLine("false"); return; }
        Console.WriteLine("true"); return;
    }
}