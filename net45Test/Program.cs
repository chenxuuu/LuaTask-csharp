using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net45Test
{
    class Program
    {
        static void Main(string[] args)
        {
            LuaTask.LuaEnv l = new LuaTask.LuaEnv();
            l.ErrorEvent += (e, d) =>
            {
                Console.WriteLine(d);
            };

            l.DoString(@"
sys.async('net45Test','net45Test.Test.test',1,
function(r,data)
print('cb function',r,data,os.time())
end)
print(os.time())
");



            Console.ReadLine();
        }
    }

    class Test
    {
        public static int test(long s,string text)
        {
            Console.WriteLine($"long string,{s},{text}");
            Task.Delay(5000).Wait();
            return 123;
        }

        public static int test(long s, long text)
        {
            Console.WriteLine($"long long,{s},{text}");
            Task.Delay(5000).Wait();
            return 123;
        }

        public static int test()
        {
            Console.WriteLine($"none");
            Task.Delay(5000).Wait();
            return 123;
        }

        public static void test(long a)
        {
            Console.WriteLine($"void");
            Task.Delay(5000).Wait();
        }
    }
}
