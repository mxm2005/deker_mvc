using Business;
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
            Console.WriteLine("begin...");
            //Test1();
            test2();

            Console.WriteLine("...end");
            Console.Read();
        }

        static void Test1()
        {
            try
            {
                int af = 0;
                long ee = 124625425;
                var ss = ee / af;

            }
            catch (Exception ex)
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
        }

        static void test2()
        {
            var lst = RecommendProduct.Instance.GetRecommendProd();
            foreach (var s in lst)
            {
                Console.WriteLine(s.id + "--" + s.title + "--" + s.picture);
            }
        }
    }
}
