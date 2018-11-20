using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KB.Model
{
    /// <summary>
    /// 实体类DATA0001 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class DATA0001
    {
        #region Model
        public DATA0001()
        { }
        #region Model
        private int _rkey;
        private int _ID;
        private DateTime? _Applytime;
        private string _dept;
        private string _name;
        private string _number;
        private string _kind;
        private string _type;
        private string _reachtime;
        private string _protype;
        private string _mapnumb;
        private string _attach;
        private string _reason;

        #endregion

        /// <summary>
		/// <RKEY>
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
        /// <summary>
		/// 
		/// </summary>
		public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
		/// 
		/// </summary>
		public DateTime?  APPLYTIME
        {
            set { _Applytime = value; }
            get { return _Applytime; }
        }
        public string DEPT
        {
            set { _dept = value; }
            get { return _dept; }
        }
        public string NAME
        {
            set { _name = value; }
            get { return _name; }
        }
        public string NUMBER
        {
            set { _number = value; }
            get { return _number; }
        }
        public string KIND
        {
            set { _kind = value; }
            get { return _kind; }
        }
        public string TYPE
        {
            set { _type = value; }
            get { return _type; }
        }
        public string REACHTIME
        {
            set { _reachtime = value; }
            get { return _reachtime; }
        }
        public string PROTYPE
        {
            set { _protype = value; }
            get { return _protype; }
        }
        public string MAPNUMB
        {
            set { _mapnumb = value; }
            get { return _mapnumb; }
        }
        public string ATTACH
        {
            set { _attach = value; }
            get { return _attach; }
        }
        public string REASON
        {
            set { _reason = value; }
            get { return _reason; }
        }

#endregion Model




    }

}
