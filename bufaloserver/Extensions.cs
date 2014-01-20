using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bufaloserver
{
    public static class Extensions
    {
        public static void Write(this BinaryWriter Writer, string value, int length)
        {
            Writer.Write(Encoding.ASCII.GetBytes(value));
            int RemainingBytes = length - value.Length;
            for (int i = 0; i < RemainingBytes; i++)
                Writer.Write((byte)0x00);
        }

        public static void Write(this BinaryWriter Writer, UInt32 value, bool bigendian = false)
        {
            byte[] Value = BitConverter.GetBytes(value);
            if (bigendian)
                Array.Reverse(Value);

            Writer.Write(Value);
        }

        public static UInt32 ReadUInt32(this BinaryReader Reader, bool bigendian = false)
        {
            byte[] Value = Reader.ReadBytes(4);
            if (bigendian)
                Array.Reverse(Value);
            return BitConverter.ToUInt32(Value, 0);
        }

        public static string ReadString(this BinaryReader Reader, int length)
        {
            byte[] Value = Reader.ReadBytes(length);

            return Encoding.ASCII.GetString(Value).Trim('\0');
        }
    }
}
