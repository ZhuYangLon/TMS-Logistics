using System;
using System.Collections.Generic;
using TMS_Logistics.IRepository;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using TMS_Logistics.Common;
using TMS_Logistics.Model;
using System.Linq;

namespace TMS_Logistics.Repository
{
    public class Base<T> : IBase<T> where T:class,new()
    {
        IDbConnection conn = new SqlConnection(ConnString.connstring);
        //反填
        public T Backfill(string sql, object id=null)
        {
            return conn.Query<T>(sql, id).SingleOrDefault();
        }

        //增删改
        public int Efec(string sql, object id=null)
        {
            return conn.Execute(sql, id);
        }
        //显示查询
        public List<T> GetList(string sql, object name=null)
        {
            return conn.Query<T>(sql, name).ToList();
        }
        
    }
}
