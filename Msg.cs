using System.Windows.Forms;
using System.Text.RegularExpressions;
using System;
using System.Text;
using System.Runtime.InteropServices;


namespace rdp
{
    public class Msg
    {
        //==============================================================
        public static void add(string name, string data)   //
        {
            //MessageBox.Show("远程桌面连接对象初始化失败！\r\n\r\n" + ex.Message);
            Console.WriteLine(name+"---"+ data);
        }
        //==============================================================
    }
}
