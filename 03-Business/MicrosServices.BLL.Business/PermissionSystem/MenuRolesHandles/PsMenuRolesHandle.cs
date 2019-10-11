using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsMenuRolesHandles
{
    public class PsMenuRolesHandle : PsMenuRolesHandleCommon, IPsMenuRolesHandle
  {
        public PsMenuRolesHandle(IRepository<PsMenuRoles> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
