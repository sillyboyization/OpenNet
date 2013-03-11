/*
    Coded by Sumeth Sithanukul (aka Paul), for the use of AsiaNet Freebuild
    NOTE: This is NOT a license
 */

using System;
using System.Collections.Generic; //for teams
using System.Text; //for list-to-string of player in teams

namespace MCDawn.Paintball
{
    public class PaintballCore : Paintball
    {
        #region Core Component

        #region Team
        //add team length checker right now to avoid more lines of code (lazy, lul)
        public void addRed(Player p)
        {
            if (morePlayer(red, blue))
            {
                if (red.Contains(p)) red.Remove(p);
                Player.SendMessage(p, "%cRed Team " + Server.DefaultColor + "full");
                blue.Add(p);
                gls("Player " + p.color + p.name + " joined the %9Blue Team" + Server.DefaultColor + ".");
                setColor(p, "blue");
                return;
            }
            if (!red.Contains(p))
            {
                if (blue.Contains(p)) blue.Remove(p);
                red.Add(p);
                gls("Player " + p.color + p.name + " joined the %cRed Team" + Server.DefaultColor + ".");
                setColor(p, "red");
                return;
            }
        }

        public void addBlue(Player p)
        {
            if (morePlayer(blue, red))
            {
                if (blue.Contains(p)) blue.Remove(p);
                Player.SendMessage(p, "%9Blue Team " + Server.DefaultColor + "full");
                red.Add(p);
                gls("Player " + p.color + p.name + " joined the %cRed Team" + Server.DefaultColor + ".");
                setColor(p, "red");
                return;
            }
            if (!blue.Contains(p))
            {
                if (red.Contains(p)) red.Remove(p);
                gls("Player " + p.color + p.name + " joined the %9Blue Team" + Server.DefaultColor + ".");
                blue.Add(p);
                setColor(p, "blue");
                return;
            }
        }

        public void addSpec(Player p) 
        {
            if (!spec.Contains(p))
            {
                if (blue.Contains(p)) blue.Remove(p);
                if (red.Contains(p)) red.Remove(p);
                spec.Add(p);
                gls("Player " + p.color + p.name + " joined the %0Spec Team" + Server.DefaultColor + ".");
            }
        }

        public void setColor(Player p, string c) 
        {
            Command.all.Find("color").Use(p, c);
            if (c == "blue") { Command.all.Find("title").Use(p, p + " Blue"); }
            if (c == "red") { Command.all.Find("title").Use(p, p + " Red"); }
            Command.all.Find("titlecolor").Use(p, p + " " + c);
        }

        public void removeAllFromTeams()
        {
            gls("Removing all player from all of the teams...");
            foreach (Player rp in red)
                red.Remove(rp);
            foreach (Player bp in blue)
                blue.Remove(bp);
            foreach (Player sp in spec)
                spec.Remove(sp);
            gls("Successfully removed all player from all of the teams...");
        }
        #endregion

        #region Game State
        public void start(Player p) 
        {
            if (gameOn) { return; }

            lvl = p.level;
            if (lvl.players.Count > 2) { gls("There must be atleast 2 players to start the paintball game!"); return; }
 
            gls("Starting a Paintball Game!");
            gameOn = true;

            if (time != defaultCTime) { time = defaultCTime; }
            if (gameTimeLeft != defaultGameTime) { gameTimeLeft = defaultGameTime; }

            removeAllFromTeams();

            foreach (Player pl in lvl.players) 
            {
                if (pl.hidden) { Command.all.Find("hide").Use(pl, "s"); }
                if (pl.invincible) { Command.all.Find("invincible").Use(pl, ""); }
                if (pl.isFlying) { Command.all.Find("fly").Use(pl, ""); }
            } 

            countDownTimer.Elapsed += delegate 
            {
                if (time <= 60) { gls("Starting a Paintball game in 1 minute!"); }
                else if (time <= 30) { gls("Starting a Paintball game in 30 seconds!"); }
                else if (time <= 10) { gls("Starting a Paintball game in " + time); }
                else if (time <= 0) 
                {
                    gls("Paintball game started! Join teams, now!");
                    countDownTimer.Stop();
                    gameTimer.Start();
                }
                time--;
            };

            gameTimer.Elapsed += delegate 
            {
                if (blue.Count <= 0) { stop(null, 1, 2); return; }
                if (red.Count <= 0) { stop(null, 1, 1); return; }
                if (gameTimeLeft <= 0) { stop(null, 0); return; }
                gameTimeLeft--;
            };
        }

        //I kinda hate the method use in winner, since any other number other than 1 will
        //return "blue" in TeamString
        public void stop(Player p, int style, int winner = 0, bool repeat = false) 
        {
            if (!gameOn) { return; }
            switch (style)
            {
                case 0: //Time up
                    gls("Time up! Paintball game stopped!");
                    break;
                case 1: //Team drop to 0
                    gls(TeamString(winner) + " won from eliminating all players from another team!");
                    break;
                case 2: //manual 
                    gls("Paintball game was manually stopped!");
                    break;
            }
            gls("Paintball game ended");
            gameOn = false;
            gameTimer.Stop();
            removeAllFromTeams();

            if (repeat) 
            {
                gls("Restarting Paintball game!s");
                start(null);
            }
        }
        #endregion

        #region Misc
        public void gls(string msg, bool paintball = true)
        {
            if (!paintball)
            {
                Player.GlobalMessage(msg);
                return;
            }
            Player.GlobalMessage("%cPaintball: " + Server.DefaultColor + msg);
        }
        #endregion

        #endregion
    }

    /* holds information... 
     * for organization puposes.. only 
     */
    public class Paintball
    {
        #region Infomation/Properties

        public int gameTimeLeft = 180; //3 mins
        public const int defaultGameTime = 180;
        public int time = 60;
        public const int defaultCTime = 60; //default countdown time (seconds)
        public System.Timers.Timer countDownTimer = new System.Timers.Timer(1000);
        public System.Timers.Timer gameTimer = new System.Timers.Timer(1000);
        public List<Player> red = new List<Player>();
        public List<Player> blue = new List<Player>();
        public List<Player> spec = new List<Player>();

        public Level lvl;

        //Maybe I should do the item system like command? 
        //(have main Item class as base class, and let the item class inherit)
        public List<string> items = new List<string>() { "gun", "knife", "shield" };

        public bool gameOn = false;

        public bool itemMountable(string items) 
        {
            return this.items.Contains(items);
        }

        //Logic: if team 1 have more player than team 2\
        //Basically, team member counts comparison 
        public bool morePlayer(List<Player> lp1, List<Player> lp2)
        {
            return lp1.Count + 2 > lp2.Count;
        }

        //1 - red, other numbers- blue
        public string TeamString(int winner) 
        {
            if (winner == 1)
            {
                return "Red";
            }
            else { return "Blue"; }
        }
        #endregion
    }

    abstract class Item 
    { 
    
    }
}
