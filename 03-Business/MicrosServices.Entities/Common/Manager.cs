using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class Manager : IEntity
  {
            public const string TableName = "manager";
        [KeyAttribute(true)]
        [Description("主键")]
        public int id { get; set; }
        [Description("账号")]
        public string UserNo { get; set; }
        [Description("用户名")]
        public string UserName { get; set; }
        [Description("密码")]
        public string Password { get; set; }
        [Description("手机号码")]
        public string Phone { get; set; }
        [Description("邮箱")]
        public string Email { get; set; }
        [Description("启用状态")]
        public byte Enabled { get; set; }
        [Description("上次登录时间")]
        public DateTime FailedLoginTime { get; set; }
        [Description("连续登录失败次数")]
        public int FailedLoginCount { get; set; }
        [Description("密钥")]
        public string APPKey { get; set; }
        [Description("角色ID")]
        public int RolesID { get; set; }
       public string GetTableName()
       {
           return TableName;
       }
       public string GetKey()
       {
           return "id";
       }
  }
}
