﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ULCloudLockTool.BLL.SHProtocol.Constants;
using ULCloudLockTool.BLL.SHProtocol.DataHandle.HandleBase;

namespace ULCloudLockTool.BLL.SHProtocol.DataHandle.ATHandleBase
{
    public class ATDataHandle : DataHandleBase, IATDataHandle
    {
        /// <summary>
        /// 请求发送扫描指令
        /// </summary>
        /// <returns></returns>
        public void RequestATScan()
        {
            string strAT = "AT+INQ=1\r\n";
            base.RequestReactorFunction(ProtocolConst.ATScanDevice, strAT);
        }
        public virtual void RequestATSetRemoteAddress(string mac)
        {
          
        }
    }
}