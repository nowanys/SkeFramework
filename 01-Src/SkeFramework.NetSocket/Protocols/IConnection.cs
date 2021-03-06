﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SkeFramework.NetSocket.Buffers;
using SkeFramework.NetSocket.Buffers.Allocators;
using SkeFramework.NetSocket.Protocols.Configs;
using SkeFramework.NetSocket.Protocols.Constants;
using SkeFramework.NetSocket.Topology;

namespace SkeFramework.NetSocket.Protocols
{
    /// <summary>
    /// 用于处理接收数据的委托
    /// </summary>
    /// <param name="incomingData">a <see cref="NetworkData"/> instance that contains information that's arrived over the network</param>
    public delegate void ReceivedDataCallback(NetworkData incomingData, IConnection responseChannel);

    public interface IConnection : IDisposable
    {
        event ReceivedDataCallback Receive;

        /// <summary>
        /// 消息编码
        /// </summary>
        IMessageEncoder Encoder { get; }
        /// <summary>
        /// 消息解码
        /// </summary>
        IMessageDecoder Decoder { get; }
        /// <summary>
        /// 用于为网络I/O分配可重用缓冲区
        /// </summary>
        IByteBufAllocator Allocator { get; }
        /// <summary>
        /// 协议创建时间
        /// </summary>
        DateTime Created { get; }
        /// <summary>
        /// 远程连接
        /// </summary>
        INode RemoteHost { get; }
        /// <summary>
        /// 当前连接
        /// </summary>
        INode Local { get; }
        /// <summary>
        /// 超时时间
        /// </summary>
        TimeSpan Timeout { get; }
        /// <summary>
        /// 是否释放
        /// </summary>
        bool WasDisposed { get; }
        /// <summary>
        /// 是否正在接受
        /// </summary>
        bool Receiving { get;  set; }
        /// <summary>
        /// 是否打开
        /// </summary>
        /// <returns></returns>
        bool IsOpen();
        /// <summary>
        /// 尚未发送到预期目的地的消息
        /// </summary>
        int MessagesInSendQueue { get; }
        /// <summary>
        /// 协议是否过期
        /// </summary>
        bool Dead { get; set; }
        /// <summary>
        /// 协议控制码
        /// </summary>
        string ControlCode { get; set; }
        #region Method
        /// <summary>
        /// 选项配置此传输
        /// </summary>
        /// <param name="config"></param>
        void Configure(IConnectionConfig config);
        /// <summary>
        /// 开启
        /// </summary>
        void Open();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
        /// <summary>
        /// 发送方法
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="index"></param>
        /// <param name="length"></param>
        /// <param name="destination"></param>
        void Send(byte[] buffer, int index, int length, INode destination);
        /// <summary>
        /// 开始接收此连接上的数据
        /// Assumes that <see cref="Receive"/> has already been set.
        /// </summary>
        void BeginReceive();
        /// <summary>
        /// 开始接收此连接上的数据
        /// </summary>
        /// <param name="callback">A callback for when data is received</param>
        void BeginReceive(ReceivedDataCallback callback);
        /// <summary>
        /// 停止接收消息，但保持连接打开
        /// </summary>
        void StopReceive();
        #endregion

    }
}
