using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn
{
    public class CmdPunch : Command
    {
        public override string name { get { return "punch"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdPunch() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            if (who.group.Permission > p.group.Permission) 
            { 
                Player.SendMessage(p, "Cannot punch someone with higher rank!");
                for (int i = 0; i < 10; i++)
                {
                    Use(who, p.name);
                }
                return; 
            }
            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " punched " + who.color + who.name + Server.DefaultColor + ".");
            unchecked { who.SendPos((byte)-1, p.pos[0], (ushort)(p.pos[1] * 2), p.pos[2], p.rot[0], p.rot[1]); }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/punch <player> - self explanatory o.o.");
        }
    }
}
