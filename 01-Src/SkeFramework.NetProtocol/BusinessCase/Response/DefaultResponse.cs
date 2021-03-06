﻿using SkeFramework.NetSerialPort.Net.Reactor;
using SkeFramework.NetSerialPort.Protocols.Configs;
using SkeFramework.NetSerialPort.Protocols.Connections;
using SkeFramework.NetSerialPort.Protocols.Constants;
using SkeFramework.NetSerialPort.Protocols.Requests;
using SkeFramework.NetSerialPort.Protocols.Response;
using SkeFramework.NetSerialPort.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ULCloudLockTool.BLL.SHProtocol.Constants;
using ULCloudLockTool.BLL.SHProtocol.DataFrame.Interfaces;
using ULCloudLockTool.BLL.SHProtocol.DataFrame.Services;

namespace ULCloudLockTool.BLL.SHProtocol.BusinessCase.Response
{
    /// <summary>
    /// 默认响应
    /// </summary>
    public class DefaultResponse : RefactorProxyResponseChannel
    {
        public DefaultResponse(ReactorBase reactor)
        : this(reactor, null)
        {
            Receive += ProtocolProxyAgent.Instance().DataPointListener_Receive;
        }

        public DefaultResponse(ReactorBase reactor, RefactorRequestChannel request)
            : base(reactor, request)
        {
        }

        public override void Configure(IConnectionConfig config)
        {
            base.Configure(config);
        }


        public override void OnReceive(NetworkData data)
        {
            base.OnReceive(data);

        }

    }
}
