﻿




// Generated by PIDL compiler.
// Do not modify this file, but modify the source .pidl file.

using System;
using System.Net;

namespace S2C
{
	internal class Proxy:Nettention.Proud.RmiProxy
	{
public bool ReplyLogon(Nettention.Proud.HostID remote,Nettention.Proud.RmiContext rmiContext, int groupID, int result, String comment)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
		__msg.SimplePacketMode = core.IsSimplePacketMode();
		Nettention.Proud.RmiID __msgid= Common.ReplyLogon;
		__msg.Write(__msgid);
		CardClient.Marshaler.Write(__msg, groupID);
		CardClient.Marshaler.Write(__msg, result);
		CardClient.Marshaler.Write(__msg, comment);
		
	Nettention.Proud.HostID[] __list = new Nettention.Proud.HostID[1];
	__list[0] = remote;
		
	return RmiSend(__list,rmiContext,__msg,
		RmiName_ReplyLogon, Common.ReplyLogon);
}

public bool ReplyLogon(Nettention.Proud.HostID[] remotes,Nettention.Proud.RmiContext rmiContext, int groupID, int result, String comment)
{
	Nettention.Proud.Message __msg=new Nettention.Proud.Message();
__msg.SimplePacketMode = core.IsSimplePacketMode();
Nettention.Proud.RmiID __msgid= Common.ReplyLogon;
__msg.Write(__msgid);
CardClient.Marshaler.Write(__msg, groupID);
CardClient.Marshaler.Write(__msg, result);
CardClient.Marshaler.Write(__msg, comment);
		
	return RmiSend(remotes,rmiContext,__msg,
		RmiName_ReplyLogon, Common.ReplyLogon);
}
// RMI name declaration.
// It is the unique pointer that indicates RMI name such as RMI profiler.
const string RmiName_ReplyLogon="ReplyLogon";
       
const string RmiName_First = RmiName_ReplyLogon;
		public override Nettention.Proud.RmiID[] GetRmiIDList() { return Common.RmiIDList; } 
	}
}

