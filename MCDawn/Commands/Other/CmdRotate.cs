using System;
using System.Threading;

namespace MCDawn 
{
    public class CmdRotate : Command
    {
        public override string name { get { return "rotate"; } }
        public override string[] aliases { get { return new string[] { "rot" }; } }
        public override string type { get { return "other"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.AdvBuilder; } }
        public CmdRotate() { }

        public override void Use(Player p, string message)
        {
            Player who = Player.Find(message);
            if (who.group.Permission > p.group.Permission)
            {
                Player.SendMessage(p, "Cannot rotate someone with equal or higher rank.");
                return;
            }
            if (!onGround(who))
            {
                Player.SendMessage(p, "Player is not on ground! Cannot rotate!");
                return;
            }

            Player.GlobalMessage(p.color + p.name + Server.DefaultColor + " rotated " + who.color + who.name + Server.DefaultColor + ".");
            for (int i = 0; i < 8; i++)
            {
                if (who == null || !who.loggedIn) { Player.SendMessage(p, "Rotating stopped; player logged out during rotation");  return; }
                unchecked { p.SendPos((byte)-1, p.pos[0], p.pos[1], p.pos[2],(byte)(p.rot[0] * 20), p.rot[1]); }
                Thread.Sleep(10);
            }
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/rotate <player> - rotate the player on the standing block.");
        }

        bool onGround(Player p)
        {
            return (!Block.Walkthrough(p.level.GetTile((ushort)(p.pos[0] / 32), (ushort)((p.pos[1] / 32) - 2), (ushort)(p.pos[2] / 32))));
        }
    }
}
