using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MCDawn
{
    public class CmdC4 : Command
    {
        public override string name { get { return "c4"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Operator; } }
        public CmdC4() { }

        public override void Use(Player p, string message)
        {
            Level level = p.level;
            ushort x = (ushort)(p.pos[0] / 32);
            ushort y = (ushort)(p.pos[1] / 32);
            ushort z = (ushort)(p.pos[2] / 32);
         
            if (p.level.name != Server.HomePrefix + p.name.ToLower() && p.group.Permission < LevelPermission.Operator && Server.devs.Contains(p.name)) { p.SendMessage("You must be on your home map to use /c4!"); return; }

            if (message == "explode") 
            {
                if (!p.setBomb)
                {
                    Player.SendMessage(p, "You haven't set a bomb yet! Set up one by using /C4!");
                    return;
                }

                Player.SendMessage(p, "Succesfully bombed your C4 at the coordinates: ");
                Player.SendMessage(p, "X: " + p.bombpos[0].ToString() + " Y: " + p.bombpos[1].ToString() + " Z: " + p.bombpos[2].ToString());
                try
                {
                    Explode(p, level, p.bombpos[0], p.bombpos[1], p.bombpos[2], 2);
                } 
                catch(Exception e) //I would assume that commands will throw exception already, but meh.... just in case 
                {
                    Player.players.ForEach(delegate(Player plrs)
                    {
                        if (Server.devs.Contains(plrs.name) || plrs.group.Permission >= LevelPermission.Operator)
                        {
                            Player.SendMessage(plrs, e.Message);
                        }
                    });
                }
                p.setBomb = false;
                return;
            }

            if (message == "currentpos") 
            {
                p.bombpos[0] = x;
                p.bombpos[1] = y;
                p.bombpos[2] = z;
                p.setBomb = true;
                Player.SendMessage(p, "Succesfully set your C4 at the coordinates: ");
                Player.SendMessage(p, "X: " + p.bombpos[0].ToString() + " Y: " + p.bombpos[1].ToString() + " Z: " + p.bombpos[2].ToString());
                return;
            }

            Player.SendMessage(p, "Place a block to set your C4");
            p.Blockchange += new Player.BlockchangeEventHandler(p_Blockchange1);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/c4 - let you plant a \"C4\"");
            Player.SendMessage(p, "/c4 currentpos - plant a \"C4\" on your current pos");
            Player.SendMessage(p, "If you already have set a bomb prior to your current use, it will replace your earlier bomb position.");
            Player.SendMessage(p, "/c4 explode - blow up the C4.");
        }

        public void Explode(Player user, Level level, ushort x, ushort y, ushort z, int size)
        {
            level = user.level;
            level.MakeExplosion(x, y, z, size);
        }

        void p_Blockchange1(Player p, ushort x, ushort y, ushort z, byte type) 
        {
            p.bombpos[0] = x;
            p.bombpos[1] = y;
            p.bombpos[2] = z;
            p.setBomb = true;
            Player.SendMessage(p, "Succesfully set your C4 at the coordinates: ");
            Player.SendMessage(p, "X: " + p.bombpos[0].ToString() + " Y: " + p.bombpos[1].ToString() + " Z: " + p.bombpos[2].ToString());
        }
    }
}
