using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KB.Model;

using KB.DAL;
namespace KB.BLL
{
    public class DATA0001BLL
    {
        private DATA0001DAL dal = null;
        #region 构造方法
        public DATA0001BLL(DBHelper DB)
        {
            dal = new DATA0001DAL(DB);
        }
        public DATA0001BLL(int factoryID)
        {
            dal = new DATA0001DAL(factoryID);
        }
        #endregion

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RKEY)
        {
            return dal.Exists(RKEY);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DATA0001 model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 model)
        {
            return dal.Add(cmd, conn, trans, model);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DATA0001 model)
        {
            dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 model)
        {
            dal.Update(cmd, conn, trans, model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RKEY)
        {

            dal.Delete(RKEY);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, int RKEY)
        {

            dal.Delete(cmd, conn, trans, RKEY);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DATA0001 GetModel(int RKEY)
        {

            return dal.GetModel(RKEY);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DATA0001> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DATA0001> DataTableToList(DataTable dt)
        {
            List<DATA0001> modelList = new List<DATA0001>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DATA0001 model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new DATA0001();
                    if (dt.Rows[n]["RKEY"].ToString() != "")
                    {
                        model.RKEY = int.Parse(dt.Rows[n]["RKEY"].ToString());
                    }
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }

                    model.APPLYTIME = DateTime.Parse(dt.Rows[0]["APPLYTIME"].ToString());
                    model.DEPT = dt.Rows[0]["DEPT"].ToString();
                    model.NAME = dt.Rows[0]["NAME"].ToString();
                    model.NUMBER = dt.Rows[0]["NUMBER"].ToString();
                    model.KIND = dt.Rows[0]["KIND"].ToString();
                    model.TYPE = dt.Rows[0]["TYPE"].ToString();
                    model.REACHTIME = dt.Rows[0]["REACHTIME"].ToString();
                    model.PROTYPE = dt.Rows[0]["PROTYPE"].ToString();
                    model.MAPNUMB = dt.Rows[0]["MAPNUMB"].ToString();
                    model.ATTACH = dt.Rows[0]["ATTACH"].ToString();
                    model.REASON = dt.Rows[0]["REASON"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法

    }
}
