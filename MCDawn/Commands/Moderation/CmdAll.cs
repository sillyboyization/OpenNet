using System;

namespace MCDawn
{
    public class CmdAll : Command
    {
        public override string name { get { return "all"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override string type { get { return "mod"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Admin; } }
        public CmdAll() { }
        string Cmd;

        public override void Use(Player p, string message)
        {
            switch (message.ToLower()) 
            {
                case "kick": Cmd = "kick"; break;
                case "slap": Cmd = "slap"; break;
                case "ban": Cmd = "ban"; break;
                case "banip": Cmd = "banip"; break;
                case "unban": Cmd = "unban"; break;
                case "unbanip": Cmd = "unbanip"; break;
                case "freeze": Cmd = "freeze"; break;
                case "demote": Cmd = "demote"; break;
                case "promote": Cmd = "promote"; break;
                case "unfreeze": Cmd = "unfreeze"; break;
                case "detain": Cmd = "detain"; break;
                default: Help(p); return;
            }
            PerformAll(p, Cmd);
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/all <action> - perform <action> on all player on the server.");
            Player.SendMessage(p, "Actions Available: Kick, Slap, Ban, BanIP, UnBan, UnBanIP, Freeze, Demote, Promote, Unfreeze, Detain.");
        }

        void PerformAll(Player p, string Cmd)
        {
            foreach (Player plr in Player.players)
            {
                if (plr.group.Permission < p.group.Permission && plr != p)
                {
                    Command.all.Find(Cmd).Use(p, plr.name);
                }
            }
        }
    }
}
