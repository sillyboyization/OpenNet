using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn
{
    public class CmdInfluence : Command
    {
        public override string name { get { return "influence"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdInfluence() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            if (who == null) { Player.SendMessage(p, "Player not found!"); return; }
            if (Server.devs.Contains(who.name) && !Server.devs.Contains(p.name))
            {
                Player.SendMessage(p, "Cannot influence a Developer.");
                return;
            }
            if (Server.opennetdevs.Contains(who.name) && !Server.opennetdevs.Contains(p.name))
            {
                Player.SendMessage(p, "Cannot influence an OpenNet-Developer.");
                return;
            }
            if (p.group.Permission <= who.group.Permission)
            {
                Player.SendMessage(p, "Cannot influence someone with equal or higher rank!");
                return;
            }

            who.color = p.color;            
            who.title = p.title;
            who.titlecolor = p.titlecolor; 

            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " influenced " + who.color + who.name + Server.DefaultColor + " on chat appearance.");

        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/influence <player> - gives a player your Chat appearance.");
            Player.SendMessage(p, "Chat Appeaerance: Color, Title, Title Color");
        }
    }
}
