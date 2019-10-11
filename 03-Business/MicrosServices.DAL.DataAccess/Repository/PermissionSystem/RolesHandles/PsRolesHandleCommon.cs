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

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public class PsRolesHandleCommon : DataTableHandle<PsRoles>, IPsRolesHandleCommon
  {
        public PsRolesHandleCommon(IRepository<PsRoles> dataSerialer)
            : base(dataSerialer, PsRoles.TableName, false)
        {
        }
  }
}
