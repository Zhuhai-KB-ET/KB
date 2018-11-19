using System;
using System.Collections.Generic;
using KB.Models;
using System.Text;

namespace KB.DAL
{
    public class FactoryDAL
    {
        public string ConnString
        {
            get;
            set;
        }
        private AccessDBHelper db;
        public FactoryDAL(string connString)
        {
            db = new AccessDBHelper(connString);
        }
        public int Add(KB.Models.Factory facotry)
        {
            string sql = "insert into Factory(FactoryName,FactoryIndex) values('{0}',{1});";
            return db.Add(string.Format(sql, facotry.FactoryName, facotry.FactoryIndex));
        }
        public int Update(KB.Models.Factory factory)
        {
            string sql = "update factory set FactoryName='{0}',FactoryIndex={1} where FactoryID={2}";
            return db.ExecuteCommand(string.Format(sql, factory.FactoryName, factory.FactoryIndex, factory.FactoryID));
        }
        public int Delete(KB.Models.Factory factory)
        {
            string sql = "delete from factory where FactoryID={0}";
            return db.ExecuteCommand(string.Format(sql, factory.FactoryID));
        }
    }

    public class SystemParameterDAL
    {
        public string ConnString
        {
            get;
            set;
        }
        private AccessDBHelper db;
        public SystemParameterDAL(string connString)
        {
            db = new AccessDBHelper(connString);
        }
        public int Add(SystemParameter systemParameter)
        {
            string sql = "insert into SystemParameter(ParamenterName,ParamenterValue) values('{0}',{1});";
            return db.Add(string.Format(sql, systemParameter.ParameterName, systemParameter.ParameterValue));
        }
        public int Update(SystemParameter systemParameter)
        {
            string sql = "update SystemParameter set ParamenterName='{0}',ParamenterValue={1} where ID={2}";
            return db.ExecuteCommand(string.Format(sql, systemParameter.ParameterName, systemParameter.ParameterValue, systemParameter.ID));
        }
        public int Delete(SystemParameter systemParameter)
        {
            string sql = "delete from SystemParameter where ID={0}";
            return db.ExecuteCommand(string.Format(sql, systemParameter.ID));
        }
    }

    public class DBConnectionDAL
    {
        public string ConnString
        {
            get;
            set;
        }
        private AccessDBHelper db;
        public DBConnectionDAL(string connString)
        {
            db = new AccessDBHelper(connString);
        }
        public int Add(DBConnection dbConn)
        {
            string sql = "insert into DBConnection(FactoryIndex,DBName,DBIndex,ConnectionString) values({0},'{1}',{2},'{3}');";
            return db.Add(string.Format(sql, dbConn.FactoryIndex, dbConn.DBName, dbConn.DBIndex, dbConn.ConnectionString));
        }
        public int Update(DBConnection dbConn)
        {
            string sql = "update DBConnection set FactoryIndex={0},DBName='{1}',DBIndex={2},ConnectionString='{3}' where ConnectionID={4}";
            return db.ExecuteCommand(string.Format(sql, dbConn.FactoryIndex, dbConn.DBName, dbConn.DBIndex, dbConn.ConnectionString, dbConn.ConnectionID));
        }
        public int Delete(DBConnection dbConn)
        {
            string sql = "delete from DBConnection where ConnectionID={0}";
            return db.ExecuteCommand(string.Format(sql, dbConn.ConnectionID));
        }
    }
}
