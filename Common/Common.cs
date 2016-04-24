using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Vars
    {
        // CardClient/Assets/Scripts 안의 값과 동일해야 한다.
        public static System.Guid g_ProtocolVersion = new System.Guid("{0x875d452,0xc512,0x4848,{0x98,0xd1,0xd4,0xf0,0xfa,0x86,0x69,0x11}}");
        public static int g_serverPort = 15001;

        static Vars()
        {

        }
    }
}
