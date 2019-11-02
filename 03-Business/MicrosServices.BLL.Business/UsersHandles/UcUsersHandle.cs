using System;
using System.Data;
using System.Linq;
using System.Collections;
using MicrosServices.Entities.Common;
using MicrosServices.DAL.DataAccess.DataHandle.Repositorys;
using SkeFramework.DataBase.Interfaces;
using System.Linq.Expressions;
using MicrosServices.Helper.Core.Constants;

namespace MicrosServices.BLL.SHBusiness.UsersHandles
{
    public class UcUsersHandle : UcUsersHandleCommon, IUcUsersHandle
    {
        public UcUsersHandle(IRepository<UcUsers> dataSerialer)
            : base(dataSerialer)
        {
        }


        /// <summary>
        /// 登陆业务
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="Md5Pas">密码</param>
        /// <param name="LoginerInfo">登陆者信息</param>
        /// <param name="platform">平台code</param>
        /// <param name="info"></param>
        /// <returns></returns>
        public LoginResultType Login(string UserName, string Md5Pas, string LoginerInfo, string platform, ref UcUsers info)
        {
            if (UserName == "" || Md5Pas == "" || UserName == null || Md5Pas == null)
            {
                return LoginResultType.ERROR_PARA; //账号或者密码为空
            }
            Expression<Func<UcUsers, bool>> la = (n => n.Phone == UserName || n.Email == UserName || n.NickName == UserName);
            info = this.Get(la);
            if (info == null || string.IsNullOrEmpty(info.UserNo))
            {
                return LoginResultType.ERROR_USER_NOT_EXIST;//登录账号不存在
            }
            if (info.Enabled==0)
            {
                return LoginResultType.ERROR_USER_INACTIVE;//账号停用
            }
            if (info.FailedLoginCount >= 3)
            {
                return LoginResultType.ERROR_PASSWORD_TOO_MUCH;//密码输入错误次数超过三次
            }
            string UserNo = info.UserNo;
            if (Md5Pas != info.Password)
            {
                this.UpdateFailLogin(UserNo, false, LoginerInfo);//更新错误登录次数
                return LoginResultType.ERROR_PASSWORD;//密码错误
            }
            this.UpdateFailLogin(UserNo, true, LoginerInfo);//清零错误登录次数
            return LoginResultType.SUCCESS_LOGIN;
        }
    }
}
