using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using MicrosServices.Entities.Common;
using System.Collections.Generic;

namespace MicrosServices.BLL.SHBusiness.PsManagementHandles
{
    public interface IPsManagementHandle : IPsManagementHandleCommon
    {
        /// <summary>
        /// 新增一个权限
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        int ManagementInser(PsManagement management);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        int ManagementBeachDelete(List<long> ManagementNos);
    }
}
