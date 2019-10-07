using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class UsersSetting : IEntity
  {
            public const string TableName = "users_setting";
        [KeyAttribute(true)]
        [Description("ID")]
        public int id { get; set; }
        [Description("描述")]
        public string UserNo { get; set; }
        [Description("用户ID")]
        public string AppId { get; set; }
        [Description("用户密钥")]
        public string AppSecret { get; set; }
        [Description("权限角色ID")]
        public int ManagementId { get; set; }
        [Description("权限值")]
        public double ManagementValue { get; set; }
        [Description("用户所属组织")]
        public string OrgNo { get; set; }
        [Description("启用状态")]
        public byte Enabled { get; set; }
        [Description("操作员")]
        public string InputUser { get; set; }
        [Description("操作时间")]
        public DateTime InputTime { get; set; }
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
