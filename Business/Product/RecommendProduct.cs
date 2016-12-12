using Mxm.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;

namespace Business
{
    public class RecommendProduct
    {
        /// <summary>
        /// 显示推荐产品块，目前是自动读取的，没有推荐的
        /// </summary>
        public string GetRecommendProd()
        {
            string res = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            string strTemp = @"<td>
            <div>
                <a href='productview.aspx?pid={0}'>
                    <img alt='' border='0' height='126' src='{1}'
                        style='padding: 3px; width: 150px; margin-right: 20px; width: 126px;' /></a></div>
            <div>
                <a href='productview.aspx?pid={2}' title='{3}'>{4}</a></div>
            </td>";
            string path = ConfigurationManager.AppSettings["imgPath"];
            DataSet ds = new production().GetList(8, 1, "");
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    sb.Append(string.Format(strTemp,
                        row["pid"].ToString(),
                        path + row["picture"].ToString(),
                        row["pid"].ToString(),
                        row["product_name"].ToString(),
                        Comm.GetShortString(row["product_name"].ToString(), 12)
                        ));
                }
                res = "<table cellpadding='0' cellspacing='0' align='center'><tr>" + sb.ToString() + "</tr></table>";
            }
            return res;
        }
    }
}
