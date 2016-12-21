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
            //test2();
            Test3();

            Console.WriteLine("...end");
            Console.Read();
        }

        static void Test1()
        {
            var lst = XmlMgr.Instance.GetHomeBanner();
        }

        static void test2()
        {
            var lst = RecommendProduct.Instance.GetRecommendProd();
            foreach (var s in lst)
            {
                Console.WriteLine(s.id + "--" + s.title + "--" + s.picture);
            }
        }

        static void Test3()
        {
            var lst = new LinqEF.CompanyDataContext().art_type.ToList();
            foreach (var s in lst)
            {
                Console.WriteLine(s.type_id + "--" + s.type_name);
            }
        }
    }
}
