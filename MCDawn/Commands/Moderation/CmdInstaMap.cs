using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn                   
{
    public class CmdInstaMap : Command
    {
        public override string name { get { return "instamap"; } }
        public override string[] aliases { get { return new string[] { "imap" }; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdInstaMap() { }

        public override void Use(Player p, string message)
        {
            if (String.IsNullOrEmpty(message)) { Help(p); return;  }
            Command.all.Find("newlvl").Use(p, message + " 128 64 128 flat");
            Command.all.Find("load").Use(p, message);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/instamap <map name> - creates a basic flat map.");
        }
    }
}