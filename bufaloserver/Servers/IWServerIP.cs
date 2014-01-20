﻿using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace bufaloserver
{
    public class IWServerIP
    {
        private short m_IWPort;
        private Socket m_IWSocket;
        private IPEndPoint m_IWEndPoint;
        private byte[] m_IWReceiveBuf;

        public IWServerIP(short port)
        {
            m_IWPort = port;
            m_IWSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            m_IWEndPoint = new IPEndPoint(IPAddress.Any, m_IWPort);
            m_IWReceiveBuf = new byte[512];
        }

        public void Start()
        {
            Console.WriteLine("> Starting IWServerIP on port {0}...", m_IWPort);

            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);

            m_IWSocket.Bind(m_IWEndPoint);

            int len = m_IWSocket.ReceiveFrom(m_IWReceiveBuf, ref remote);

            m_IWReceiveBuf = Encoding.Default.GetBytes(remote.ToString());
            MemoryStream stream = new MemoryStream(m_IWReceiveBuf);
            BinaryReader reader = new BinaryReader(stream);

            IWHandleIP handleIP = new IWHandleIP();

            byte pType = reader.ReadByte();

            switch (pType)
            {
                case 49:
                    stream.Position = 0;
                    handleIP.HandlePacket(m_IWSocket, remote, len, reader);
                    break;

                default:
                    Console.WriteLine("Got unk packet: {0}", pType);
                    break;
            }            
        }
    }
}
