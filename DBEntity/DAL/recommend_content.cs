using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;

namespace Mxm.DAL
{
	/// <summary>
	/// ���ݷ�����recommend_content��
	/// </summary>
	public class recommend_content
	{
		public recommend_content()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			string strsql = "select max(id)+1 from recommend_content";
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 1;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
			strSql.Append("select count(1) from recommend_content where id=@id ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			int cmdresult;
			object obj = db.ExecuteScalar(dbCommand);
			if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
			{
				cmdresult = 0;
			}
			else
			{
				cmdresult = int.Parse(obj.ToString());
			}
			if (cmdresult == 0)
			{
				return false;
			}
			else
			{
				return true;
			}
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(Mxm.Model.recommend_content model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into recommend_content(");
			strSql.Append("title,content,url,picture,group_id)");

			strSql.Append(" values (");
			strSql.Append("@title,@content,@url,@picture,@group_id)");
			strSql.Append(";select @@IDENTITY");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "content", DbType.String, model.content);
			db.AddInParameter(dbCommand, "url", DbType.String, model.url);
			db.AddInParameter(dbCommand, "picture", DbType.String, model.picture);
			db.AddInParameter(dbCommand, "group_id", DbType.Int32, model.group_id);
			int result;
			object obj = db.ExecuteScalar(dbCommand);
			if(!int.TryParse(obj.ToString(),out result))
			{
				return 0;
			}
			return result;
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Mxm.Model.recommend_content model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update recommend_content set ");
			strSql.Append("title=@title,");
			strSql.Append("content=@content,");
			strSql.Append("url=@url,");
			strSql.Append("picture=@picture,");
			strSql.Append("group_id=@group_id");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32, model.id);
			db.AddInParameter(dbCommand, "title", DbType.String, model.title);
			db.AddInParameter(dbCommand, "content", DbType.String, model.content);
			db.AddInParameter(dbCommand, "url", DbType.String, model.url);
			db.AddInParameter(dbCommand, "picture", DbType.String, model.picture);
			db.AddInParameter(dbCommand, "group_id", DbType.Int32, model.group_id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete recommend_content ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Mxm.Model.recommend_content GetModel(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,url,picture,group_id from recommend_content ");
			strSql.Append(" where id=@id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "id", DbType.Int32,id);
			Mxm.Model.recommend_content model=null;
			using (IDataReader dataReader = db.ExecuteReader(dbCommand))
			{
				if(dataReader.Read())
				{
					model=ReaderBind(dataReader);
				}
			}
			return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,url,picture,group_id ");
			strSql.Append(" FROM recommend_content ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			Database db = DatabaseFactory.CreateDatabase();
			return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
			db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "recommend_content");
			db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
			db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
			db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
			db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
			db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
			return db.ExecuteDataSet(dbCommand);
		}*/

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<Mxm.Model.recommend_content> GetListArray(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,title,content,url,picture,group_id ");
			strSql.Append(" FROM recommend_content ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			List<Mxm.Model.recommend_content> list = new List<Mxm.Model.recommend_content>();
			Database db = DatabaseFactory.CreateDatabase();
			using (IDataReader dataReader = db.ExecuteReader(CommandType.Text, strSql.ToString()))
			{
				while (dataReader.Read())
				{
					list.Add(ReaderBind(dataReader));
				}
			}
			return list;
		}

        /// <summary>
        /// ��������б����������Ʋ�ѯ
        /// </summary>
        public List<Mxm.Model.recommend_content> GetListByGroupName(string group_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, title, content, url, picture, group_id from recommend_content ");
            strSql.Append(" where group_id =(select group_id from recommend_group where group_name=@group_name)");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "group_name", DbType.String, group_name);

            List<Mxm.Model.recommend_content> list = new List<Mxm.Model.recommend_content>();
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    list.Add(ReaderBind(dataReader));
                }
            }
            return list;
        }


		/// <summary>
		/// ����ʵ�������
		/// </summary>
		public Mxm.Model.recommend_content ReaderBind(IDataReader dataReader)
		{
			Mxm.Model.recommend_content model=new Mxm.Model.recommend_content();
			object ojb; 
			ojb = dataReader["id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.id=(int)ojb;
			}
			model.title=dataReader["title"].ToString();
			model.content=dataReader["content"].ToString();
			model.url=dataReader["url"].ToString();
			model.picture=dataReader["picture"].ToString();
			ojb = dataReader["group_id"];
			if(ojb != null && ojb != DBNull.Value)
			{
				model.group_id=(int)ojb;
			}
			return model;
		}

		#endregion  ��Ա����
	}
}

