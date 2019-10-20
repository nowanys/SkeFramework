using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using System.Linq.Expressions;
using SkeFramework.Core.SnowFlake;

namespace MicrosServices.BLL.SHBusiness.PsRolesHandles
{
    public class PsRolesHandle : PsRolesHandleCommon, IPsRolesHandle
  {
        public PsRolesHandle(IRepository<PsRoles> dataSerialer)
            : base(dataSerialer)
        {
        }

      

        public int RolesInsert(PsRoles model)
        {
            model.RolesNo = AutoIDWorker.Example.GetAutoID();
            model.InputTime = DateTime.Now;
            model.Enabled = 1;
            return this.Insert(model);
        }

        public int RolesUpdate(PsRoles management)
        {
            PsRoles model = this.GetModelByKey(management.id.ToString());
            if (model != null)
            {
                model.UpdateTime = DateTime.Now;
                model.Name = management.Name;
                model.ParentNo = management.ParentNo;
                model.Description = management.Description;
                model.ManagementValue = management.ManagementValue ;
                model.Enabled = management.Enabled;
                return this.Update(model);
            }
            return -1;
        }
    }
}
