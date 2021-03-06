﻿// /////////////////////////////////////////////////////////////////////////////////////////////////////                                                                                           
// Project - Realm created on 09/27/2013 by Cooper Teixeira                                           //
//                                                                                                    //
// Copyright (c) 2014 - All rights reserved                                                           //
//                                                                                                    //
// This software is provided 'as-is', without any express or implied warranty.                        //
// In no event will the authors be held liable for any damages arising from the use of this software. //
// /////////////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace Realm
{
    public class End
    {
        private class GameOverException : Exception
        {
        }

        public static void GameOver()
        {
            try
            {
                throw new GameOverException();
            }
            catch (GameOverException)
            {
            }
            Main.loop_number = 0;
            Interface.type(
                "Game Over. You have been revived at the last inn you stayed in. You have lost half your gold and maybe an item. Press any key to continue.",
                ConsoleColor.DarkRed);
            Console.ReadKey();
            Console.Clear();
            Main.Player.g /= 2;
            Main.Player.reputation = -50;
            Main.Player.xp = 0;
            Main.Player.hp = Main.Player.maxhp;
            if (Main.rand.NextDouble() <= .25)
            {
                int rand = Main.rand.Next(0, Main.Player.backpack.Count == 0 ? 0 : Main.Player.backpack.Count - 1);
                if (Main.Player.backpack.Count > 0)
                {
                    var toRemove = Main.Player.backpack[rand];
                    Main.Player.backpack.RemoveAt(rand);
                    if (!Main.Player.backpack.Contains(toRemove) && Main.Player.primary.name == toRemove.name)
                        Main.Player.primary = new Item();
                    if (!Main.Player.backpack.Contains(toRemove) && Main.Player.secondary.name == toRemove.name)
                        Main.Player.secondary = new Item();
                    if (!Main.Player.backpack.Contains(toRemove) && Main.Player.armor.name == toRemove.name)
                        Main.Player.armor = new Item();
                    if (!Main.Player.backpack.Contains(toRemove) && Main.Player.accessory.name == toRemove.name)
                        Main.Player.accessory = new Item();
                }
            }
            var test = new int[2];
            if (Main.Player.last_inn != test)
            {
                Map.PlayerPosition.x = Main.Player.last_inn[0];
                Map.PlayerPosition.y = Main.Player.last_inn[1];
            }
            else
            {
                Map.PlayerPosition.x = 0;
                Map.PlayerPosition.y = 6;
            }
            Main.MainLoop();
        }

        public static void Endgame()
        {
            if (!Main.devmode)
            {
                if (Main.magiccounter >= 1)
                    Interface.type(
                        "You recognize the magic man from the alley in Central. It is he who stands before you.");
                Interface.type(
                    "\"I am Janus.\" The man before you says. You stand in front of the protetorate, Janus. He says \"" +
                    Main.Player.name +
                    ", have you realized that this world is an illusion?\" You nod your head. \"You will result in the Realm\"s demise, you must be purged. Shimmering darkness gathers around him, and beams of blue light blindingly blast outwards.");
                Interface.type("I regret to say it, but we must fight.");
                Combat.BattleLoop(new finalboss());
                Main.ach.Get("finalboss");
                Interface.type(
                    "Janus defeated, the world vanishes and you both are standing on glass in a blank world of black void.");
                Interface.type(
                    "The protectorate kneels on the ground in front of you. \"Is this truly what you want?\", he says. You look at him without uttering a word. \"Very well, I must ask of you one last favor; even though the Realm is no more, do not let it vanish from within you.\" Everything around you goes black. (Press any key to continue)");
                Interface.readkey();
                Console.Clear();
            }
            Interface.type("GAME CLEAR!", ConsoleColor.Yellow);
            Interface.type("==========STATS==========", ConsoleColor.Yellow);
            Interface.type("Name: " + Main.Player.name, ConsoleColor.Yellow);
            Interface.type("Race: " + Main.Player.race.ToString().ToUpperFirstLetter(), ConsoleColor.Yellow);
            Interface.type("Class: " + Main.Player.pclass.ToString().ToUpperFirstLetter(), ConsoleColor.Yellow);
            Interface.type("Level: " + Main.Player.level, ConsoleColor.Yellow);
            Interface.type("Gold: " + Main.Player.g, ConsoleColor.Yellow);
            Interface.type("Reputation " + Main.Player.reputation, ConsoleColor.Yellow);
            Interface.type("FINAL SCORE: " + calcScore().Item2, ConsoleColor.Yellow);
            Interface.type("FINAL RANK: " + calcScore().Item1, ConsoleColor.Yellow);
            Interface.type("=========================\r\n", ConsoleColor.Yellow);
            Interface.type("Press any key to continue.", ConsoleColor.White);
            Interface.readkey();
            Console.Clear();
            Credits();
        }

        public static void Credits()
        {
            Interface.type(
                "A child awakes from his sleep and looks out the window feeling fulfilled as if a story has come to a close.");
            Interface.type("Press any key to continue.", ConsoleColor.White);
            Interface.readkey();
            Console.Clear();
            Interface.type("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", ConsoleColor.DarkMagenta);
            Interface.type("----------------------Credits---------------------", ConsoleColor.DarkMagenta);
            Interface.type("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~", ConsoleColor.DarkMagenta);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Executive Developer: Cooper Teixeira", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Secondary Developer: Giorgio Lo", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Executive Producer: Cooper Teixeira", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Co-Producer: Giorgio Lo", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Music By: Charlie Catino", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Lead Content Designer: Giorgio Lo", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Secondary Content Designer: Cooper Teixeira", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Executive Game Tester: Rosemary Rogal", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Lead Art Consultant: Rosemary Rogal", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Secondary Art Designer: Giorgio Lo", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Secondary Art Designer: Cooper Teixeira", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Concept Artist: Rosemary Rogal", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Special thanks to:", ConsoleColor.DarkMagenta);
            Interface.type("- Steve Teixeira", ConsoleColor.Yellow);
            Interface.type("- Ryan Teixeira", ConsoleColor.Yellow);
            Interface.type("- Paul Pfenning", ConsoleColor.Yellow);
            Interface.type("- Charlie Catino", ConsoleColor.Yellow);
            Interface.type("- Bradley Lignoski", ConsoleColor.Yellow);
            Interface.type("- Alexander Pfenning", ConsoleColor.Yellow);
            Interface.type("__________________________________________________", ConsoleColor.DarkMagenta);
            Interface.type("Copyright(c) 2014", ConsoleColor.White);
            Interface.type("Press any key to continue.", ConsoleColor.White);
            Interface.readkey();
            Environment.Exit(0);
        }

        private static Tuple<string, int> calcScore()
        {
            var score = (Main.Player.reputation + (Main.Player.level*10) + Main.Player.g) * (int)Main.difficulty;
            var rank = (score >= 1500
                ? "S Rank"
                : score >= 1000
                    ? "A Rank"
                    : score >= 750
                        ? "B Rank"
                        : score >= 500 ? "C Rank" : score >= 250 ? "D Rank" : score >= 0 ? "F Rank" : "you tried");
            return new Tuple<string, int>(rank, score);
        }
    }
}