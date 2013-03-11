using System;
using System.Collections.Generic;

namespace MCDawn
{
    public abstract class Command
    {
        public abstract string name { get; }
        public abstract string[] aliases { get; }
        public abstract string type { get; }
        public abstract bool museumUsable { get; }
        public abstract LevelPermission defaultRank { get; }
        public abstract void Use(Player p, string message);
        public abstract void Help(Player p);

        public static CommandList all = new CommandList();
        public static CommandList core = new CommandList();
        public static void InitAll()
        {
            //all.Add(new CmdLua());
            all.Add(new CmdMiddle());
            //all.Add(new CmdCommandBlock());

            //Homes
            all.Add(new CmdHome());
            all.Add(new CmdHWipe());
            all.Add(new CmdHLockMap());
            all.Add(new CmdHSave());
            all.Add(new CmdHFixGrass());
            all.Add(new CmdHKick());
            all.Add(new CmdHMotd());
            all.Add(new CmdHPhysics());
            all.Add(new CmdHPortal());
            all.Add(new CmdHRestore());
            all.Add(new CmdHSpawn());
            all.Add(new CmdHZone());

            all.Add(new CmdAbort());
            all.Add(new CmdAbout());
            all.Add(new CmdAdminChat());
            all.Add(new CmdAfk());
            all.Add(new CmdAllowGun());
            all.Add(new CmdBan());
            all.Add(new CmdBanip());
            all.Add(new CmdBind());
            all.Add(new CmdBlocks());
            all.Add(new CmdBlockSet());
            all.Add(new CmdBotAdd());
            all.Add(new CmdBotAI());
            all.Add(new CmdBotRemove());
            all.Add(new CmdBots());
            all.Add(new CmdBotSet());
            all.Add(new CmdBotSummon());
            all.Add(new CmdClearBlockChanges());
            all.Add(new CmdClick());
            all.Add(new CmdClones());
            all.Add(new CmdCmdBind());
            all.Add(new CmdCmdCreate());
            all.Add(new CmdCmdLoad());
            all.Add(new CmdCmdSet());
            all.Add(new CmdCmdUnload());
            all.Add(new CmdCompile());
            all.Add(new CmdCompLoad());
            all.Add(new CmdColor());
            all.Add(new CmdCopy());
            all.Add(new CmdCTF());
            all.Add(new CmdCTFTeam());
            all.Add(new CmdCuboid());
            all.Add(new CmdCure());
            all.Add(new CmdDelete());
            all.Add(new CmdDeleteLvl());
            all.Add(new CmdDevs());
            all.Add(new CmdDrop());
            all.Add(new CmdEmote());
            all.Add(new CmdFill());
            all.Add(new CmdFixGrass());
            all.Add(new CmdFlipHeads());
            all.Add(new CmdFly());
            all.Add(new CmdFollow());
            all.Add(new CmdFreeze());
            all.Add(new CmdGive());
            all.Add(new CmdGlobal());
            all.Add(new CmdGoto());
            all.Add(new CmdGun());
            all.Add(new CmdHacks());
            all.Add(new CmdIrc());
            // all.Add(new CmdHeartbeat()); DEBUG COMMAND DO NOT USE
            all.Add(new CmdHelp());
            all.Add(new CmdHide());
            all.Add(new CmdHighlight());
            all.Add(new CmdHollow());
            all.Add(new CmdHost());
            all.Add(new CmdImport());
            all.Add(new CmdImageprint());
            all.Add(new CmdImpersonate());
            all.Add(new CmdInbox());

            // Infection
            all.Add(new CmdInfect());
            all.Add(new CmdInfected());
            all.Add(new CmdInfection());
            all.Add(new CmdAlive());
            all.Add(new CmdQueue());

            all.Add(new CmdInfo());
            all.Add(new CmdInvincible());
            all.Add(new CmdIrcReset());
            all.Add(new CmdJail());
            all.Add(new CmdJoker());
            all.Add(new CmdKick());
            all.Add(new CmdKickban());
            all.Add(new CmdKill());
            all.Add(new CmdKillPhysics());
            all.Add(new CmdLastCmd());
            all.Add(new CmdLevels());
            all.Add(new CmdLimit());
            all.Add(new CmdLine());
            all.Add(new CmdLoad());
            all.Add(new CmdLockMap());
            all.Add(new CmdLowlag());
            all.Add(new CmdMaintenance());
            all.Add(new CmdMain());
            all.Add(new CmdMap());
            all.Add(new CmdMapInfo());
            all.Add(new CmdMe());
            all.Add(new CmdMeasure());
            //all.Add(new CmdMegaboid()); // useless now, with building commands throttle speed :D
            all.Add(new CmdMessageBlock());
            all.Add(new CmdMissile());
            all.Add(new CmdMode());
            all.Add(new CmdModerate());
            all.Add(new CmdMove());
            all.Add(new CmdMuseum());
            all.Add(new CmdMute());
            all.Add(new CmdNewLvl());
            all.Add(new CmdOpChat());
            all.Add(new CmdOpRules());
            all.Add(new CmdOutline());
            all.Add(new CmdPaint());
            all.Add(new CmdPaste());
            all.Add(new CmdPause());
            all.Add(new CmdPay());
            all.Add(new CmdPCount());
            all.Add(new CmdPermissionBuild());
            all.Add(new CmdPermissionVisit());
            all.Add(new CmdPhysics());
            all.Add(new CmdPlace());
            all.Add(new CmdPlayers());
            all.Add(new CmdPortal());
            all.Add(new CmdPossess());
            all.Add(new CmdPrivate());
            all.Add(new CmdRagequit());
            all.Add(new CmdRainbow());
            all.Add(new CmdRedo());
            all.Add(new CmdReferee());
            all.Add(new CmdRenameLvl());
            all.Add(new CmdRepeat());
            all.Add(new CmdReplace());
            all.Add(new CmdReplaceAll());
            all.Add(new CmdReplaceNot());
            all.Add(new CmdRestart());
            all.Add(new CmdRestartPhysics());
            all.Add(new CmdRestore());
            all.Add(new CmdRetrieve());
            all.Add(new CmdReveal());
            all.Add(new CmdRevoke());
            all.Add(new CmdRide());
            all.Add(new CmdRoll());
            all.Add(new CmdRules());
            all.Add(new CmdSave());
            all.Add(new CmdSay());
            all.Add(new CmdSend());
            all.Add(new CmdServerReport());
            all.Add(new CmdSetRank());
            all.Add(new CmdSetspawn());
            all.Add(new CmdSlap());
            all.Add(new CmdSpawn());
            all.Add(new CmdSpheroid());
            all.Add(new CmdSpin());
            all.Add(new CmdStairs());
            all.Add(new CmdStatic());
            all.Add(new CmdStore());
            all.Add(new CmdSummon());
            all.Add(new CmdSummonMap());
            all.Add(new CmdTake());
            //all.Add(new CmdTBracket());
            all.Add(new CmdTColor());
            all.Add(new CmdTempBan());
            all.Add(new CmdTempRank());
            all.Add(new CmdText());
            all.Add(new CmdTime());
            all.Add(new CmdTimer());
            all.Add(new CmdTitle());
            all.Add(new CmdTnt());
            all.Add(new CmdTp());
            all.Add(new CmdTpZone());
            all.Add(new CmdTree());
            all.Add(new CmdTrust());
            all.Add(new CmdUnban());
            all.Add(new CmdUnbanip());
            all.Add(new CmdUndo());
            all.Add(new CmdUnflood());
            all.Add(new CmdUnload());
            all.Add(new CmdUnloaded());
            all.Add(new CmdUpdate());
            all.Add(new CmdView());
            all.Add(new CmdViewRanks());
            all.Add(new CmdVoice());
            all.Add(new CmdWhisper());
            if (Server.useWhitelist) { all.Add(new CmdWhitelist()); }
            all.Add(new CmdWhoip());
            all.Add(new CmdWhois());
            all.Add(new CmdWhowas());
            all.Add(new CmdWrite());
            all.Add(new CmdZone());
            all.Add(new CmdZoneAll());
            all.Add(new CmdCrashServer());
            all.Add(new CmdPromote());
            all.Add(new CmdDemote());
            all.Add(new CmdDrill());
            all.Add(new CmdAward());
            all.Add(new CmdAwards());
            all.Add(new CmdAwardMod());
            all.Add(new CmdXban());
            all.Add(new CmdFacepalm());
            all.Add(new CmdFakeRank());
            all.Add(new CmdVisible());
            all.Add(new CmdReview());
            all.Add(new CmdDecline());
            all.Add(new CmdClearChat());
            all.Add(new CmdSpleef());
            all.Add(new CmdPCommand());
            all.Add(new CmdGrantPass());
            all.Add(new CmdSetPass());
            all.Add(new CmdPass());
            all.Add(new CmdRankChat());
            all.Add(new CmdWarn());
            all.Add(new CmdAgree());
            all.Add(new CmdAgreePass());
            all.Add(new CmdDisAgree());
            all.Add(new CmdSetMain());
            all.Add(new CmdObUpdate());
            all.Add(new CmdGbUpdate());
            //all.Add(new CmdPump());
            all.Add(new CmdCallConsole());
            all.Add(new CmdBitchSlap());
            all.Add(new CmdMoney());
            all.Add(new CmdIgnore());
            all.Add(new CmdDeafen());
            all.Add(new CmdZz());
            all.Add(new CmdTimeRank());
            all.Add(new CmdSetTime());
            all.Add(new CmdChatroom());
            all.Add(new CmdWomText());
            all.Add(new CmdP2P());
            all.Add(new CmdPatrol());
            all.Add(new CmdLoginMessage());
            all.Add(new CmdLogoutMessage());
            all.Add(new CmdTpRequest());
            all.Add(new CmdTpAccept());
            all.Add(new CmdTpDeny());
            all.Add(new CmdSummonRequest());
            all.Add(new CmdSummonAccept());
            all.Add(new CmdSummonDeny());
            all.Add(new CmdCage());
            all.Add(new CmdShutdown());
            all.Add(new CmdSetSkin());
            all.Add(new CmdXray());
            all.Add(new CmdPlugin());
            all.Add(new CmdDisplayName());
            all.Add(new CmdThrough());
            all.Add(new CmdTop());
            all.Add(new CmdUnder());
            all.Add(new CmdUserDetail());
            all.Add(new CmdPortCheck());
            all.Add(new CmdBrush());
            all.Add(new CmdHandcuff());
            all.Add(new CmdDiscourager());
            all.Add(new CmdSpeedHacks());
            all.Add(new CmdAutoBuild());
            all.Add(new CmdCaps());
            all.Add(new CmdCopyLvl());
            all.Add(new CmdRemote());
            all.Add(new CmdRemoteUser());
            all.Add(new CmdLogSearch());
            all.Add(new CmdUnXban());
            all.Add(new CmdPauseCuboids());
            all.Add(new CmdThrottle());
            all.Add(new CmdShowNames());
            all.Add(new CmdPushBall());
            all.Add(new CmdPushBallTeam());
            //all.Add(new CmdReflection());
            all.Add(new CmdReport());
            all.Add(new CmdSetWomPass());
            all.Add(new CmdHAllowGuns());
            all.Add(new CmdDome());
            all.Add(new CmdCone());
            all.Add(new CmdPyramid());

            //all.Add(new Commands.GameControl.CmdGame());

            #region OpenNet Added Commands/Features

            /* VERSION 1.0 */
            all.Add(new CmdDetain()); //Detain a player on a specific map
            //Added detained bool in Player class
            //Added detained-checker in CmdGoto class
            all.Add(new CmdSuggest()); //Send suggestions to me :3
            /*all.Add(new CmdXTitle()); //Give used-player a title
            all.Add(new CmdXTColor());*/
            //all.Add(new CmdSwear()); //Toggle swear censoring mode, undone
            all.Add(new CmdPunch()); //Punch someone :3
            all.Add(new CmdKillMobs()); //Kill all existing block on users' current map
            all.Add(new CmdInherit());
            all.Add(new CmdInfluence());
            all.Add(new CmdRotate());
            all.Add(new CmdInstaMap());
            all.Add(new CmdC4());
            //added bombset bool
            //----- bombpos int array
            all.Add(new CmdOP());
            all.Add(new CmdBeacon());
            //----- kill distance in gun
            all.Add(new CmdMark()); 
            all.Add(new CmdFCuboid()); //experiment with cuboid for system

            #endregion 

            core.commands = new List<Command>(all.commands);

            Scripting.Autoload();
        }
    }
}