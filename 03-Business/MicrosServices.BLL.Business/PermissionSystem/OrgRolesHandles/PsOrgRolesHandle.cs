using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsOrgRolesHandles
{
    public class PsOrgRolesHandle : PsOrgRolesHandleCommon, IPsOrgRolesHandle
  {
        public PsOrgRolesHandle(IRepository<PsOrgRoles> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
