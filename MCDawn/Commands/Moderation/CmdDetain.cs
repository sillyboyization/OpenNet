using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn
{
    public class CmdDetain : Command
    {
        public override string name { get { return "detain"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdDetain() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            Level whomap = who.level;
            if (who == null) { Player.SendMessage(p, "Player not found!"); }
            if (who == p) { Player.SendMessage(p, "Can't detain your self!"); }
            if (Server.devs.Contains(who.name) && !Server.devs.Contains(p.name))
            {
                Player.SendMessage(p, "You can't detain an MCDawn Developer!");
                return;
            }
            if (who.group.Permission >= p.group.Permission)
            {
                Player.SendMessage(p, "Can't detain someone with equal or higher rank!");
                return;
            }

            if (who.detained)
            {
                who.detained = false;
                Player.GlobalMessage(who.color + who.name + Server.DefaultColor + " is now freed from detention by " + p.color + p.name + Server.DefaultColor + ".");
                Command.all.Find("displayname").Use(who, who.name);
                return;
            }

            who.detained = true;
            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " detained " + who.color + who.name + Server.DefaultColor + " on map: &a" + whomap.name + Server.DefaultColor + ".");
            Command.all.Find("displayname").Use(who, who.name + " &c(detained)" + who.color + who.name);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/detain <player> - detain a player on their current map, making them unable to go to other maps.");
        }
    }
}
