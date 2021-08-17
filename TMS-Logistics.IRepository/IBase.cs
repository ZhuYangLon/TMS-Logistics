using System;
using System.Collections.Generic;
using TMS_Logistics.Model;
namespace TMS_Logistics.IRepository
{
    public interface IBase<T> where T:class,new()
    {
        //显示
        List<T> GetList(string sql,object name);
        //增删改
        int Efec(string sql,object id);
        //反填
        T Backfill(string sql, object id);


    }
}
