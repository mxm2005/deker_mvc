using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Mxm.Common;

namespace Mxm.DAL
{
	/// <summary>
	/// ���ݷ�����article��
	/// </summary>
	public class article
	{
		public article()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("aid", "article"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int aid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from article");
			strSql.Append(" where aid=@aid ");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)};
			parameters[0].Value = aid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// ��ȡ�ܼ�¼��,���ü�where�ؼ���
        /// </summary>
        public int GetCount(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from article ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return (int)obj;
            }
            else
            {
                return 0;
            }
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Mxm.Model.article model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into article(");
			strSql.Append("title,content,create_time,update_time,author,sub_title,editor,status,type_id,picture_small,sumary)");
			strSql.Append(" values (");
            strSql.Append("@title,@content,@create_time,@update_time,@author,@sub_title,@editor,@status,@type_id,@picture_small,@sumary)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@content", SqlDbType.NVarChar,0),
					new SqlParameter("@create_time", SqlDbType.DateTime),
					new SqlParameter("@update_time", SqlDbType.DateTime),
					new SqlParameter("@author", SqlDbType.NVarChar,50),
                    new SqlParameter("@sub_title", SqlDbType.NVarChar,500),
                    new SqlParameter("@editor", SqlDbType.NVarChar,50),
                    new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@type_id", SqlDbType.Int,4),
                    new SqlParameter("@picture_small", SqlDbType.NVarChar,400),
                    new SqlParameter("@sumary", SqlDbType.NVarChar,1000)
                };
			parameters[0].Value = model.title;
			parameters[1].Value = model.content;
			parameters[2].Value = model.create_time;
			parameters[3].Value = model.update_time;
			parameters[4].Value = model.author;
            parameters[5].Value = model.Sub_title;
            parameters[6].Value = model.Editor;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Type_id;
            parameters[9].Value = model.Picture_small;
            parameters[10].Value = model.Sumary;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return -1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Mxm.Model.article model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update article set ");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("update_time=@update_time,");
            strSql.Append("author=@author,");
            strSql.Append("sub_title=@sub_title,");
            strSql.Append("editor=@editor,");
            strSql.Append("status=@status,");
            strSql.Append("type_id=@type_id,");
            strSql.Append("picture_small=@picture_small,");
            strSql.Append("sumary=@sumary");
            strSql.Append(" where aid=@aid ");
            SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,8),
					new SqlParameter("@title", SqlDbType.NVarChar,500),
					new SqlParameter("@content", SqlDbType.NVarChar,0),
					new SqlParameter("@update_time", SqlDbType.DateTime),
					new SqlParameter("@author", SqlDbType.NVarChar,50),
					new SqlParameter("@sub_title", SqlDbType.NVarChar,500),
					new SqlParameter("@editor", SqlDbType.NVarChar,50),
					new SqlParameter("@status", SqlDbType.Int,4),
                    new SqlParameter("@type_id", SqlDbType.Int,4),
                    new SqlParameter("@picture_small", SqlDbType.NVarChar,400),
                    new SqlParameter("@sumary", SqlDbType.NVarChar,1000)
            };
            parameters[0].Value = model.aid;
            parameters[1].Value = model.title;
            parameters[2].Value = model.content;
            parameters[3].Value = model.update_time;
            parameters[4].Value = model.author;
            parameters[5].Value = model.Sub_title;
            parameters[6].Value = model.Editor;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.Type_id;
            parameters[9].Value = model.Picture_small;
            parameters[10].Value = model.Sumary;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int aid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete article ");
			strSql.Append(" where aid=@aid ");
			SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)};
			parameters[0].Value = aid;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
        
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Mxm.Model.article GetModel(int aid)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aid,title,content,create_time,update_time,author,sub_title,editor,status,type_id,picture_small,sumary from article ");
            strSql.Append(" where aid=@aid ");
            SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)};
            parameters[0].Value = aid;

            Mxm.Model.article model = new Mxm.Model.article();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["aid"].ToString() != "")
                {
                    model.aid = int.Parse(ds.Tables[0].Rows[0]["aid"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(ds.Tables[0].Rows[0]["update_time"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                model.Sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.Editor = ds.Tables[0].Rows[0]["editor"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    model.Type_id = int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
                }
                model.Picture_small = ds.Tables[0].Rows[0]["picture_small"].ToString();
                model.Sumary = ds.Tables[0].Rows[0]["sumary"].ToString();
                return model;
            }
            else
            {
                return null;
            }
		}

        /// <summary>
        /// �õ���һƪ����һƪ
        /// <param name="aid">��ǰID</param>
        /// <param name="flag">��һƪ:0,��һƪ:1</param>
        /// <param name="where">��ѯ����</param>
        /// </summary>
        public Mxm.Model.article GetNextModel(int aid,int flag,string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aid,title,content,create_time,update_time,author,sub_title,editor,status,type_id,Picture_small,sumary from article where ");
            if (!string.IsNullOrEmpty(where))
            {
                strSql.Append( where + " and ");
            }
            if (flag > 0)//��һƪ
            {
                strSql.Append(" aid<@aid order by aid desc");
            }
            else//��һƪ
            {
                strSql.Append(" aid>@aid order by aid asc");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@aid", SqlDbType.Int,4)};
            parameters[0].Value = aid;

            Mxm.Model.article model = new Mxm.Model.article();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["aid"].ToString() != "")
                {
                    model.aid = int.Parse(ds.Tables[0].Rows[0]["aid"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["create_time"].ToString() != "")
                {
                    model.create_time = DateTime.Parse(ds.Tables[0].Rows[0]["create_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["update_time"].ToString() != "")
                {
                    model.update_time = DateTime.Parse(ds.Tables[0].Rows[0]["update_time"].ToString());
                }
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                model.Sub_title = ds.Tables[0].Rows[0]["sub_title"].ToString();
                model.Editor = ds.Tables[0].Rows[0]["editor"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    model.Type_id = int.Parse(ds.Tables[0].Rows[0]["type_id"].ToString());
                }
                model.Picture_small = ds.Tables[0].Rows[0]["picture_small"].ToString();
                model.Sumary = ds.Tables[0].Rows[0]["sumary"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aid,title,content,create_time,update_time,author,sub_title,editor,status,type_id,picture_small,sumary ");
            strSql.Append(" FROM article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strWhere">�������ʽ�����ü�"where"</param>
        /// <param name="order">�����ֶ���������</param>
        /// <returns></returns>
        public DataSet GetList(string strWhere,string order)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select aid,title,content,create_time,update_time,author,sub_title,editor,status,type_id,picture_samll,sumary ");
            strSql.Append(" FROM article ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (order.Trim() != "")
            {
                strSql.Append(" order by " + strWhere + " desc");
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "article";
			parameters[1].Value = "aid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}

        /// <summary>
        /// ��ҳ��ѯ
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="fldName">��ѯ�ֶ���</param>
        /// <param name="strWhere"></param>
        /// <param name="orderBy">�����ֶ�</param>
        /// <param name="orderType">�������ͣ��� 0 ֵ����</param>
        /// <returns></returns>
        public DataSet GetList(int PageSize, int PageIndex,string fldName, string strWhere,string orderBy,int orderType)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 2000),
                    new SqlParameter("@OrderfldName", SqlDbType.VarChar, 255),//�����ֶ���
					new SqlParameter("@StatfldName", SqlDbType.VarChar, 255),//ͳ���ֶ�
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),//���ؼ�¼����, �� 0 ֵ�򷵻� 
					new SqlParameter("@OrderType", SqlDbType.Bit),//������������, �� 0 ֵ���� 
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "article";
            parameters[1].Value = fldName;
            parameters[2].Value = orderBy;
            parameters[3].Value = "aid";
            parameters[4].Value = PageSize;
            parameters[5].Value = PageIndex;
            parameters[6].Value = 0;
            parameters[7].Value = orderType;
            parameters[8].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPageOrder", parameters, "ds");
        }

		#endregion  ��Ա����
	}
}

