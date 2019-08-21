﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SkeFramework.NetSocket.Channels;
using SkeFramework.NetSocket.Net;
using SkeFramework.NetSocket.Topology;

namespace SkeFramework.NetSocket.Reactor
{
    /// <summary>
    /// 网络连接接口
    /// </summary>
    //[Obsolete("Use IChannel instead")]
    public interface IReactor : IDisposable
    {
        #region 事件
        /// <summary>
        /// 连接事件
        /// </summary>
        event ConnectionEstablishedCallback OnConnection;
        /// <summary>
        /// 接受事件
        /// </summary>
        event ReceivedDataCallback OnReceive;
        /// <summary>
        /// 连接终止事件
        /// </summary>
        event ConnectionTerminatedCallback OnDisconnection;
        /// <summary>
        /// 连接异常事件
        /// </summary>
        event ExceptionCallback OnError;
        #endregion

        //IMessageEncoder Encoder { get; }
        //IMessageDecoder Decoder { get; }
        //IByteBufAllocator Allocator { get; }

        /// <summary>
        /// 连接适配器
        /// </summary>
        IConnection ConnectionAdapter { get; }

        //NetworkEventLoop EventLoop { get; }

        /// <summary>
        /// The backlog of pending connections allowed for the underlying transport
        /// </summary>
        int Backlog { get; set; }
        /// <summary>
        /// 连接是否活跃
        /// </summary>
        bool IsActive { get; }
        /// <summary>
        /// 是否释放
        /// </summary>
        bool WasDisposed { get; }
        /// <summary>
        /// 本地连接
        /// </summary>
        IPEndPoint LocalEndpoint { get; }
        /// <summary>
        /// 连接类型
        /// </summary>
        TransportType Transport { get; }
        /// <summary>
        /// 连接参数配置
        /// </summary>
        /// <param name="config"></param>
        void Configure(IConnectionConfig config);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data"></param>
        void Send(NetworkData data);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="destination"></param>
        void Send(byte[] buffer, int index, int length, INode destination);
        /// <summary>
        /// 开始
        /// </summary>
        void Start();
        /// <summary>
        /// 停止
        /// </summary>
        void Stop();
        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing"></param>
        void Dispose(bool disposing);
    }
}
