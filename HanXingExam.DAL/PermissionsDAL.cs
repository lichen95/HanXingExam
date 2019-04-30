using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanXingExam.DAL
{
    using HanXingExam.IDAL;
    using HanXingExam.Entity;
    using SqlSugar;
    using HanXingExam.Common;

    /// <summary>
    /// ** 描述：权限数据访问类
    /// ** 创始时间：2018-11-02
    /// ** 修改时间：-
    /// ** 作者：zhq
    /// </summary>
    public class PermissionsDAL :IPermissions_DAL
    {
        private SqlSugarClient db = null;      
        public PermissionsDAL()
        {
            if (db == null)
                db = SqlSugarClientHelper.SqlDBConnection;
        }
        /// <summary>
        /// 权限添加
        /// </summary>
        /// <param name="t">权限实体</param>
        /// <returns></returns>
        public bool Add(Permissions t)
        {
            try
            {
                var sql = "insert into Permissions values(@PermissionName,@URL,@IsUse,@PId,@CreateDate)";
                SugarParameter[] parm ={
                new SugarParameter("@PermissionName",t.PermissionName),
                new SugarParameter("@URL",t.URL),
                new SugarParameter("@IsUse",t.IsUse),
                new SugarParameter("@PId",t.PId),
                new SugarParameter("@CreateDate",t.CreateDate),
            };
                var result = db.Ado.ExecuteCommand(sql, parm);
                return result > 0;

            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }
        /// <summary>
        /// 权限删除
        /// </summary>
        /// <param name="Ids">定义的ids值</param>
        /// <returns></returns>
        public bool Delete(string Ids)
        {
            try
            {
                var arr = Ids.Split(',');
                //string[] input = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                int[] output = Array.ConvertAll<string, int>(arr, delegate (string s) { return int.Parse(s); });
                var result = db.Deleteable<Permissions>().In(arr).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }

        }
        /// <summary>
        /// 获取权限信息
        /// </summary>
        /// <param name="permissionName">权限名称</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页几条</param>
        /// <returns>返回分页类</returns>
        public PageBox Query(string permissionName, int pageIndex = 1, int pageSize = 3)
        {
            try
            {
                //总页数
                var pageCount = 0;
                var list = db.Queryable<Permissions>();
                //根据权限名称查询
                if (!string.IsNullOrWhiteSpace(permissionName))
                    list = list.Where(m => m.PermissionName.Contains(permissionName));
                //分页
                var listUser = list.ToPageList(pageIndex, pageSize, ref pageCount);
                PageBox page = new PageBox();
                page.PageIndex = pageIndex;
                page.PageCount = pageCount;
                page.Data = listUser;
                return page;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 获取用户加载权限
        /// </summary>
        /// <returns>返回用户信息</returns>
        public List<Permissions> GetPermissionsById(int Id)
        {
            try
            {
                var sql = @"select p.* from Permissions p join Permission_Roles pr on p.PermissionId= pr.PermissionId
 join Roles r on pr.RoleId = r.RoleId join User_Roles ur on r.RoleId = ur.RoleId join Users u
     on u.UserId = ur.UserId where u.UserId =@UserId";
                var getPermissions = db.Ado.SqlQuery<Permissions>(sql, new { UserId = Id });
                return getPermissions;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }

        }
        /// <summary>
        /// 动态加载权限菜单
        /// </summary>
        /// <returns>返回用户信息</returns>
        public List<Permissions> GetPermissions(int Id)
        {
            try
            {
                var sql = " select * from Permissions where PId =@PId";
                var getPermissions = db.Ado.SqlQuery<Permissions>(sql, new { PId = Id });
                return getPermissions;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Permissions QueryById(int Id)
        {
            try
            {
                var getById = db.Queryable<Permissions>().InSingle(Id);
                return getById;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return null;
            }
        }
        /// <summary>
        /// 权限修改
        /// </summary>
        /// <param name="t">权限实体</param>
        /// <returns></returns>
        public bool Update(Permissions t)
        {
            try
            {
                var result = db.Updateable<Permissions>(t).ExecuteCommand();
                return result > 0;
            }
            catch (Exception ex)
            {
                ErrorLog.WriteLog(ex);
                return false;
            }
        }
    }
}
