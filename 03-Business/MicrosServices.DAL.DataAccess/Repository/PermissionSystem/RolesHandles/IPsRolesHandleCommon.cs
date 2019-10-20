using System;
using System.Data;
using System.Collections;
using System.Linq;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.Entities.Common;

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public interface IPsRolesHandleCommon : IDataTableHandle<PsRoles>
    {
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="Nos"></param>
        /// <returns></returns>
        int BatchDelete(long[] Nos);

    }
}
