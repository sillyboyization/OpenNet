using System;
using System.Collections.Generic;

namespace MCDawn
{
    public class CmdInherit : Command
    {
        public override string name { get { return "inherit"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdInherit() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            if (who == null) { Player.SendMessage(p, "Player not found!"); return; }
            if (Server.devs.Contains(who.name) && !Server.devs.Contains(p.name))
            {
                Player.SendMessage(p, "Cannot inherit from a Developer.");
                return;
            }
            if (Server.opennetdevs.Contains(who.name) && !Server.opennetdevs.Contains(p.name))
            {
                Player.SendMessage(p, "Cannot inherit from an OpenNet-Developer.");
                return;
            }
            p.color = who.color;
            p.title = who.title;
            p.titlecolor = who.titlecolor;

            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " inherited " + who.color + who.name + Server.DefaultColor + " chat appearance.");

        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/inherit <player> - inherits all of the specified player's chat appearance.");
            Player.SendMessage(p, "Chat Appeaerance: Color, Title, Title Color");
        }
    }
}
