using System.Data;
using Microsoft.EntityFrameworkCore;
using MinimalAPIBySelf;
namespace MinimalAPIBySelf.Db;

public class EFCoreHelper
{
    //public static readonly DbContext Db = new DbContext(new ConnectionConfig()
    //{
    //    ConnectionString = AppConfig.Settings?.DbConnectionStrings,//连接符字串
    //    DbType = DbType.,
    //    IsAutoCloseConnection = true,
    //}, db =>
    //{
    //    ExternalServicesSetting(db);
    //    db.Aop.OnLogExecuting = (sql, pars) =>
    //    {
    //        Console.WriteLine(sql);
    //    };
    //});
    //public static readonly SqlSugarScope Db = new SqlSugarScope(new ConnectionConfig()
    //{
    //    ConnectionString = AppConfig.Settings.DbConnectionStrings,//连接符字串
    //    DbType = DbType.MySql,
    //    IsAutoCloseConnection = true,
    //}, db =>
    //{
    //    ExternalServicesSetting(db);
    //    db.Aop.OnLogExecuting = (sql, pars) =>
    //    {
    //        Console.WriteLine(sql);
    //    };
    //});

    /// <summary>
    /// 拓展配置
    /// </summary>
    /// <param name="db"></param>
    /// <param name="config"></param>
    //private static void ExternalServicesSetting(SqlSugarClient db) {
    //    var cache = ServiceLocator.Instance.GetService<SqlSugarMemoryCacheService>();
    //    db.CurrentConnectionConfig.ConfigureExternalServices = new ConfigureExternalServices
    //    {
    //        DataInfoCacheService = cache,
    //        EntityService = (c, p) =>
    //        {
    //            if (p.IsPrimarykey == false && new NullabilityInfoContext()
    //                    .Create(c).WriteState is NullabilityState.Nullable)
    //            {
    //                p.IsNullable = true;
    //            }
    //        }
    //    };
    //}
}