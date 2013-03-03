using System;

namespace MCDawn
{
    public class CmdPaintball : Command
    {
        public override string name { get { return "paintball"; } }
        public override string[] aliases { get { return new string[] { "pbl" , "paintb" , "pball"}; } }
        public override string type { get { return "games"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdPaintball() { }

        public override void Use(Player p, string message)
        {

        }

        public override void Help(Player p)
        {

        }
    }
}
