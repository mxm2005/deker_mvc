using System;
namespace Mxm.Model
{
	/// <summary>
	/// ʵ����message ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class message
	{
		public message()
		{}
		#region Model
		private int _mid;
		private string _title;
		private string _content;
		private int _parent_id;
		private DateTime _create_time;
        private int _type_id;

		/// <summary>
		/// 
		/// </summary>
		public int mid
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int parent_id
		{
			set{ _parent_id=value;}
			get{return _parent_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime create_time
		{
			set{ _create_time=value;}
			get{return _create_time;}
		}
        /// <summary>
        /// ����ID
        /// </summary>
        public int type_id
        {
            set { _type_id = value; }
            get { return _type_id; }
        }
		#endregion Model

	}
}

