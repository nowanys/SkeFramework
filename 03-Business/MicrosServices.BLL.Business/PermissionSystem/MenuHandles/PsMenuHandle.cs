using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;

namespace MicrosServices.BLL.SHBusiness.PsMenuHandles
{
    public class PsMenuHandle : PsMenuHandleCommon, IPsMenuHandle
  {
        public PsMenuHandle(IRepository<PsMenu> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
