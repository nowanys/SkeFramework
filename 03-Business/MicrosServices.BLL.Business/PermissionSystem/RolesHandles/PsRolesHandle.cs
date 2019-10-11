using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsRolesHandles
{
    public class PsRolesHandle : PsRolesHandleCommon, IPsRolesHandle
  {
        public PsRolesHandle(IRepository<PsRoles> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
