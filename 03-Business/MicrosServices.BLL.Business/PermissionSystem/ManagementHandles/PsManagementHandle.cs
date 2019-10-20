using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using System.Linq.Expressions;
using MicrosServices.BLL.Business;
using SkeFramework.Core.SnowFlake;
using System.Collections.Generic;

namespace MicrosServices.BLL.SHBusiness.PsManagementHandles
{
    public class PsManagementHandle : PsManagementHandleCommon, IPsManagementHandle
    {
        public PsManagementHandle(IRepository<PsManagement> dataSerialer)
            : base(dataSerialer)
        {
        }

        /// <summary>
        /// 新增一个权限
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        public int ManagementInser(PsManagement management)
        {
            Expression<Func<PsManagement, bool>> where = (o => o.Name == management.Name);
            long count = this.Count(where);
            if (count > 0)
            {
                return -1;
            }
            management.ManagementNo = AutoIDWorker.Example.GetAutoID();
            management.InputTime = DateTime.Now;
            management.Enabled = 1;
            return this.Insert(management);
        }

        /// <summary>
        /// 新增一个权限
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        public int ManagementUpdate(PsManagement management)
        {
            PsManagement model = this.GetModelByKey(management.id.ToString());
            if (model != null)
            {
                model.UpdateTime = DateTime.Now;
                model.Name = management.Name;
                model.ParentNo = management.ParentNo;
                model.Description = management.Description;
                model.Value = management.Value;
                model.Sort = management.Sort;
                model.Enabled = management.Enabled;
                return this.Update(model);
            }
            return -1;
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="management"></param>
        /// <returns></returns>
        public int ManagementBeachDelete(List<long> ManagementNos)
        {
            return 0;
        }


        /// <summary>
        /// 检查名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool CheckManagementNameIsExist(string Name,long ManagementNo=-1)
        {
            Expression<Func<PsManagement, bool>> where = (o => o.Name == Name&&(o.ManagementNo==-1 || o.ManagementNo!=ManagementNo));
            long count = this.Count(where);
            if (count > 0)
            {
                throw new Exception(String.Format("名称[{0}]已存在", Name));
            }
            return false;
        }
        /// <summary>
        /// 检查编码是否存在
        /// </summary>
        /// <param name="ManagementNo"></param>
        /// <returns></returns>
        public bool CheckManagementNoIsExist(long ManagementNo)
        {
            if (ManagementNo != -1)
            {
                Expression<Func<PsManagement, bool>> where = (o => o.ManagementNo == ManagementNo);
                long count = this.Count(where);
                if (count == 0)
                {
                    throw new Exception(String.Format("权限编号[{0}]不存在", ManagementNo));
                }
            }
            return false;
        }
    }
}
