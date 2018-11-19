using System;
using System.Xml;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Web; 
using System.IO;

namespace KB.FUNC
{
    /// <summary>
    /// XmlSource 的摘要说明
    /// </summary>
    public class XmlSource
    {
        #region XmlSource()
        public XmlSource()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region 返回某节点数据源, 及 默认选中项 GetData
        /// <summary>
        /// 返回某节点数据源, 及 默认选中项
        /// </summary>
        /// <param name="nodeName">格式:  Root/节点名称</param>
        /// <returns></returns>
        public static DataTable GetData(string nodeName)
        {
            string fileName = System.IO.Directory.GetCurrentDirectory() + "\\Resources\\Para.dll"; 
            XmlDocument xmDoc = new XmlDocument();
            xmDoc.Load(fileName);

            DataTable tb = new DataTable();
            tb.Columns.Add("id");
            tb.Columns.Add("text");
            tb.Columns.Add("value",typeof(float) );
            tb.Columns.Add("selected");

            XmlNode  parentNode=xmDoc.SelectSingleNode(nodeName);

            foreach (XmlNode node in parentNode.ChildNodes)
            {
                DataRow row = tb.NewRow();
                row["id"] = node.SelectSingleNode("id").InnerText;
                row["text"] = node.SelectSingleNode("text").InnerText; 
                row["value"] = node.SelectSingleNode("value").InnerText;

                try
                {
                    row["selected"] = parentNode.Attributes["selected"].Value;
                }
                catch
                {
                    row["selected"] = "0";
                }

                tb.Rows.Add(row);
            } 
            
            return tb;
        }
        #endregion

        #region 根据fIDList,生成同时操作的库表 GetFactory
        /// <summary>
        /// 根据fIDList,生成同时操作的库表
        /// </summary>
        /// <param name="fIDList"></param>
        /// <returns></returns>
        public static DataTable GetFactory(string fIDList)
        {
            DataTable tb = GetData("Root/Factory");
            
            tb.TableName = "FactoryInfo";

            DataView dv = new DataView();
            dv.Table = tb;
            dv.RowFilter = "value in (" + fIDList + "-1)";
            
            /// 返回
            return dv.ToTable();
        }
        #endregion

        #region 获取工厂中文名 GetFactoryName
        /// <summary>
        /// 获取工厂中文名
        /// </summary>
        /// <param name="Factoryid">工厂ID</param>
        /// <returns>工厂中文名</returns>
        public static string GetFactoryName(int Factoryid)
        {
            string tmp = "";
            foreach (DataRow row in GetData("Root/Factory").Rows)
            {
                if (row["value"].ToString() == Factoryid.ToString())
                {
                    tmp = row["text"].ToString();
                }
            }           
            return tmp;
        }
        #endregion
    }
}