using System;

namespace MCDawn
{
    public class CmdBeacon : Command
    {
        public override string name { get { return "beacon"; } }
        public override string[] aliases { get { return new string[] { "pillar" }; } }
        public override string type { get { return "build"; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Builder; } }
        public CmdBeacon() { }

        public override void Use(Player p, string message)
        {
            ushort x = (ushort)(p.pos[0] / 32);
            ushort y = (ushort)((p.pos[1] / 32) + 1);
            ushort z = (ushort)(p.pos[2] / 32);

            if (p == null) { Player.SendMessage(p, "Command not usable from Console."); return; }
            if (message == "remove") { TakeDownBeacon(p, x, y, z); Player.SendMessage(p, "Sucessfully removed a beacon."); return; }


            CreateBeacon(p, x, y, z, Block.redmushroom);
            Player.SendMessage(p, "Sucessfully created a pillar.");
            
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/beacon - Creates a pillar on your coordinates.");
            Player.SendMessage(p, "/beacon remove - removes a pillar");
        }

        public void CreateBeacon(Player p, ushort px, ushort py, ushort pz, byte block)
        {
            Level level = p.level;
            for (ushort yy = level.depth; py <= yy; py++)
            {
                level.Blockchange(p, px, py, pz, block);
            }
        }

        public void TakeDownBeacon(Player p, ushort px, ushort py, ushort pz)
        {
            Level level = p.level;
            for (ushort yy = level.depth; py <= yy; py++)
            {
                if (p.level.GetTile(px, py, pz) == Block.redmushroom) 
                {
                    level.Blockchange(p, px, py, pz, Block.air);
                }
            }
        }
    }
}