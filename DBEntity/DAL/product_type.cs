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
	/// ���ݷ�����product_type��
	/// </summary>
	public class product_type
	{
		public product_type()
		{}
		#region  ��Ա����

		/// <summary>
		/// �õ����������ļ�¼��
		/// </summary>
		public int GetCount(string where )
		{
            string strsql = "select count(1) from product_type ";
            if (!string.IsNullOrEmpty(where))
            {
                strsql += " where " + where;
            }
			Database db = DatabaseFactory.CreateDatabase();
			object obj = db.ExecuteScalar(CommandType.Text, strsql);
			if (obj != null && obj != DBNull.Value)
			{
				return int.Parse(obj.ToString());
			}
			return 0;
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string type_name)
		{
			Database db = DatabaseFactory.CreateDatabase();
			StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from product_type where type_name=@type_name ");
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "type_name", DbType.String, type_name);
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
		public int Add(Mxm.Model.product_type model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into product_type(");
            strSql.Append("type_name,parent_id,banner,remark)");

            strSql.Append(" values (");
            strSql.Append("@type_name,@parent_id,@banner,@remark)");
            strSql.Append(";select @@IDENTITY");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "type_name", DbType.String, model.type_name);
            db.AddInParameter(dbCommand, "parent_id", DbType.Int32, model.parent_id);
            db.AddInParameter(dbCommand, "banner", DbType.String, model.banner);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            int result;
            object obj = db.ExecuteScalar(dbCommand);
            if (!int.TryParse(obj.ToString(), out result))
            {
                return 0;
            }
            return result;
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Mxm.Model.product_type model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update product_type set ");
            strSql.Append("type_name=@type_name,");
            strSql.Append("parent_id=@parent_id,");
            strSql.Append("banner=@banner,");
            strSql.Append("remark=@remark");
            strSql.Append(" where type_id=@type_id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "type_id", DbType.Int32, model.type_id);
            db.AddInParameter(dbCommand, "type_name", DbType.String, model.type_name);
            db.AddInParameter(dbCommand, "parent_id", DbType.Int32, model.parent_id);
            db.AddInParameter(dbCommand, "banner", DbType.String, model.banner);
            db.AddInParameter(dbCommand, "remark", DbType.String, model.remark);
            db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int type_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete product_type ");
			strSql.Append(" where type_id=@type_id ");
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
			db.AddInParameter(dbCommand, "type_id", DbType.Int32,type_id);
			db.ExecuteNonQuery(dbCommand);

		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Mxm.Model.product_type GetModel(int type_id)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select type_id,type_name,parent_id,banner,remark from product_type ");
            strSql.Append(" where type_id=@type_id ");
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand(strSql.ToString());
            db.AddInParameter(dbCommand, "type_id", DbType.Int32, type_id);
            Mxm.Model.product_type model = null;
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                if (dataReader.Read())
                {
                    model = ReaderBind(dataReader);
                }
            }
            return model;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select type_id,type_name,parent_id,banner,remark ");
            strSql.Append(" FROM product_type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            Database db = DatabaseFactory.CreateDatabase();
            return db.ExecuteDataSet(CommandType.Text, strSql.ToString());
		}

         /// <summary>
        /// ��ҳ��ȡ�����б�
         /// </summary>
         /// <param name="PageSize"></param>
         /// <param name="PageIndex"></param>
         /// <param name="strWhere"></param>
         /// <returns></returns>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("UP_GetRecordByPage");
            db.AddInParameter(dbCommand, "tblName", DbType.AnsiString, "product_type");
            db.AddInParameter(dbCommand, "fldName", DbType.AnsiString, "ID");
            db.AddInParameter(dbCommand, "PageSize", DbType.Int32, PageSize);
            db.AddInParameter(dbCommand, "PageIndex", DbType.Int32, PageIndex);
            db.AddInParameter(dbCommand, "IsReCount", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "OrderType", DbType.Boolean, 0);
            db.AddInParameter(dbCommand, "strWhere", DbType.AnsiString, strWhere);
            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
		/// </summary>
		public List<Mxm.Model.product_type> GetListArray(string strWhere)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select type_id,type_name,parent_id,banner,remark,sort ");
            strSql.Append(" FROM product_type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort ");
            List<Mxm.Model.product_type> list = new List<Mxm.Model.product_type>();
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
        /// ��������б�
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Mxm.Model.product_type> GetListArray(int PageSize, int PageIndex, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top ");
            strSql.Append(PageSize);
            strSql.Append(" type_id,type_name,parent_id,banner,remark,sort ");
            strSql.Append(" FROM product_type ");
            strSql.Append(" where type_id not in ( select top ");
            strSql.Append(PageSize * (PageIndex - 1));
            strSql.Append(" type_id from product_type order by sort ) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" and " + strWhere);
            }
            strSql.Append(" order by sort ");
            List<Mxm.Model.product_type> list = new List<Mxm.Model.product_type>();
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
        /// ��������б���DataSetЧ�ʸߣ��Ƽ�ʹ�ã�
        /// <param name="strWhere">����</param>
        /// <param name="size">������ȡ</param>
        /// </summary>
        public List<Mxm.Model.product_type> GetListArray(string strWhere,int size)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + size);
            strSql.Append(" type_id,type_name,parent_id,banner,remark  ");
            strSql.Append(" FROM product_type ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort ");
            List<Mxm.Model.product_type> list = new List<Mxm.Model.product_type>();
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
		/// ����ʵ�������
		/// </summary>
		public Mxm.Model.product_type ReaderBind(IDataReader dataReader)
		{
            Mxm.Model.product_type model = new Mxm.Model.product_type();
            object ojb;
            ojb = dataReader["type_id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.type_id = (int)ojb;
            }
            model.type_name = dataReader["type_name"].ToString();
            ojb = dataReader["parent_id"];
            if (ojb != null && ojb != DBNull.Value)
            {
                model.parent_id = (int)ojb;
            }
            model.banner = dataReader["banner"].ToString();
            model.remark = dataReader["remark"].ToString();
            return model;
		}

		#endregion  ��Ա����
	}
}

