using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Model;

namespace KB.DAL
{
    public partial class DATA0001DAL
    {
        #region   字段 and 属性
        DBHelper dbHelper = null;
        ///<sumary>
        ///字段 用于指定目标数据库
        ///</sumary>
        private int factoryid = 0;

        ///<sumary>
        ///属性 用于指定目标数据库
        ///</sumary>
        public int FactoryID
        {
            get
            {
                return this.factoryid;
            }    
            set
            {
                this.factoryid = value;
            }
        }
        #endregion

        #region 构造方法
        public DATA0001DAL(DBHelper DB)
        {
            this.FactoryID = DB.FactoryID;
            this.dbHelper = DB;
        }
        public DATA0001DAL(int factoryID)
        {
            this.FactoryID = factoryID;
            this.dbHelper = new DBHelper(factoryID);
        }
        #endregion 构造方法

        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dbHelper.GetMaxID("RKEY", "DATA0001");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RKEY)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DATA0001 with(nolock) ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RKEY", SqlDbType.Int,4)};
            parameters[0].Value = RKEY;

            return dbHelper.Exists(strSql.ToString(), parameters);
        }


        #region 增加
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DATA0001 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0001(");
            strSql.Append("ID,APPLYTIME,DEPT,NAME,NUMBER,KIND,TYPE,REACHTIME,PROTYPE.MAPNUMB,ATTACH,REASON)");
            strSql.Append(" values (");
            strSql.Append("@ID,@APPLYTIME,@DEPT,@NAME,@NUMBER,@KIND,@TYPE,@REACHTIME,@PROTYPE,@MAPNUMB,@ATTACH,@REASON)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.VarChar,4),
                        new SqlParameter("@APPLYTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@DEPT", SqlDbType.VarChar,4),
                        new SqlParameter("@NAME", SqlDbType.VarChar,4),
                        new SqlParameter("@NUMBER", SqlDbType.VarChar,4),
                        new SqlParameter("@KIND", SqlDbType.VarChar,4),
                        new SqlParameter("@TYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@REACHTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@PROTYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@MAPNUMB", SqlDbType.VarChar,4),
                        new SqlParameter("@ATTACH", SqlDbType.VarChar,4),
                        new SqlParameter("@REASON", SqlDbType.VarChar,4) };
            parameters[0].Value = model.ID;
            parameters[0].Value = model.APPLYTIME;
            parameters[0].Value = model.DEPT;
            parameters[0].Value = model.NAME;
            parameters[0].Value = model.NUMBER;
            parameters[0].Value = model.KIND;
            parameters[0].Value = model.TYPE;
            parameters[0].Value = model.REACHTIME;
            parameters[0].Value = model.PROTYPE;
            parameters[0].Value = model.MAPNUMB;
            parameters[0].Value = model.ATTACH;
            parameters[0].Value = model.REASON;

            object obj = dbHelper.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DATA0001(");
            strSql.Append("ID,APPLYTIME,DEPT,NAME,NUMBER,KIND,TYPE,REACHTIME,PROTYPE.MAPNUMB,ATTACH,REASON)");
            strSql.Append(" values (");
            strSql.Append("@ID,@APPLYTIME,@DEPT,@NAME,@NUMBER,@KIND,@TYPE,@REACHTIME,@PROTYPE,@MAPNUMB,@ATTACH,@REASON)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@ID", SqlDbType.VarChar,4),
                        new SqlParameter("@APPLYTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@DEPT", SqlDbType.VarChar,4),
                        new SqlParameter("@NAME", SqlDbType.VarChar,4),
                        new SqlParameter("@NUMBER", SqlDbType.VarChar,4),
                        new SqlParameter("@KIND", SqlDbType.VarChar,4),
                        new SqlParameter("@TYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@REACHTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@PROTYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@MAPNUMB", SqlDbType.VarChar,4),
                        new SqlParameter("@ATTACH", SqlDbType.VarChar,4),
                        new SqlParameter("@REASON", SqlDbType.VarChar,4) };
            parameters[0].Value = model.ID;
            parameters[0].Value = model.APPLYTIME;
            parameters[0].Value = model.DEPT;
            parameters[0].Value = model.NAME;
            parameters[0].Value = model.NUMBER;
            parameters[0].Value = model.KIND;
            parameters[0].Value = model.TYPE;
            parameters[0].Value = model.REACHTIME;
            parameters[0].Value = model.PROTYPE;
            parameters[0].Value = model.MAPNUMB;
            parameters[0].Value = model.ATTACH;
            parameters[0].Value = model.REASON;

            return dbHelper.ExecuteTranByID(cmd, conn, trans, strSql.ToString(), parameters);
        }
        #endregion 增加

        #region 更新
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(DATA0001 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DATA0001 set ");
            strSql.Append("ID=@ID,");
            strSql.Append("APPLYTIME=@APPLYTIME,");
            strSql.Append("DEPT=@DEPT,");
            strSql.Append("NAME=@NAME,");
            strSql.Append("NUMBER=@NUMBER,");
            strSql.Append("KIND=@KIND,");
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("REACHTIME=@REACHTIME,");
            strSql.Append("PROTYPE=@PROTYPE,");
            strSql.Append("MAPNUMB=@MAPNUMB,");
            strSql.Append("ATTACH=@ATTACH,");
            strSql.Append("REASON=@REASON ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                        new SqlParameter("@RKEY", SqlDbType.VarChar,4),
                        new SqlParameter("@ID", SqlDbType.VarChar,4),
                        new SqlParameter("@APPLYTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@DEPT", SqlDbType.VarChar,4),
                        new SqlParameter("@NAME", SqlDbType.VarChar,4),
                        new SqlParameter("@NUMBER", SqlDbType.VarChar,4),
                        new SqlParameter("@KIND", SqlDbType.VarChar,4),
                        new SqlParameter("@TYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@REACHTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@PROTYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@MAPNUMB", SqlDbType.VarChar,4),
                        new SqlParameter("@ATTACH", SqlDbType.VarChar,4),
                        new SqlParameter("@REASON", SqlDbType.VarChar,4) };
            parameters[0].Value = model.RKEY;
            parameters[0].Value = model.ID;
            parameters[0].Value = model.APPLYTIME;
            parameters[0].Value = model.DEPT;
            parameters[0].Value = model.NAME;
            parameters[0].Value = model.NUMBER;
            parameters[0].Value = model.KIND;
            parameters[0].Value = model.TYPE;
            parameters[0].Value = model.REACHTIME;
            parameters[0].Value = model.PROTYPE;
            parameters[0].Value = model.MAPNUMB;
            parameters[0].Value = model.ATTACH;
            parameters[0].Value = model.REASON;

            dbHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, DATA0001 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DATA0001 set ");
            strSql.Append("ID=@ID,");
            strSql.Append("APPLYTIME=@APPLYTIME,");
            strSql.Append("DEPT=@DEPT,");
            strSql.Append("NAME=@NAME,");
            strSql.Append("NUMBER=@NUMBER,");
            strSql.Append("KIND=@KIND,");
            strSql.Append("TYPE=@TYPE,");
            strSql.Append("REACHTIME=@REACHTIME,");
            strSql.Append("PROTYPE=@PROTYPE,");
            strSql.Append("MAPNUMB=@MAPNUMB,");
            strSql.Append("ATTACH=@ATTACH,");
            strSql.Append("REASON=@REASON ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                        new SqlParameter("@RKEY", SqlDbType.VarChar,4),
                        new SqlParameter("@ID", SqlDbType.VarChar,4),
                        new SqlParameter("@APPLYTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@DEPT", SqlDbType.VarChar,4),
                        new SqlParameter("@NAME", SqlDbType.VarChar,4),
                        new SqlParameter("@NUMBER", SqlDbType.VarChar,4),
                        new SqlParameter("@KIND", SqlDbType.VarChar,4),
                        new SqlParameter("@TYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@REACHTIME", SqlDbType.VarChar,4),
                        new SqlParameter("@PROTYPE", SqlDbType.VarChar,4),
                        new SqlParameter("@MAPNUMB", SqlDbType.VarChar,4),
                        new SqlParameter("@ATTACH", SqlDbType.VarChar,4),
                        new SqlParameter("@REASON", SqlDbType.VarChar,4) };
            parameters[0].Value = model.RKEY;
            parameters[0].Value = model.ID;
            parameters[0].Value = model.APPLYTIME;
            parameters[0].Value = model.DEPT;
            parameters[0].Value = model.NAME;
            parameters[0].Value = model.NUMBER;
            parameters[0].Value = model.KIND;
            parameters[0].Value = model.TYPE;
            parameters[0].Value = model.REACHTIME;
            parameters[0].Value = model.PROTYPE;
            parameters[0].Value = model.MAPNUMB;
            parameters[0].Value = model.ATTACH;
            parameters[0].Value = model.REASON;

            dbHelper.ExecuteTranByNone(cmd, conn, trans, strSql.ToString(), parameters);
        }

        #endregion 更新

        #region 删除
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int RKEY)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DATA0001 ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RKEY", SqlDbType.Int,4)};
            parameters[0].Value = RKEY;

            dbHelper.ExecuteNonQuery(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, int RKEY)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from DATA0001 ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RKEY", SqlDbType.Int,4)};
            parameters[0].Value = RKEY;

            dbHelper.ExecuteTranByNone(cmd, conn, trans, strSql.ToString(), parameters);
        }

        #endregion 删除


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DATA0001 GetModel(int RKEY)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 RKEY,SOURCE_CODE,ID_KEY,ANS_NAME from DATA0001 with(nolock)  ");
            strSql.Append(" where RKEY=@RKEY ");
            SqlParameter[] parameters = {
                    new SqlParameter("@RKEY", SqlDbType.Int,4)};
            parameters[0].Value = RKEY;

            DATA0001 model = new DATA0001();
            DataSet ds = dbHelper.GetDataSet2(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.RKEY = int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
                model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                model.APPLYTIME = DateTime.Parse(ds.Tables[0].Rows[0]["APPLYTIME"].ToString());
                model.DEPT = ds.Tables[0].Rows[0]["DEPT"].ToString();
                model.NAME = ds.Tables[0].Rows[0]["NAME"].ToString();
                model.NUMBER = ds.Tables[0].Rows[0]["NUMBER"].ToString();
                model.KIND = ds.Tables[0].Rows[0]["KIND"].ToString();
                model.TYPE = ds.Tables[0].Rows[0]["TYPE"].ToString();
                model.REACHTIME = ds.Tables[0].Rows[0]["REACHTIME"].ToString();
                model.PROTYPE = ds.Tables[0].Rows[0]["PROTYPE"].ToString();
                model.MAPNUMB = ds.Tables[0].Rows[0]["MAPNUMB"].ToString();
                model.ATTACH = ds.Tables[0].Rows[0]["ATTACH"].ToString();
                model.REASON = ds.Tables[0].Rows[0]["REASON"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RKEY,ID,APPLYTIME,DEPT,NAME,NUMBER,KIND,TYPE,REACHTIME,PROTYPE.MAPNUMB,ATTACH,REASON ");
            strSql.Append(" FROM DATA0001 with(nolock)  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dbHelper.GetDataSet2(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" RKEY,ID,APPLYTIME,DEPT,NAME,NUMBER,KIND,TYPE,REACHTIME,PROTYPE.MAPNUMB,ATTACH,REASON ");
            strSql.Append(" FROM DATA0001 with(nolock) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return dbHelper.GetDataSet2(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "DATA0001";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  成员方法

    }
}
