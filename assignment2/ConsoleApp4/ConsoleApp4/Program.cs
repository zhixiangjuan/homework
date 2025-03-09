using System;
class Program
{
    static void Main(string[] args)
    {
        int[] num = new int[100];
        num[0] = 1;
        for(int i=1;i<100;i++)
        {
            if (num[i]==0)
                for(int j=i+1;j<100;j++)
                    if ((j + 1) % (i + 1) == 0) num[j] = 1;
        }
        for (int i = 0; i < 100; i++)
            if (num[i] == 0) Console.Write((i + 1) + " ");
    }
}