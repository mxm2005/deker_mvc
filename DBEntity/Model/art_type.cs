using System;
namespace Mxm.Model
{
	/// <summary>
	/// ʵ����art_type ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class art_type
	{
		public art_type()
		{}
		#region Model
		private int _type_id;
		private string _type_name;
		/// <summary>
		/// 
		/// </summary>
		public int type_id
		{
			set{ _type_id=value;}
			get{return _type_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_name
		{
			set{ _type_name=value;}
			get{return _type_name;}
		}
		#endregion Model

	}
}

