using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn
{
    public class CmdOP  : Command
    {
        public override string name { get { return "op"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdOP() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            if (who == p) { Player.SendMessage(p, "Cannot OP/De-OP your self!"); return; }

            if (p.group.Permission < Server.opchatperm)
            {
                foreach (Group grp in Group.GroupList)
                {
                    if (grp.Permission == Server.opchatperm)
                    {
                        Command.all.Find("rank").Use(p, p.name + " " + grp.name);
                        if (p.hidden)
                        {
                            Player.GlobalMessage("Unknown source opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                        if (p == null)
                        {
                            Player.GlobalMessage("Console opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                        else
                        {
                            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                    }
                }
            }
            else
            {
                foreach (Group grp in Group.GroupList)
                {
                    if (grp.Permission == LevelPermission.Guest)
                    {
                        if (p.hidden)
                        {
                            Player.GlobalMessage("Unknown source de-opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                        if (p == null)
                        {
                            Player.GlobalMessage("Console de-opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                        else
                        {
                            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " de-opped " + who.color + who.name + Server.DefaultColor + ".");
                        }
                    }
                }
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/op <player> - rank the player to the Op Chat rank.");
            Player.SendMessage(p, "If the player is already an OP, then they will get De-OPed.");
        }
    }
}
