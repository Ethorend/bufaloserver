using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace bufaloserver
{
    public class IWHandleIP
    {
        public void HandlePacket(Socket sock, EndPoint ep, int len, BinaryReader reader)
        {
            byte pType = reader.ReadByte();
            int pType2 = pType + 1;

            byte[] sendBuf = new byte[512];

            if (pType == 49)
            {
                MemoryStream stream = new MemoryStream(sendBuf);
                BinaryWriter writer = new BinaryWriter(stream);

                // unk packet and ipdetect
                writer.Write(0xffffffff);
                writer.Write(new byte[] { 0x69, 0x70, 0x64, 0x65, 0x74, 0x65, 0x63, 0x74 });

                if (pType2 == 50)
                {
                    // unk 00 00 00 and seqID
                    writer.Write(new byte[] { 0x00, 0x00, 0x00, 0x01 });

                    // unk packet
                    writer.Write(new byte[] { 0x00, 0x14, 0x1b });

                    // fake ip address and port
                    writer.Write(new byte[] { 0x33, 0xcd, 0x81 });
                    writer.Write(new byte[] { 0xd9, 0x20, 0x71 });

                    // blankness for the win
                    writer.Write(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x14, 0x00 });
                }
                else if (pType2 == 53)
                {
                    // unk 00 01 00 and seqID
                    writer.Write(new byte[] { 0x00, 0x01, 0x00, 0x02 });

                    // more unk packets
                    writer.Write(new byte[] { 0x00, 0x17, 0x1e });
                    writer.Write(new byte[] { 0x00, 0x78, 0x8a, 0x43, 0xf9, 0x4a, 0xc4 });
                    writer.Write(new byte[] { 0x23, 0xfc, 0x8a, 0x0d, 0x4b, 0x97 });
                    writer.Write(new byte[] { 0x7e, 0x23, 0xfb, 0x08, 0xec, 0x62, 0x10, 0x88 });
                    writer.Write(new byte[] { 0x98, 0xdf, 0x05, 0x16, 0xcc, 0xe5, 0x1b, 0x77 });

                    // TODO: finish this.
                }
                else
                {
                    Console.WriteLine("> Unknown packet in connect {0}.", pType2);
                }
            }
            else
            {
                Console.WriteLine("> Unknown packet {0}.", pType);
                return;
            }

            sock.SendTo(sendBuf, len, SocketFlags.None, ep);
        }
    }
}
