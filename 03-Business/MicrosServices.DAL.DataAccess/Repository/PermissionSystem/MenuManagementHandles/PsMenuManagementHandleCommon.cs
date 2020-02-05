using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using SkeFramework.DataBase.Common.DataFactory;
using SkeFramework.DataBase.Common.DataCommon;
using SkeFramework.DataBase.Interfaces;
using SkeFramework.DataBase.DataAccess.DataHandle.Common;
using MicrosServices.Entities.Common;
using System.Data.Common;

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public class PsMenuManagementHandleCommon : DataTableHandle<PsMenuManagement>, IPsMenuManagementHandleCommon
  {
        public PsMenuManagementHandleCommon(IRepository<PsMenuManagement> dataSerialer)
            : base(dataSerialer, PsMenuManagement.TableName, false)
        {
        }
       
        /// <summary>
        /// 删除菜单权限列表
        /// </summary>
        /// <param name="managementNo"></param>
        public bool DeleteManagementMenus(long ManagementNo, int Type)
        {
            string sSQL = String.Format(@"DELETE FROM {0} WHERE ManagementNo=@ManagementNo AND Type=@Type", _mTableName);
            List<DbParameter> ParaList = new List<DbParameter>();
            ParaList.Add(DbFactory.Instance().CreateDataParameter("@ManagementNo", ManagementNo));
            ParaList.Add(DbFactory.Instance().CreateDataParameter("@Type", Type));
            return RepositoryHelper.ExecuteNonQuery(CommandType.Text, sSQL, ParaList.ToArray()) > 0 ? true : false;
        }
        /// <summary>
        /// 删除菜单权限列表
        /// </summary>
        /// <param name="managementNo"></param>
        public bool DeleteMenuManagements(long MenuNo,int Type)
        {
            string sSQL = String.Format(@"DELETE FROM {0} WHERE MenuNo=@MenuNo AND Type=@Type", _mTableName);
            List<DbParameter> ParaList = new List<DbParameter>();
            ParaList.Add( DbFactory.Instance().CreateDataParameter("@MenuNo", MenuNo));
            ParaList.Add(DbFactory.Instance().CreateDataParameter("@Type", Type));
            return RepositoryHelper.ExecuteNonQuery(CommandType.Text, sSQL, ParaList.ToArray()) > 0 ? true : false;
        }
    }
}
