//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2012-3-16 9:17:06
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KB.Models
{
    ///<summary>
    ///数据实体 [表名("FOUNDERPCB_MENU_EXT")]
    /// </summary>
    [Serializable()]
    public class FOUNDERPCB_MENU_EXT : ICloneable
    {
        /// <summary>
        ///  成员 
        /// </summary>
        private decimal rkey;
        private string classname = String.Empty;
        private int imgindex;
        private bool runnable;

        ///<summary>
        ///  构造方法
        ///</summary>
        public FOUNDERPCB_MENU_EXT() { }

        ///<summary>
        ///主键 [字段("RKEY")]
        ///数据库类型:numeric(18, 0)
        ///</summary> 
        public decimal RKEY
        {
            get { return this.rkey; }
            set { this.rkey = value; }
        }



        ///<summary>
        ///属性 [("ClassName")]
        ///数据库类型:varchar(100)
        ///</summary>
        public string CLASSNAME
        {
            get { return this.classname; }
            set { this.classname = value; }
        }

        ///<summary>
        ///属性 [("ImgIndex")]
        ///数据库类型:int
        ///</summary>
        public int IMGINDEX
        {
            get { return this.imgindex; }
            set { this.imgindex = value; }
        }

        ///<summary>
        ///属性 [("Runnable")]
        ///数据库类型:bit(1)
        ///</summary>
        public bool RUNNABLE
        {
            get { return this.runnable; }
            set { this.runnable = value; }
        }

        /// <summary>
        /// ICloneable 实现克隆本身, 深度克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BinaryFormatter Formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            MemoryStream stream = new MemoryStream();
            Formatter.Serialize(stream, this);
            stream.Position = 0;
            object clonedObj = Formatter.Deserialize(stream);
            stream.Close();
            return clonedObj;
        }
    }
}
