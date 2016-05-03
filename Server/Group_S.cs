using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettention.Proud;

namespace Server
{
    public class Group_S
    {
        public Group_S()
        {
            m_nextNewID = 1;
            m_p2pGroupID = HostID.HostID_None;
        }
        public ConcurrentDictionary<HostID, RemoteClient_S> m_players = new ConcurrentDictionary<HostID, RemoteClient_S>();
        public String m_name;
        public int m_nextNewID;
        public HostID m_p2pGroupID;
    }
    
}
