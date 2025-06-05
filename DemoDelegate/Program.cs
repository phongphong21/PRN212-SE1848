using System.Text;

class Program
{
    public delegate int MyDelegate(int x, int y);
    public delegate int[] YourDelegate(int n);
    static int Cong(int a, int b)
    {
        return a + b;
    }
    static int Tru(int a, int b)
    {
        return a - b;
    }
    static int[] Danhsachsochan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i=i+2)
        {
            list.Add(i);
        }
        return list.ToArray();
    }
    static int[] Danhsachsonguyento(int n)
    {
               List<int> list = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            int count = 0;
            for (int j = 1; j <= i; j++)
            {
                if (i % j == 0)
                {
                    count++;
                }
            }
            if(count == 2) // nếu số nguyên tố thì chỉ có 2 ước là 1 và chính nó
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MyDelegate m = new MyDelegate(Cong);
        Console.WriteLine("5+8= "+ m(5,8));
        m= new MyDelegate(Tru);
        Console.WriteLine("5-8= "+ m(5,8));
        YourDelegate y = new YourDelegate(Danhsachsochan);
        int[] arr = y(10);
        Console.WriteLine("các số chẵn: ");
        foreach(var item in arr)
        {
            Console.WriteLine(item +"\t");
        }
        y = new YourDelegate(Danhsachsonguyento);
        arr = y(20);
        Console.WriteLine("\ncác số nguyên tố: ");
        foreach(var item in arr)
        {
            Console.WriteLine(item +"\t");
        }
    }
}
