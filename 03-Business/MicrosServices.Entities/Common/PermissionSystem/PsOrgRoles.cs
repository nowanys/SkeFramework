using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class PsOrgRoles : IEntity
    {
        public const string TableName = "ps_org_roles";
        [KeyAttribute(true)]
        [Description("ID")]
        public Int64 id { get; set; }
        [Description("角色编号")]
        public Int64 RolesNo { get; set; }
        [Description("组织编号")]
        public Int64 OrgNo { get; set; }
        [Description("权限值")]
        public Int64 ManagementValue { get; set; }
        [Description("操作员")]
        public string InputUser { get; set; }
        [Description("操作时间")]
        public DateTime InputTime { get; set; }
        [Description("更新时间")]
        public DateTime UpdateTime { get; set; }
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
