﻿using SkeFramework.Core.Enums.ExtendAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosServices.Helper.Core.Constants
{
   /// <summary>
   /// 权限类型枚举
   /// </summary>
    public enum ManagementType
    {
        [EnumAttribute(1, "操作权限")] OPERATE_TYPE=1,
        [EnumAttribute(2, "菜单权限")] MENU_TYPE=2,
    }
}