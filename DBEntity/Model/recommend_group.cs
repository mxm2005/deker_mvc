using System;
namespace Mxm.Model
{
	/// <summary>
	/// ʵ����recommend_group ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class recommend_group
	{
		public recommend_group()
		{}
		#region Model
		private int _group_id;
		private string _group_name;
        private string _remark;

		/// <summary>
		/// 
		/// </summary>
		public int group_id
		{
			set{ _group_id=value;}
			get{return _group_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string group_name
		{
			set{ _group_name=value;}
			get{return _group_name;}
		}
        /// <summary>
        /// ��ע
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
		#endregion Model

	}
}

