using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using SkeFramework.Core.SnowFlake;
using MicrosServices.Helper.DataUtil.Tree;

namespace MicrosServices.BLL.SHBusiness.PsOrganizationHandles
{
    public class PsOrganizationHandle : PsOrganizationHandleCommon, IPsOrganizationHandle
  {
        public PsOrganizationHandle(IRepository<PsOrganization> dataSerialer)
            : base(dataSerialer)
        {
        }
        /// <summary>
        /// 新增一个组织
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int OrganizationInsert(PsOrganization model)
        {
            PsOrganization ParentInfo = this.GetModelByKey(model.ParentNo.ToString());
            model.TreeLevelNo = TreeLevelUtil.GetTreeLevelNo<PsOrganization>(ParentInfo, model.ParentNo);
            model.OrgNo = AutoIDWorker.Example.GetAutoSequence();
            model.InputTime = DateTime.Now;
            model.Enabled = 1;
            return this.Insert(model);
        }
        /// <summary>
        /// 更新组织
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        public int OrganizationUpdate(PsOrganization management)
        {
            PsOrganization model = this.GetModelByKey(management.id.ToString());
            if (model != null)
            {
                PsOrganization ParentInfo = this.GetModelByKey(management.ParentNo.ToString());
                model.TreeLevelNo = TreeLevelUtil.GetTreeLevelNo<PsOrganization>(ParentInfo, management.ParentNo);
                model.UpdateTime = DateTime.Now;
                model.Name = management.Name;
                model.ParentNo = management.ParentNo;
                model.Description = management.Description;
                model.Category = management.Category;
                model.Enabled = management.Enabled;
                return this.Update(model);
            }
            return 0;
        }
    }
}
