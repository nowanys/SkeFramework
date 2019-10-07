using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class ManagementRoles : IEntity
  {
            public const string TableName = "management_roles";
        [KeyAttribute(true)]
        [Description("ID")]
        public int id { get; set; }
        [Description("角色名称")]
        public string Name { get; set; }
        [Description("描述")]
        public string Description { get; set; }
        [Description("权限值")]
        public double ManagementValue { get; set; }
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
