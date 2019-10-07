using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using SkeFramework.DataBase.DataAccess.DataHandle.Common;

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public class UsersHandleCommon : DataTableHandle<Users>, IUsersHandleCommon
  {
        public UsersHandleCommon(IRepository<Users> dataSerialer)
            : base(dataSerialer, Users.TableName, false)
        {
        }
  }
}
