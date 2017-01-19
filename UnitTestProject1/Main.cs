using Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestProject1
{
    class MainClass
    {
        private const string LOG_VAL_EXPRESSION = @"\{\#(\w+)\}";
        /// <summary>
        /// 取LOG现网值参数处理正则表达式
        /// </summary>
        public static readonly Regex LOG_VAL_PATTERN = new Regex(LOG_VAL_EXPRESSION, RegexOptions.Compiled);

        public static void Main(string[] args)
        {
            Console.WriteLine("begin...");
            //Test1();
            //test2();
            Test3();
            //Test4();

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

        static void Test4()
        {
            var s1 = "ojfowamfowanf aweglmo awf @Value($role-base) edit {#tte}";
            var res = LOG_VAL_PATTERN.Match(s1).Groups[1].Value;

            var val = LOG_VAL_PATTERN.Replace(s1, (Match m) =>
            {
                return "ddd";
            });

            Console.WriteLine(s1);
            Console.WriteLine(res);
            Console.WriteLine(val);
        }
    }
}
