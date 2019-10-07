using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using SkeFramework.DataBase.Interfaces;

namespace MicrosServices.BLL.SHBusiness.UsersHandles
{
    public class UsersHandle : UsersHandleCommon, IUsersHandle
  {
        public UsersHandle(IRepository<Users> dataSerialer)
            : base(dataSerialer)
        {
        }
  }
}
