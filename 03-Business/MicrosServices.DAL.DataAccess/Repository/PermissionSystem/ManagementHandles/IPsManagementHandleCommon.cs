using System;
using System.Data;
using System.Collections;
using System.Linq;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using System.Collections.Generic;
using MicrosServices.Helper.Core.Common;
using MicrosServices.Entities.Constants;

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public interface IPsManagementHandleCommon : IDataTableHandle<PsManagement>
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ManagementNos"></param>
        /// <returns></returns>
        int BatchDelete(long[] ManagementNos);
        /// <summary>
        /// 获取键值对
        /// </summary>
        /// <returns></returns>
        List<OptionValue> GetOptionValues(long PlatformNo= ConstData.DefaultNo, long ManagementType = ConstData.DefaultNo);
        /// <summary>
        /// 获取角色菜单列表
        /// </summary>
        /// <param name="RolesNos"></param>
        /// <returns></returns>
        List<PsManagement> GetRoleManagementList(List<long> RolesNos);
    }
}
