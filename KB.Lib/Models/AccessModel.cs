using System;
using System.Collections.Generic;
using System.Text;

namespace KB.Models
{
    public class Factory
    {
        public int FactoryID
        {
            get;
            set;
        }
        public string FactoryName
        {
            get;
            set;
        }
        public int FactoryIndex
        {
            get;
            set;
        }
    }
    public class SystemParameter
    {
        public int ID
        {
            get;
            set;
        }
        public string ParameterName
        {
            get;
            set;
        }
        public string ParameterValue
        {
            get;
            set;
        }
    }
    public class DBConnection
    { 
        public int ConnectionID
        {
            get;
            set;
        }
        public int FactoryIndex
        {
            get;
            set;
        }
        public string DBName
        {
            get;
            set;
        }
        public int DBIndex
        {
            get;
            set;
        }
        public string ConnectionString
        {
            get;
            set;
        }
    }
}
