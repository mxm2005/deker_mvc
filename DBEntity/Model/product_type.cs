using System;
namespace Mxm.Model
{
	/// <summary>
	/// ʵ����product_type ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class product_type
	{
		public product_type()
		{}
		#region Model
		private int _type_id;
		private string _type_name;
		private int _parent_id;
        private string _banner;
        private string _remark;
        private int _sort;
		/// <summary>
		/// ����ID
		/// </summary>
		public int type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
		}
		/// <summary>
		/// ����ID
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
        /// <summary>
        /// BannerͼƬ
        /// </summary>
        public string banner
        {
            set { _banner = value; }
            get { return _banner; }
        }
        /// <summary>
        /// ������ע
        /// </summary>
        public string remark
        {
            set { _remark= value; }
            get { return _remark; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
		#endregion Model

	}
}

