using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using SkeFramework.DataBase.Common.DataFactory;
using SkeFramework.DataBase.Common.DataCommon;
using SkeFramework.DataBase.Interfaces;
using SkeFramework.DataBase.DataAccess.DataHandle.Common;
using MicrosServices.Entities.Common;
using MicrosServices.Helper.Core.Common;
using Newtonsoft.Json;

namespace MicrosServices.DAL.DataAccess.DataHandle.Repositorys
{
    public class PsMenuHandleCommon : DataTableHandle<PsMenu>, IPsMenuHandleCommon
    {
        public PsMenuHandleCommon(IRepository<PsMenu> dataSerialer)
            : base(dataSerialer, PsMenu.TableName, false)
        {
        }
        /// <summary>
        /// 获取键值对
        /// </summary>
        /// <returns></returns>
        public List<OptionValue> GetOptionValues()
        {
            string sSQL =String.Format( "SELECT MenuNo as Value,Name  FROM {0}; ",_mTableName);
            DataTable dataTable = RepositoryHelper.GetDataTable(CommandType.Text, sSQL);
            if (dataTable != null || dataTable.Rows.Count > 0)
            {
                return JsonConvert.DeserializeObject<List<OptionValue>>(JsonConvert.SerializeObject(dataTable));
            }
            else
            {
                return new List<OptionValue>();
            }
        }

    }
}
