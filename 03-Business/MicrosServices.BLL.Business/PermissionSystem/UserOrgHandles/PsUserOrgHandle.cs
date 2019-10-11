using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsUserOrgHandles
{
    public class PsUserOrgHandle : PsUserOrgHandleCommon, IPsUserOrgHandle
  {
        public PsUserOrgHandle(IRepository<PsUserOrg> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
