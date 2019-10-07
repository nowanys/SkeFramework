using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class Organization : IEntity
  {
            public const string TableName = "organization";
        [KeyAttribute(true)]
        [Description("ID")]
        public int id { get; set; }
        [Description("组织编号")]
        public string OrgNo { get; set; }
        [Description("组织名称")]
        public int Name { get; set; }
        [Description("地址")]
        public string Address { get; set; }
        [Description("联系电话")]
        public string Phone { get; set; }
        [Description("父节点")]
        public string ParentId { get; set; }
        [Description("分类【集团、公司、部门、工作组】")]
        public double Category { get; set; }
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
