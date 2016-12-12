using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //string ss = "<leave g='d' f=':last'><![CDATA[exit]]></leave><leave g='a' f=':first'><![CDATA[edit]]></leave>";
            //XElement xe = XElement.Parse(ss);

            //Console.WriteLine(xe.ToString());

            try
            {
                int af = 0;
                long ee = 124625425;
                var ss = ee / af;

            }
            catch (Exception  ex)
            {
                Console.Write(ex.ToString());
            }
            int mainTaskId = 165;
            long detailId = 124625425;
            string rootPath = System.Configuration.ConfigurationManager.AppSettings["CheckResultPath"];
            string dateStr = DateTime.Now.ToString("yyyyMMdd");
            string midPath = string.Format("\\ur_check_task_detail\\{0}\\{1}", dateStr, mainTaskId);
            string fName = string.Format("{0}\\{1}-{2}-{3}.xml",
                midPath, dateStr, mainTaskId, detailId);

            if (!Directory.Exists(rootPath + midPath))
                Directory.CreateDirectory(rootPath + midPath);


            Mxm.Common.TxtOpt.WriteTxt(rootPath + fName, DateTime.Now.ToString());
            Console.WriteLine(rootPath + fName);
            Console.WriteLine(fName);

            Console.Read();
        }
    }
}
