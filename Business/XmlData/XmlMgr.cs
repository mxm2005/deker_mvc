using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using LinqEF;

namespace Business
{
    public class XmlMgr
    {
        #region singleton
        private static XmlMgr _instance = new XmlMgr();
        public static XmlMgr Instance
        {
            get { return _instance; }
        }
        private XmlMgr()
        {
            
        }
        #endregion

        public List<XmlDataEn> GetHomeBanner()
        {
            var reList = new List<XmlDataEn>();
            var path = AppDomain.CurrentDomain.BaseDirectory + "Content\\XmlData\\index.xml";

            var dt = XmlAction.ReadToDt(path);
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    reList.Add(new XmlDataEn { id =i, img = dt.Rows[i]["img"].ToString(), key = dt.Rows[i]["key"].ToString(), url = dt.Rows[i]["url"].ToString() });

                }
            }

            return reList;
        }
    }
}
