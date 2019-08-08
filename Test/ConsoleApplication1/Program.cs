using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.IO;
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
            //Get();
            //Console.ReadKey();
            //EditFillName();
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

        static void EditFillName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(";20180913102013005.jpg,拉拉队");
            sb.Append(";20180911204213806.jpg,那时的我们");
            sb.Append(";20180913104823160.jpg,海绵宝宝");
            sb.Append(";20180911234946226.jpg,一群小蜜蜂");
            sb.Append(";20180913115316281.jpg,从来不早睡小分队");
            sb.Append(";20180911221129284.jpg,每个人都要好好的");
            sb.Append(";20180911212551738.jpg,三傻大闹218");
            sb.Append(";20180913113024129.jpg,元气美少女战士！");
            sb.Append(";20180912114513809.jpg,95内钳");
            sb.Append(";20180913100147969.jpg,急需赞赞，第一走起");
            sb.Append(";20180914105435658.jpg,飞起来");
            sb.Append(";20180914131335637.jpg,美女队");
            sb.Append(";20180913104127440.jpg,赞赞对");
            sb.Append(";20180912152902599.jpg,天体一霸");
            sb.Append(";20180912151400649.jpg,NicetoMeetU");
            sb.Append(";20180914162037481.jpg,风之子");
            sb.Append(";20180919150840018.jpg,追.忆");
            sb.Append(";20180913101924917.jpg,开心宝宝");
            sb.Append(";20180913115250575.jpg,北鼻！");
            sb.Append(";20180913125459646.jpg,太妹天团");
            sb.Append(";20180913104136136.jpg,Whynot");
            sb.Append(";20180911210946892.jpg,幸福满屋");
            sb.Append(";20180913105840457.jpg,兔子");
            sb.Append(";20180916220321037.jpg,怀念513");
            sb.Append(";20180927092610467.jpg,653兄弟团");
            sb.Append(";20180919144231027.jpg,说得都对队");
            sb.Append(";20180912235047602.jpg,偷心贼");
            sb.Append(";20180914130702341.jpg,快乐");
            sb.Append(";20180915114026645.jpg,广彩");
            sb.Append(";20180915193724363.jpg,亲情");
            sb.Append(";20180911225846075.jpg,那年夏天");
            sb.Append(";20180912105307170.jpg,世界第一退堂鼓队");
            sb.Append(";20180912111235353.jpg,佩琪");
            sb.Append(";20180912111347979.jpg,奶茶杀手在成都");
            sb.Append(";20180912112334920.jpg,成都男女关系图鉴");
            sb.Append(";20180912152702449.jpg,skr大魔王");
            sb.Append(";20180912171048691.jpg,成都老妖精");
            sb.Append(";20180912224240365.jpg,1111");
            sb.Append(";20180913102319014.jpg,宿舍六愤青");
            sb.Append(";20180919143921670.jpg,369很喜欢");
            sb.Append(";20180913122501518.jpg,中大外院男子天团");
            sb.Append(";20180914003209841.jpg,牛牛对");
            sb.Append(";20180918100329663.jpg,开心游");
            sb.Append(";20180915121556851.jpg,小妞");
            sb.Append(";20180915174305805.jpg,君临天下");
            sb.Append(";20180915224542210.jpg,你好");
            sb.Append(";20180916213106058.jpg,735不相信美男");
            sb.Append(";20180917110305392.jpg,110寝室1-6床");
            sb.Append(";20180917134718474.jpg,差一个");
            sb.Append(";20180918084738774.jpg,lucky4");
            sb.Append(";20180919150042499.jpg,脸子");
            sb.Append(";20180918111304249.jpg,414宿舍");
            sb.Append(";20180919144904020.jpg,365超喜欢");
            sb.Append(";20180919145547956.jpg,合家欢");
            sb.Append(";20180920145906719.jpg,358非常棒");
            sb.Append(";20180919152147116.jpg,一家老小");
            sb.Append(";20180920151236006.jpg,AC米兰很喜欢");
            sb.Append(";20180921121927006.jpg,扑街宿舍");
            sb.Append(";20180921123459730.jpg,ST228");
            sb.Append(";20180921123354811.jpg,三刘彭黄罗");
            sb.Append(";20180921124213473.jpg,318滴小逼崽子");
            sb.Append(";20180921125214171.jpg,从211到511");
            sb.Append(";20180921130913217.jpg,602玉米们");
            sb.Append(";20180921131409698.jpg,老男人组");
            sb.Append(";20180921134148040.jpg,Ac90不老");
            sb.Append(";20180921140617182.jpg,214小窝");
            sb.Append(";20180921142949792.jpg,那些花儿");
            sb.Append(";20180921143404259.jpg,105美少女战士");
            sb.Append(";20180921150914899.jpg,代号“禽兽”");
            sb.Append(";20180921143922499.jpg,婷婷玉立");
            sb.Append(";20180921153355751.jpg,北清华南井大Di539");
            sb.Append(";20180921163341068.jpg,509：长长久久");
            sb.Append(";20180921164901359.jpg,骚货们");
            sb.Append(";20180921210802605.jpg,女流氓不问岁数");
            sb.Append(";20180921212822271.jpg,永恒的G2204");
            sb.Append(";20180922152707555.jpg,颜值爆表队");
            sb.Append(";20180922090836104.jpg,有空聚聚吧");

            var str = sb.ToString().Split(';');
            Dictionary<string, string> keyvalue = new Dictionary<string, string>();
            foreach (var item in str)
            {
                var arr = item.Split(',');
                if (arr.Length > 1)
                {
                    keyvalue.Add(arr[0], arr[1]);
                }
            }
            string log = string.Empty;
            DirectoryInfo di = new DirectoryInfo(@"D:\Documents\Tencent Files\569090986\FileRecv\studentCard");
            foreach (FileInfo file in di.GetFiles())//遍历文件夹中的文件
            {
                if (keyvalue.ContainsKey(file.Name))
                {
                    string value = string.Empty;
                    keyvalue.TryGetValue(file.Name, out value);
                    try
                    {
                        file.CopyTo(@"D:\Documents\Tencent Files\569090986\FileRecv\studentCard\new\" + value + ".jpg");
                    }
                    catch {
                        log += ";"+ file.Name;
                    }
                }
            }
        }

    }
}
