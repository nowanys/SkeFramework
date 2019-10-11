using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsManagementHandles
{
    public class PsManagementHandle : PsManagementHandleCommon, IPsManagementHandle
  {
        public PsManagementHandle(IRepository<PsManagement> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
