using LinqEF;
using LinqEF.ResModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business
{
    public class ProductTypeMgr
    {
        private CompanyDataContext ctx;

        public ProductTypeMgr()
        {
            ctx = new CompanyDataContext();
        }

        /// <summary>
        /// 获取菜单产品分类列表
        /// </summary>
        /// <returns></returns>
        public ResponseListModel<NestedProductType> GetMenuList()
        {
            var reVal = new ResponseListModel<NestedProductType>();
            reVal.List=new List<NestedProductType>();
            
            var lstAll = GetAllType();
            var lst = lstAll
                .Where(s => s.parent_id == 0)
                .Take(4)
                .ToList();

            foreach (var item in lst)
            {
                var ni = new NestedProductType()
                {
                    banner = item.banner,
                    parent_id = item.parent_id,
                    remark = item.remark,
                    sort = item.sort,
                    type_id = item.type_id,
                    type_name = item.type_name,
                    Child = lstAll.Where(s => s.parent_id == item.type_id).Take(4).ToList()
                };
                reVal.List.Add(ni);
            }

            reVal.Total = lst.Count();
            return reVal;
        } 

        /// <summary>
        /// 获取产品分类列表
        /// </summary>
        /// <param name="parentid"></param>
        /// <returns></returns>
        public ResponseListModel<product_type> GetList(int parentid)
        {
            var reVal = new ResponseListModel<product_type>();
            var lst = ctx.product_type
                .Take(100)
                .ToList();
            reVal.List = lst;
            reVal.Total = lst.Count();
            return reVal;
        }

        /// <summary>
        /// 获取所有产品分类
        /// </summary>
        /// <returns></returns>
        public List<product_type> GetAllType()
        {
            var lst = ctx.product_type.ToList();
            return lst;
        }
    }
}
