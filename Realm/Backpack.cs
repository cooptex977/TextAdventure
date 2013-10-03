﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm
{
    public class Backpack
    {
        public class backpackcommand : Combat.Command
        {
            public backpackcommand(string aname, char cmd)
                : base(aname, cmd)
            {
            }
            public override bool Execute(object Data)
            {
                Item i = (Item)Data;
                Interface.type(i.name);
                Interface.type("Description: " + i.desc);
                Interface.type("Attack Buff: " + i.atkbuff + " / Defense Buff: " + i.defbuff + " / Speed Buff: " + i.spdbuff + " / Intelligence Buff: " + i.intlbuff);
                if (i.slot == 1)
                    Interface.type("Slot: Primary");
                else if (i.slot == 2)
                    Interface.type("Slot: Secondary");
                else if (i.slot == 3)
                    Interface.type("Slot: Armor");
                else if (i.slot == 4)
                    Interface.type("Slot: Accessory");
                Interface.type("Tier: " + i.tier);
                Interface.type("Enter (y) to equip this item, (d) to destroy and anything else to go back.");
                char c = Interface.readkey().KeyChar;
                switch (c)
                {
                    case 'y':
                        if (i.slot == 1)
                            Main.Player.primary = i;
                        else if (i.slot == 2)
                            Main.Player.secondary = i;
                        else if (i.slot == 3)
                            Main.Player.armor = i;
                        else if (i.slot == 4)
                            Main.Player.accessory = i;
                        break;
                    case 'd':
                        if (i.slot == 1)
                        {
                            if (Main.Player.primary == i)
                                Main.Player.primary = new Item();
                            Main.Player.backpack.Remove(i);
                        }
                        else if (i.slot == 2)
                        {
                            if (Main.Player.secondary == i)
                                Main.Player.secondary = new Item();
                            Main.Player.backpack.Remove(i);
                        }
                        else if (i.slot == 3)
                        {
                            if (Main.Player.armor == i)
                                Main.Player.armor = new Item();
                            Main.Player.backpack.Remove(i);
                        }
                        else if (i.slot == 4)
                        {
                            if (Main.Player.accessory == i)
                                Main.Player.accessory = new Item();
                            Main.Player.backpack.Remove(i);
                        }
                        break;
                    default:
                        return false;
                }
                return true;
            }
        }
        public static void BackpackLoop()
        {
            bool loopcontrol = true;
            while (loopcontrol)
            {
                Interface.type("**********Current Equipment**********");
                Interface.type("Primary: " + Main.Player.primary.name);
                Interface.type("Secondary: " + Main.Player.secondary.name);
                Interface.type("Armor: " + Main.Player.armor.name);
                Interface.type("Accessory: " + Main.Player.accessory.name);
                Interface.type("*************************************");
                int q = 1;
                Combat.CommandTable cmd = new Combat.CommandTable();
                foreach (Item i in Main.Player.backpack)
                {
                    Interface.type((q - 1) + ". " + i.name);
                    backpackcommand bpcmd = new backpackcommand(i.name, (char)(q + 47));
                    cmd.AddCommand(bpcmd);
                    q++;
                }
                Interface.type("");
                char ch = Interface.readkey().KeyChar;
                if (!cmd.commandChars.Contains(ch))
                    break;
                //if (ch == '1')
                //    cmd.ExecuteCommand('1', 1);
                cmd.ExecuteCommand(ch, Main.Player.backpack[(int)Char.GetNumericValue(ch)]);
            }
        }
    }
}
