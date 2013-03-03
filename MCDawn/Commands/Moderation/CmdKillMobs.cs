using System;
using System.Collections.Generic;

namespace MCDawn
{
    public class CmdKillMobs : Command
    {
        public override string name { get { return "killmobs"; } }
        public override string[] aliases { get { return new string[] { "mkill" }; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdKillMobs() { }

        public override void Use(Player p, string message)
        {
            List<string> BlockString = new List<string>() //common mobs
            {
                "zombie_head",
                "zombie",
                "creeper",
                "salmon",
                "shark",
                "gold_fish"
            };

            for (int i = 0; i < BlockString.Count ; i++)
            {
                Player.SendMessage(p, "Killing " + BlockString[i] + "....");
                Command.all.Find("replaceall").Use(p, BlockString[i] + " air");
                Player.SendMessage(p, "Sucessfully killed  " + BlockString[i] + "!");
            }
            Player.SendMessage(p, "Successfully killed all mobs.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/killmobs - \"kill\" all existing mob blocks on the map you're on.");
        }   
    }
}