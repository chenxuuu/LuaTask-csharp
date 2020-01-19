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
sys.async('net45Test','net45Test.Test.test',{123,'text Test'},
function(r,data)
print('cb function',r,data,os.time())
end)
print(os.time())

sys.timerStart(print,2000,'2 seconds')
sys.timerLoopStart(print,1000,'loop')

sys.taskInit(function()
    while true do 
        print('task1',os.time())
        sys.wait(1000)
    end
end)
sys.taskInit(function()
    while true do 
        print('task2',os.time())
        sys.wait(1000)
    end
end)
");



            Console.ReadLine();
        }
    }

    class Test
    {
        public static int test(long s,string text)
        {
            Console.WriteLine($"test,{s},{text}");
            Task.Delay(5000).Wait();
            return 123;
        }
    }
}
