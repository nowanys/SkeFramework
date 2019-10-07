using System;
using System.Data;
using System.Collections;
using System.ComponentModel;
using SkeFramework.DataBase.Common.AttributeExtend;

namespace MicrosServices.Entities.Common
{
    public class Management : IEntity
  {
            public const string TableName = "management";
        [KeyAttribute(true)]
        [Description("ID")]
        public int id { get; set; }
        [Description("名称")]
        public string Name { get; set; }
        [Description("权限值")]
        public double Value { get; set; }
        [Description("父节点")]
        public int ParentId { get; set; }
        [Description("跳转地址")]
        public string url { get; set; }
        [Description("图标")]
        public string icon { get; set; }
        [Description("排序")]
        public int Sort { get; set; }
        [Description("")]
        public int Enabled { get; set; }
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
