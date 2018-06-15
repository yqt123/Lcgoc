using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //static RedisClient redisClient = new RedisClient("172.16.147.121", 6379);//redis服务IP和端口

        static void Main(string[] args)
        {
            //Console.WriteLine(redisClient.Get<string>("city"));
            //Console.ReadKey();
            Get();
            Console.ReadKey();
        }

        //redis写入
        static void Set()
        {
            using (IRedisClient con = RedisManage.ClientManager.GetClient())
            {
                //存数据
                con.Set<int>("age", 18);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic["yzk"] = "test";
                con.Set<Dictionary<string, string>>("dic", dic);
            }
        }

        //读取数据
        static void Get()
        {
            using (IRedisClient con = RedisManage.ClientManager.GetClient())
            {
                //取数据
                int age = con.Get<int>("age");
                Console.WriteLine(age);
                Dictionary<string, string> dic = con.Get<Dictionary<string, string>>("dic");
                Console.WriteLine(dic["yzk"]);
            }
        }
    }
}
