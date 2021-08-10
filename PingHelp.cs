using System.Net.NetworkInformation;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Net;
//using System.Net.Sockets;



//https://www.cnblogs.com/soundcode/p/13805092.html
//https://www.cnblogs.com/guohu/p/4601567.html

namespace rdp
{
    public class PingHelp
    {
        public static string PingHost(string host)
        {
            //显示颜色ping 勾选
            //string host = "www.baidu.com";
            string Time_to = "--";
            Ping p1 = new Ping();
            PingReply reply = p1.Send(host); //发送主机名或Ip地址
            //StringBuilder sbuilder;
            if (reply.Status == IPStatus.Success)
            {
                //sbuilder = new StringBuilder();
                //sbuilder.AppendLine(string.Format("Address: {0} ", reply.Address.ToString()));
                //sbuilder.AppendLine(string.Format("RoundTrip time: {0} ", reply.RoundtripTime));
                //sbuilder.AppendLine(string.Format("ok /ms    Time to live: {0} ", reply.Options.Ttl));
                //sbuilder.AppendLine(string.Format("Don't fragment: {0} ", reply.Options.DontFragment));
                //sbuilder.AppendLine(string.Format("Buffer size: {0} ", reply.Buffer.Length));
                //Console.WriteLine(sbuilder.ToString());
                Time_to = string.Format("{0}", reply.Options.Ttl);
            }
            else if (reply.Status == IPStatus.TimedOut)
            {
                //Console.WriteLine("over time");  //超时
                Time_to = LangResx.Common.ping_out;
            }
            else
            {
                //Console.WriteLine("err");   //失败
                Time_to = LangResx.Common.ping_err;
            }
            return Time_to;
        }
    }
}
