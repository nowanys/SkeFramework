using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using SkeFramework.DataBase.Interfaces;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using System.Collections.Generic;
using MicrosServices.Helper.Core.VO;
using MicrosServices.Helper.Core.Form;
using System.Linq.Expressions;
using MicrosServices.BLL.Business;
using MicrosServices.Helper.Core.Common;
using MicrosServices.Helper.Core.Extends;
using MicrosServices.Entities.Constants;

namespace MicrosServices.BLL.SHBusiness.PsMenuRolesHandles
{
    public class PsMenuManagementHandle : PsMenuManagementHandleCommon, IPsMenuManagementHandle
  {
        public PsMenuManagementHandle(IRepository<PsMenuManagement> dataSerialer)
            : base(dataSerialer)
        {
        }


        /// <summary>
        /// 权限菜单授权
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ManagementMenusInsert(ManagementMenusForm model)
        {
            int result = 0;
            //删除原有权限
            DataHandleManager.Instance().PsMenuManagementHandle.DeleteManagementMenus(model.ManagementNo);
            PsMenuManagement managementRoles = null;
            if (model.MenuNos != null)
            {
                foreach (var nos in model.MenuNos)
                {
                    PsMenu menu = DataHandleManager.Instance().PsMenuHandle.GetMenuInfo(nos);
                    if (menu != null)
                    {
                        managementRoles = new PsMenuManagement()
                        {
                            MenuNo = nos,
                            ManagementNo = model.ManagementNo,
                            InputUser = model.InputUser,
                            InputTime = DateTime.Now,
                            UpdateTime = DateTime.Now
                        };
                        result += DataHandleManager.Instance().PsMenuManagementHandle.Insert(managementRoles);
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// 检查权限菜单是否存在
        /// </summary>
        /// <param name="ManagementNo"></param>
        /// <returns></returns>
        public bool CheckManagementMenusNoIsExist(long MenuNo, long ManagementNo)
        {
            if (ManagementNo != ConstData.DefaultNo)
            {
                Expression<Func<PsMenuManagement, bool>> where = (o => o.ManagementNo == ManagementNo && o.MenuNo == MenuNo);
                long count = this.Count(where);
                if (count == 0)
                {
                    throw new Exception(String.Format("菜单权限[{0}-{1}]已存在", MenuNo, ManagementNo));
                }
            }
            return false;
        }
        /// <summary>
        /// 获取权限菜单列表
        /// </summary>
        /// <param name="ManagementNo"></param>
        /// <returns></returns>
        public MenuAssignVo GetMenuAssign(long ManagementNo)
        {
            MenuAssignVo assignVo = new MenuAssignVo();
            List<PsMenuManagement> menuManagements  = this.GetManagementMenus(ManagementNo);
            assignVo.ManagementInfo = DataHandleManager.Instance().PsManagementHandle.GetManagementInfo(ManagementNo);
            List<OptionValue> optionValues = DataHandleManager.Instance().PsMenuHandle.GetMenusOptionValues(assignVo.ManagementInfo.PlatformNo);
            assignVo.optionValues = new List<CheckOptionValue>();
            foreach (var item in optionValues)
            {
                bool isCheck = menuManagements.Where(o => o.MenuNo == item.Value).FirstOrDefault() != null;
                assignVo.optionValues.Add(new CheckOptionValue()
                {
                    isCheck = isCheck,
                    Name = item.Name,
                    Value = item.Value
                });
            }
            return assignVo;
        }
        /// <summary>
        /// 获取权限菜单关系列表
        /// </summary>
        /// <param name="ManagementNo"></param>
        /// <returns></returns>
        public List<PsMenuManagement> GetManagementMenus(long ManagementNo)
        {
            Expression<Func<PsMenuManagement, bool>> where = (o => o.ManagementNo == ManagementNo);
            return this.GetList(where).ToList();
        }
    }
}
