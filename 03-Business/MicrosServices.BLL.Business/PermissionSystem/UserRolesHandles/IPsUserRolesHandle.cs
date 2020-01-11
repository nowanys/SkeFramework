using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using MicrosServices.Helper.Core.VO;

namespace MicrosServices.BLL.SHBusiness.PsUserRolesHandles
{
    public interface IPsUserRolesHandle : IPsUserRolesHandleCommon
    {
        /// <summary>
        /// 获取用户角色信息
        /// </summary>
        /// <param name="usersNo"></param>
        /// <returns></returns>
        RolesAssignVo GetRolesAssign(long UsersNo);
    }
}
