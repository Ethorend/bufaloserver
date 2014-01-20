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
    public class IWHandleLog
    {
        /*
         * PREVIEW OF WHAT THE CLIENT SHOULD SEND:
         * 
         * ..$.......username.IW4 MP 1.0 build 182 latest Tue Feb 02 2010 03:46:27PM win-x86
         * ..........................h...3 q q...........................{....A..$.......
         * username.IW4 MP 1.0 build 182 latest Tue Feb 02 2010 03:46:27PM win-x86............
         * 5..HELLO: LSPXUID 110000100000124 - GT "username" - MID 0 - HD "yes" - WS "yes" - 
         * BTN "buttons_default" - STK "thumbstick_default"...$.......username.IW4 MP 1.0 build 182 
         * latest Tue Feb 02 2010 03:46:27PM win-x86..........................h...3 q q............
         * ...............{....A..$.......username.IW4 MP 1.0 build 182 latest Tue Feb 02 2010 
         * 03:46:27PM win-x86............5..HELLO: LSPXUID 110000100000124 - GT "username" - MID 0
         * - HD "yes" - WS "yes" - BTN "buttons_default" - STK "thumbstick_default"...$.......
         * username.IW4 MP 1.0 build 182 latest Tue Feb 02 2010 03:46:27PM win-x86..................
         * ........h...3 q q...........................{....A..$.......username.IW4 MP 1.0 build 182 
         * latest Tue Feb 02 2010 03:46:27PM win-x86............5..HELLO: LSPXUID 110000100000124 - GT 
         * "username" - MID 0 - HD "yes" - WS "yes" - BTN "buttons_default" - STK "thumbstick_default".
         */

        public class PlayerInfo
        {
            public string Username;
        }

        public void HandlePacket(Socket sock, EndPoint ep, int len, BinaryReader reader)
        {
            // TODO: implement log server.
        }
    }
}
