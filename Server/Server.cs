using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettention.Proud;


namespace Server
{
    public class Server
    {
        public bool m_runLoop;

        private NetServer m_netServer = new NetServer();

        private Nettention.Proud.ThreadPool netWorkerThreadPool = new Nettention.Proud.ThreadPool(8);
        private Nettention.Proud.ThreadPool userWorkerThreadPool = new Nettention.Proud.ThreadPool(8);

        // RMI proxy for server-to-client messaging

        internal S2C.Proxy m_S2CProxy = new S2C.Proxy();
        internal C2S.Stub m_C2SStub = new C2S.Stub();

        public Server()
        {
            m_runLoop = true;
            m_netServer.AttachStub(m_C2SStub);
            m_netServer.AttachProxy(m_S2CProxy);

            // 클라이언트의 접속 요청에 대한 콜백 함수를 지정하는 델리게이트
            m_netServer.ConnectionRequestHandler = (AddrPort clientAddr, ByteArray userDataFromClient, ByteArray reply) =>
            {
                reply = new ByteArray();
                reply.Clear();
                return true;
            };
            m_netServer.ClientHackSuspectedHandler = (HostID clientID, HackType hackType) =>
            {

            };
            m_netServer.ClientJoinHandler = (NetClientInfo clientInfo) =>
            {
                Console.WriteLine("OnClientJoin: {0}", clientInfo.hostID);
            };
            m_netServer.ClientLeaveHandler = (NetClientInfo clientInfo, ErrorInfo errorinfo, ByteArray comment) =>
            {
                Console.WriteLine("OnClientLeave: {0}", clientInfo.hostID);
            };
            m_netServer.ErrorHandler = (ErrorInfo errorInfo) =>
            {
                Console.WriteLine("OnError! {0}", errorInfo.ToString());
            };
            m_netServer.WarningHandler = (ErrorInfo errorInfo) =>
            {
                Console.WriteLine("OnWarning! {0}", errorInfo.ToString());
            };
            m_netServer.ExceptionHandler = (Exception e) =>
            {
                Console.WriteLine("OnWarning! {0}", e.Message.ToString());
            };
            m_netServer.InformationHandler = (ErrorInfo errorInfo) =>
            {
                Console.WriteLine("OnInformation! {0}", errorInfo.ToString());
            };
            m_netServer.NoRmiProcessedHandler = (RmiID rmiID) =>
            {
                Console.WriteLine("OnNoRmiProcessed! {0}", rmiID);
            };

            m_netServer.P2PGroupJoinMemberAckCompleteHandler = (HostID groupHostID, HostID memberHostID, ErrorType result) =>
            {

            };
            m_netServer.TickHandler = (object context) =>
            {

            };
            m_netServer.UserWorkerThreadBeginHandler = () =>
            {

            };
            m_netServer.UserWorkerThreadEndHandler = () =>
            {

            };
        }

        public void Start()
        {
            StartServerParameter sp = new StartServerParameter();
            sp.protocolVersion = new Nettention.Proud.Guid(Common.Vars.g_ProtocolVersion);
            sp.tcpPorts = new IntArray();
            sp.tcpPorts.Add(Common.Vars.g_serverPort);
            sp.serverAddrAtClient = "112.166.83.47";
            sp.localNicAddr = "112.166.83.47";
            sp.SetExternalNetWorkerThreadPool(netWorkerThreadPool);
            sp.SetExternalUserWorkerThreadPool(userWorkerThreadPool);

            m_netServer.Start(sp);
        }

        public void Dispose()
        {
            m_netServer.Dispose();
        }
    }
}
