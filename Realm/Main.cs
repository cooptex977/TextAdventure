﻿// /////////////////////////////////////////////////////////////////////////////////////////////////////                                                                                           
// Project - Realm created on 09/27/2013 by Cooper Teixeira                                           //
//                                                                                                    //
// Copyright (c) 2014 - All rights reserved                                                           //
//                                                                                                    //
// This software is provided 'as-is', without any express or implied warranty.                        //
// In no event will the authors be held liable for any damages arising from the use of this software. //
// /////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;

namespace Realm
{
    public static class Main
    {
        public const string version = "v1.8.6.5";

        public static int loop_number,
            slimecounter,
            goblincounter,
            banditcounter,
            drakecounter,
            wkingcounter,
            slibcounter,
            forrestcounter,
            libcounter,
            centrallibcounter,
            ramsaycounter,
            magiccounter,
            nlibcounter,
            townfolkcounter,
            nomadcounter,
            minecounter,
            frozencounter,
            noobcounter,
            gbooks,
            intlbuff,
            defbuff,
            atkbuff,
            spdbuff;

        public static bool raven_dead,
            is_theif,
            wkingdead, 
            devmode,
            command,
            hasmap,
            is_typing,
            hasFarmedCrystal,
            achievements_disabled,
            fullscreen = true;

        public static Difficulty difficulty = Difficulty.easy;
        public static uint volume;
        public static TextSpeed speed = TextSpeed.Slow;
        public static ConsoleColor DefaultColor = ConsoleColor.Gray;

        public static readonly Achievement ach = new Achievement();
        public static readonly Player.GamePlayer Player = new Player.GamePlayer();

        public static readonly Random rand = new Random();

        public static string tpath,
            path,
            achpath,
            tachpath,
            crashpath,
            spath;

        public static Dictionary<string, bool> achieve = new Dictionary<string, bool>();

        public static SoundPlayer mainplayer;

        public static readonly List<Item> MainItemList = new List<Item>
        {
            new cardboard_armor(),
            new cardboard_shield(),
            new cardboard_sword(),
            new iron_band(),
            new iron_buckler(),
            new iron_lance(),
            new iron_mail(),
            new iron_rapier(),
            new wood_armor(),
            new wood_plank(),
            new wood_staff(),
            new fmBP(),
            new sonictee(),
            new slwscreen(),
            new plastic_ring(),
            new m_amulet(),
            new m_robes(),
            new m_staff(),
            new m_tome(),
            new bt_battleaxe(),
            new bt_greatsword(),
            new bt_longsword(),
            new bt_plate(),
            new blood_amulet(),
            new swifites(),
            new ice_amulet(),
            new ice_dagger(),
            new ice_shield(),
            new p_mail(),
            new p_shield(),
            new p_shortsword(),
            new goldcloth_cloak(),
            new a_amulet(),
            new a_mail(),
            new a_staff(),
            new tome(),
            new ds_amulet(),
            new ds_kite(),
            new ds_kris(),
            new ds_scale(),
            new sb_saber(),
            new sb_chain(),
            new sb_gauntlet(),
            new sb_shield()
        };

        public static void Tutorial()
        {
            var secret = new List<string>{ "human", "elf", "warrior", "rockman", "shade", "zephyr", "giant" };
            if (achieve["100slimes"])
                secret.Add("Slime");
            if (achieve["100goblins"])
                secret.Add("Goblin");
            if (achieve["100bandits"])
                secret.Add("Bandit");
            if (achieve["100drakes"])
                secret.Add("Drake");
            Interface.type("Welcome, ");
            Interface.typeOnSameLine(Player.name, ConsoleColor.White);
            Interface.typeOnSameLine(", to Realm.");
            if (achieve["finalboss"])
                Player.backpack.Add(new nightbringer());
            if (!devmode)
            {
                Interface.type("Skip the tutorial? (y/n)");
                if (Interface.readkey().KeyChar == 'n')
                {
                    Interface.type("To do anything in Realm, simply press one of the listed commands.");
                    Interface.type("If at any time, you wish to you view you stats, press 'v'");
                    Interface.type(
                        "Make sure to visit every library! They offer many valuable abilities as well as experience.");
                    Interface.type(
                        "When in combat, select an availible move. All damage is randomized. Mana is refilled after each fight.");
                    Interface.type(
                        "While in the backpack, simply select a number corresponding to an item. You may swap this item in or out. Make sure to equip an item once you pick it up!");
                    Interface.type("At any specified time, you may press #. Doing so will save the game.");
                    Interface.type("You may also press 'Esc' to access options.");
                }
                Interface.type(
                    "In Realm, every player selects a race. Each race gives its own bonuses. You may choose from Human, Elf, Rockman, Giant, Zephyr, or Shade.");
                if (achieve["100slimes"] || achieve["100goblins"] || achieve["100bandits"] || achieve["100drakes"])
                {
                    Interface.type("Secret Races: ", ConsoleColor.Yellow);
                    for (var i = 0; i < secret.Count; i++)
                    {
                        if (i > 1)
                            Interface.typeOnSameLine(", ", ConsoleColor.Yellow);
                        Interface.type(secret[i], ConsoleColor.Yellow);
                    }
                }
                Interface.type("Please enter a race. ");
                bool rresult = false;
                while (!rresult)
                {
                    var s = Interface.readinput();
                    if (secret.Contains(s))
                        rresult = Enum.TryParse(s, true, out Player.race);
                    else
                        Interface.type("Please enter a valid race: ", ConsoleColor.Red);
                }
                Interface.type("You have selected " + Player.race.ToString().ToUpperFirstLetter() + ".",
                    ConsoleColor.Magenta);
                Interface.type("Each player also has a class. You may choose from Warrior, Paladin, Mage, or Thief.");
                Interface.type("Please enter a class. ");
                bool cresult = false;
                while (!cresult)
                {
                    cresult = Enum.TryParse(Interface.readinput(), true, out Player.pclass);
                    if (!cresult)
                        Interface.type("Please enter a valid class.", ConsoleColor.Red);
                }
                Interface.type("You have selected " + Player.pclass.ToString().ToUpperFirstLetter() + ".",
                    ConsoleColor.Magenta);
                Interface.type("You are now ready to play Realm. Good luck!");
                Interface.type("Press any key to continue.", ConsoleColor.White);
                Interface.readkey();
                Map.PlayerPosition.x = 0;
                Map.PlayerPosition.y = 6;
                if (Player.race == pRace.giant)
                    Player.hp = 15;
            }
            MainLoop();
        }

        private static void Options()
        {
            bool optioning = true;
            while (optioning)
            {
                Console.Clear();
                Interface.typeNoDelay("OPTIONS:\r\n", ConsoleColor.White);
                Interface.type("1. Text speed\r\n\r\n2. Volume\r\n\r\n3. Difficulty\r\n\r\n4. Default text color\r\n\r\n5. Window size (will require restart)\r\n\r\n6. Delete save(will require restart)\r\n\r\n7. Exit settings\r\n\r\n8. Exit game\r\n\r\nEnter a number listed to set the value: ");
                switch (Interface.readkey().KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Interface.type("Please enter slow, medium, fast, or zero (current setting: " + speed + "): ");
                        bool valid = false;
                        while (!valid)
                        {
                            switch (Interface.readinput().ToLower())
                            {
                                case "1":
                                case "slow":
                                    speed = TextSpeed.Slow;
                                    valid = true;
                                    break;
                                case "2":
                                case "medium":
                                    speed = TextSpeed.Medium;
                                    valid = true;
                                    break;
                                case "3":
                                case "fast":
                                    speed = TextSpeed.Fast;
                                    valid = true;
                                    break;
                                case "4":
                                case "zero":
                                    speed = TextSpeed.Zero;
                                    valid = true;
                                    break;
                                default:
                                    Interface.type("Invalid.\r\n");
                                    break;
                            }
                        }
                        break;
                    case '2':
                        Console.Clear();
                        NativeMethods.waveOutGetVolume(IntPtr.Zero, out volume);
                        var CalcVol = (ushort)(volume & 0x0000ffff);
                        Interface.type("Please enter a number between 1 and 10 (current volume: " + CalcVol / (ushort.MaxValue / 10) + "): ");
                        bool valid2 = false;
                        int input = 0;
                        while (!valid2) valid2 = int.TryParse(Interface.readinput(), out input);
                        var NewVolume = ((ushort.MaxValue / 10) * input);
                        volume = (((uint)NewVolume & 0x0000ffff) | ((uint)NewVolume << 16));
                        NativeMethods.waveOutSetVolume(IntPtr.Zero, volume);
                        break;
                    case '3':
                        Console.Clear();
                        Interface.type("Please enter easy, normal, or impossible (current difficulty: " + difficulty + "): ");
                        bool success = false;
                        while (!success) success = Enum.TryParse(Interface.readinput(), out difficulty);
                        break;
                    case '4':
                        Console.Clear();
                        Interface.type("Color options: Black, Blue, Cyan, Gray, Green, Magenta, Red, Dark Blue, Dark Cyan, Dark Gray, Dark Green, Dark Magenta, Dark Red");
                        Interface.type("Please enter a color: ");
                        bool colorified = false;
                        while (!colorified)
                            colorified = Enum.TryParse(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Interface.readinput()), out DefaultColor);
                        break;
                    case '5':
                        Console.Clear();
                        Interface.type("Fullscreen? (y/n) ");
                        switch (Interface.readkey().KeyChar)
                        {
                            case 'y':
                                fullscreen = true;
                                Save.SaveSettings();
                                Restart();
                                break;
                            default:
                                fullscreen = false;
                                Save.SaveSettings();
                                Restart();
                                break;
                        }
                        break;
                    case '6':
                        Console.Clear();
                        Interface.type("Are you sure you want to delete your save? (y/n) ");
                        if (Interface.readkey().KeyChar == 'y')
                        {
                            if (File.Exists(path))
                                File.Delete(path);
                            Restart();
                        }
                        break;
                    case '7':
                        Console.Clear();
                        Interface.type("Save settings? (y/n) ");
                        if (Interface.readkey().KeyChar == 'y')
                            Save.SaveSettings();
                        optioning = false;
                        break;
                    case '8':
                        Console.Clear();
                        Interface.type("Are you sure? (y/n) ");
                        switch (Interface.readkey().KeyChar)
                        {
                            case 'y':
                                Interface.type("Would you like to save? (y/n) ");
                                switch (Interface.readkey().KeyChar)
                                {
                                    case 'y':
                                        Save.SaveSettings();
                                        Save.SaveGame();
                                        Environment.Exit(0);
                                        break;
                                    default:
                                        Environment.Exit(0);
                                        break;
                                }
                                break;
                        }
                        break;
                }
            }
        }

        public static void MainLoop()
        {
            mainplayer.PlayLooping();
            while (Player.hp > 0)
            {
                if (Player.abilities.commands.ContainsKey('&'))
                    Player.abilities.RemoveCommand('&');
                if (slimecounter == 100)
                    ach.Get("100slimes");
                if (goblincounter == 100)
                    ach.Get("100goblins");
                if (banditcounter == 100)
                    ach.Get("100bandits");
                if (drakecounter == 100)
                    ach.Get("100drakes");

                var xy = Map.CoordinatesOf(typeof (Nomad));
                Map.map[xy.Item1, xy.Item2] = new Place();
                var nextNomad = Map.getRandomBlankTile();
                Map.map[nextNomad.Item1, nextNomad.Item2] = new Nomad();

                foreach (var p in Map.map)
                    if (p.GetType() == typeof (Place))
                        p.is_npc_active = false;
                var randomTile = Map.getRandomBlankTile();
                if (rand.NextDouble() <= .1)
                    Map.map[randomTile.Item1, randomTile.Item2].is_npc_active = true;

                if (devmode)
                {
                    Interface.type("Dev Powers!", ConsoleColor.DarkMagenta);
                    Player.primary = new phantasmal_claymore();
                    Player.secondary = new spectral_bulwark();
                    Player.armor = new illusory_plate();
                    Player.accessory = new void_cloak();
                    hasmap = true;
                }
                Player.applybonus();
                Enemy enemy;
                Player.levelup();
                Place currPlace = Map.map[Map.PlayerPosition.x, Map.PlayerPosition.y];
                if (Player.hp > Player.maxhp)
                    Player.hp = Player.maxhp;
                if (loop_number >= 1)
                {
                    if (Combat.CheckBattle() && currPlace.getEnemyList() != null && !devmode)
                    {
                        enemy = currPlace.getEnemyList();
                        Combat.BattleLoop(enemy);
                    }
                }
                Item pc = new phantasmal_claymore();
                Item sb = new spectral_bulwark();
                Item ip = new illusory_plate();
                Item vc = new void_cloak();
                if ((Player.backpack.Contains(pc) && Player.backpack.Contains(sb) && Player.backpack.Contains(ip) &&
                     Player.backpack.Contains(vc)) || devmode)
                {
                    if (!Player.abilities.commandChars.Contains('*'))
                        Player.abilities.AddCommand(new Combat.EndtheIllusion("End the Illusion", '*'));
                    ach.Get("set");
                }
                if (devmode)
                    Interface.type(Map.PlayerPosition.x + " " + Map.PlayerPosition.y);
                if (!devmode)
                    Player.applybonus();
                else
                    Player.applydevbonus();
                if (gbooks >= 3 && !Player.abilities.commandChars.Contains('@'))
                {
                    Interface.type(
                        "Having read all of the Ramsay books, you are enlightened in the ways of Gordon Ramsay.");
                    Player.abilities.AddCommand(new Combat.HellsKitchen("Hell's Kitchen", '@'));
                }
                Interface.type(!devmode ? currPlace.Description : currPlace.ToString());
                var currcommands = currPlace.getAvailableCommands();
                Interface.typeOnSameLine("\r\nYour current commands are " + currcommands[0], ConsoleColor.Cyan);
                foreach (var c in currcommands.Skip(1))
                    Interface.typeOnSameLine(", " + c, ConsoleColor.Cyan);
                Interface.type("");

                var readkey = Interface.readkey();

                if (readkey.Key == ConsoleKey.Escape)
                    Options();
                else if (readkey.KeyChar == '-' && (devmode || command))
                {
                    try
                    {
                        var cmdargs = Interface.readinput().Split();
                        var cmd = cmdargs[0];
                        var numargs = cmdargs.Length;
                        switch (cmd)
                        {
                            case "end":
                                End.Endgame();
                                break;
                            case "combat":
                            {
                                var etype = Type.GetType("Realm." + cmdargs[1]);
                                try
                                {
                                    var e = (Enemy) Activator.CreateInstance(etype);
                                    Combat.BattleLoop(e);
                                }
                                catch (ArgumentNullException)
                                {
                                    Interface.type("Invalid Enemy.");
                                }
                            }
                                break;
                            case "name":
                                Player.name = cmdargs[1];
                                break;
                            case "additem":
                                var atype = Type.GetType("Realm." + cmdargs[1]);
                                try
                                {
                                    var i = (Item) Activator.CreateInstance(atype);

                                    if (Player.backpack.Count <= 10)
                                    {
                                        if (numargs >= 3)
                                        {
                                            for (int j = 0; j < int.Parse(cmdargs[2]); j++)
                                                Player.backpack.Add(i);
                                        }
                                        else
                                            Player.backpack.Add(i);
                                    }
                                    else
                                    {
                                        Interface.type("Not enough space.");
                                    }
                                }
                                catch (ArgumentNullException)
                                {
                                    Interface.type("Invalid Item.");
                                }
                                break;
                            case "droploot":
                                if (rand.NextDouble() <= .1d)
                                {
                                    Player.backpack.Add(MainItemList[rand.Next(0, MainItemList.Count - 1)]);
                                }
                                else
                                {
                                    Interface.type("Nothing dropped.");
                                }
                                break;
                            case "teleport":
                            {
                                var xcoord = int.Parse(cmdargs[1]);
                                var ycoord = int.Parse(cmdargs[2]);
                                Map.PlayerPosition.x = xcoord;
                                Map.PlayerPosition.y = ycoord;
                            }
                                break;
                            case "level":
                                Player.level = int.Parse(cmdargs[1]);
                                break;
                            case "levelup":
                                Player.xp += Player.xp_next;
                                break;
                            case "getach":
                                ach.Get(cmdargs[1]);
                                break;
                            case "suicide":
                                End.GameOver();
                                break;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                    }
                }
                else
                    currPlace.handleInput(readkey.KeyChar);
                loop_number++;
                Player.mana += Player.mana >= Player.maxmana ? 0 : 1;
            }
        }

        private static void Restart()
        {
            var Info = new ProcessStartInfo
            {
                Arguments =
                    "/C ping 127.0.0.1 -n 2 && \"" +
                    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(Info);
            Environment.Exit(0); 
        }
    }
}