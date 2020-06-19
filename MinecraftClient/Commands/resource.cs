using MinecraftClient.Protocol.Handlers;
using System.Collections.Generic;

namespace MinecraftClient.Commands {
    public class Resource : Command {
        public override string CMDName { get { return "resource"; } }
        public override string CMDDesc { get { return "resource <loaded|declined|failed|accepted>"; } }

        public override string Run(McTcpClient handler, string command, Dictionary<string, object> localVars) {
            if (hasArg(command)) {


                Protocol18Handler protocol = handler.GetMinecraftCom() as Protocol18Handler;
                if(protocol == null) {
                    return "Error: Only Protocol18 is supported right now...";
                }
                int response;
                command = getArg(command);
                switch (command) {
                    case "loaded":
                        response = 0;
                        break;
                    case "declined":
                        response = 1;
                        break;
                    case "failed":
                        response = 2;
                        break;
                    case "accepted":
                        response = 3;
                        break;
                    default:
                        return $"Error: Unknown return code: '{command}'";
                }

                protocol.SendPacket(PacketOutgoingType.ResourcePackStatus, protocol.dataTypes.GetVarInt(response));




                return "Packet sent!";
            } else return CMDDesc;
        }
    }
}
