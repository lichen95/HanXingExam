using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using SqlSugar;
    using Entity;
    using System.Configuration;

    /// <summary>
    /// ** 描述：CRUD上下文 有bug
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：lc
    /// </summary>
    public class DbContext<T> where T : class, new()
    {
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "server=169.254.86.153;database=HanXingExamDb;uid=sa;pwd=1234;",
                DbType = DbType.SqlServer,
                InitKeyType = InitKeyType.SystemTable,//从特性读取主键和自增列信息
                IsAutoCloseConnection = true,//开启自动释放模式和EF原理一样我就不多解释了

            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql + "\r\n" +
                    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                Console.WriteLine();
            };

        }
        
        public SimpleClient<T> CurrentDb { get { return new SimpleClient<T>(Db); } }//用来处理T表的常用操作

        /// <summary>
        /// 单个添加
        /// </summary>
        /// <returns></returns>
        public virtual bool Insert(T obj)
        {
            return CurrentDb.Insert(obj);
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual bool InsertRange(T[] obj)
        {
            return CurrentDb.InsertRange(obj);
        }
        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual List<T> GetList()
        {
            return CurrentDb.GetList();
        }

        /// <summary>
        /// 根据主键删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool Delete(dynamic ids)
        {
            return CurrentDb.DeleteByIds(ids);
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="obj">实体</param>
        /// <returns></returns>
        public virtual bool Update(T obj)
        {
            return CurrentDb.Update(obj);
        }

    }
}
