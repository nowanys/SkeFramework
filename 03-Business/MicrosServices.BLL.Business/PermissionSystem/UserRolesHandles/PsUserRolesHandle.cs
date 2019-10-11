using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsUserRolesHandles
{
    public class PsUserRolesHandle : PsUserRolesHandleCommon, IPsUserRolesHandle
  {
        public PsUserRolesHandle(IRepository<PsUserRoles> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
