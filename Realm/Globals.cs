﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realm
{
    public struct Point
    {
        public int x;
        public int y;
    }
    public class Item
    {
        public string name;
        public string desc;
        public int atkbuff;
        public int defbuff;
        public int spdbuff;
        public int intlbuff;
        public int tier;
        public int slot;
        public float multiplier;
        //1 for primary 2 for secondary 3 for armor 4 for Accessory
        public Item()
        {
            atkbuff = 0;
            defbuff = 0;
            spdbuff = 0;
            intlbuff = 0;
            multiplier = 1;
        }
    }
    public class Globals
    {
        public static Place[,] map = new Place[,] {

        {new Place(), new Seaport(), new Place(), new IllusionForest(), new Place(), new WKingdom()},

        {new Place(), new Place(), new Valleyburg(), new Place(), new Riverwell(), new NKingdom()},
        
        {new SKingdom(), new Nomad(), new CentralKingdom(), new Place(), new Place(), new Place()},
 
        {new Place(), new TwinPaths(), new Place(), new Newport(), new NMtns(), new Place()},        
         
        {new Place(), new Ravenkeep(), new EKingdom(), new Place(), new Place(), new Place()}

        };

        public static Point PlayerPosition;
    }
    public class cardboard_armor : Item
    {
        public cardboard_armor()
        {
            name = "Cardboard Armor";
            desc = "A refrigerator box barely held together by masking tape.";
            defbuff = 1;
            tier = 0;
            slot = 3;
        }
    }
    public class cardboard_sword : Item
    {
        public cardboard_sword()
        {
            name = "Cardboard Sword";
            desc = "One of those wrapping paper tubes you hit your siblings with.";
            atkbuff = 1;
            tier = 0;
            slot = 1;
            multiplier = 1;
        }
    }
    public class cardboard_shield : Item
    {
        public cardboard_shield()
        {
            name = "Carboard Shield";
            desc = "It's just a box from costco.";
            defbuff = 1;
            tier = 0;
            slot = 2;
        }
    }
    //sammy tier
    public class wood_staff : Item
    {
        public wood_staff()
        {

            name = "Wood Staff";
            desc = "A label that reads 'Luigi(sammy)' is stuck on it. There's also blood on the hilt.";
            defbuff = 2;
            atkbuff = 2;
            spdbuff = 1;
            intlbuff = 1;
            tier = 1;
            slot = 1;
            multiplier = 1.075f;
        }
    }
    public class fmBP : Item
    {
        public fmBP()
        {
            name = "Fire Mario Backpack";
            name = "Discontinued because people used its supernatural powers for bad.";
            intlbuff = 5;
            tier = 1;
            slot = 4;
        }
    }
    public class sonictee : Item
    {
        public sonictee()
        {
            name = "Sonic T-Shirt";
            desc = "'Gotta go fast!'(Alright, guys?)";
            defbuff = 1;
            spdbuff = 4;
            tier = 1;
            slot = 3;
        }
    }
    public class slwscreen : Item
    {
        public slwscreen()
        {
            name = "Sonic Lost World Screenshots";
            desc = "This proves you can't hate on Sonic. LIKE SONIC LIKE SONIC LIKE SONIC LIKE SONIC.";
            defbuff = 4;
            tier = 1;
            slot = 3;
        }
    }
    //Bad tier
    public class wood_armor : Item
    {
        public wood_armor()
        {
            name = "Wood Armor";
            desc = "Some plywood you stole from Home Depot. It give you the Home Depot feeling. ";
            defbuff = 5;
            tier = 1;
            slot = 3;
        }
    }
    public class wood_plank : Item
    {
        public wood_plank()
        {

            name = "Wood Plank";
            desc = "A wood plank.";
            defbuff = 1;
            atkbuff = 2;
            tier = 1;
            slot = 1;
            multiplier = 1.1f;
        }
    }
    public class plastic_ring : Item
    {
        public plastic_ring()
        {
            name = "Plastic Ring";
            desc = "It's actually just a Ringpop.";
            spdbuff = 1;
            intlbuff = 1;
            tier = 0;
            slot = 4;
        }
    }
    //mediocre tier
    public class iron_lance : Item
    {
        public iron_lance()
        {
            name = "Iron Lance";
            desc = "A gilded lance of iron.";
            defbuff = 1;
            atkbuff = 3;
            spdbuff = 1;
            tier = 2;
            slot = 1;
            multiplier = 1.1f;
        }
    }
    public class iron_rapier : Item
    {
        public iron_rapier()
        {
            name = "Iron Rapier";
            desc = "A well-smithed blade said to even be able to pierce thick armor if used properly.";
            atkbuff = 5;
            spdbuff = 2;
            tier = 2;
            slot = 1;
            multiplier = 1.1f;
        }
    }
    public class iron_mail : Item
    {
        public iron_mail()
        {
            name = "Iron Chainmail";
            desc = "A reliable suit of armor that sacrifices speed for defense.";
            defbuff = 5;
            spdbuff = -1;
            tier = 2;
            slot = 3;
        }
    }
    public class iron_buckler : Item
    {
        public iron_buckler()
        {

            name = "Iron Buckler";
            desc = "A lightweight buckler meant for all professions.";
            defbuff = 3;
            tier = 2;
            slot = 2;
        }
    }
    public class iron_band : Item
    {
        public iron_band()
        {

            name = "Iron Band";
            desc = "A bland iron band with inscriptions on the inside.";
            spdbuff = 2;
            intlbuff = 5;
            tier = 2;
            slot = 4;
            multiplier = 1.05f;
        }
    }
    //ok tier
    public class bt_longsword : Item
    {
        public bt_longsword()
        {
            name = "Bloodthirsty Longsword";
            desc = "A longsword that has rusted from all of the blood that it has drawn from its prey. It is unknown as to why the rust is crimson.";
            atkbuff = 12;
            slot = 1;
            tier = 3;
            multiplier = 1.3f;
        }
    }
    public class bt_battleaxe : Item
    {
        public bt_battleaxe()
        {
            name = "Bloodthirsty Battleaxe";
            desc = "This weapon was once used on its creator. There is an eerie aura emanating from it. ";
            atkbuff = 10;
            defbuff = 3;
            spdbuff = -1;
            slot = 1;
            tier = 3;
            multiplier = 1.25f;
        }
    }
    public class bt_greatsword : Item
    {
        public bt_greatsword()
        {
            name = "Bloodthirsty Greatsword";
            desc = "An uncommonly large greatsword  traditionally used by the ancients. ";
            atkbuff = 13;
            slot = 1;
            tier = 3;
            multiplier = 1.31f;
        }
    }
    public class bt_plate : Item
    {
        public bt_plate()
        {
            name = "Bloodmail";
            desc = "Chainmail that gained magic protection from the blood of divine animals.";
            atkbuff = 1;
            defbuff = 10;
            tier = 3;
            slot = 3;
        }
    }
    public class blood_amulet : Item
    {
        public blood_amulet()
        {
            name = "Blood Amulet";
            desc = "A red amulet. It is said that the previous owner died from unknown causes.";
            intlbuff = 10;
            spdbuff = 1;
            atkbuff = 1;
            tier = 3;
            slot = 4;
        }
    }
    //good tier
    public class p_shield : Item
    {
        public p_shield()
        {
            name = "Palladium Shield";
            desc = "A shield inscribed with the mark of the protectorate that guards this world.";
            defbuff = 11;
            spdbuff = -1;
            tier = 4;
            slot = 3;
        }
    }
    public class p_shortsword : Item
    {
        public p_shortsword()
        {
            name = "Palladium Shortsword";
            desc = "This blade is only meant to be used for the sake of protecting others.";
            defbuff = 1;
            atkbuff = 10;
            spdbuff = 2;
            slot = 1;
            tier = 4;
            multiplier = 1.25f;
        }
    }
    public class p_mail : Item
    {
        public p_mail()
        {
            name = "Palladium Mail";
            desc = "It is said that Palladium Mail is made by sacred iron that originates from the sky.";
            defbuff = 13;
            spdbuff = -1;
            tier = 4;
            slot = 3;
        }
    }
    public class goldcloth_cloak : Item
    {
        public goldcloth_cloak()
        {
            name = "Goldcloth Cloak";
            desc = "The cloth worn by the hero king who united the realm in the name of peace.";
            intlbuff = 13;
            defbuff = 2;
            tier = 4;
            slot = 4;
        }
    }

    //excellent tier
    public class ds_amulet : Item
    {
        public ds_amulet()
        {
            name = "Darksteel Amulet";
            desc = " An indestructible amulet that was worn by the protectorate when he salvaged the realm from chaos. It reads ' Do not cast the shadow away from light'.";
            defbuff = 7;
            intlbuff = 15;
            tier = 5;
            slot = 4;
        }
    }
    public class ds_kite : Item
    {
        public ds_kite()
        {
            name = "Darksteel Kite Shield";
            desc = "A shield created from the protectorate's shadow.";
            defbuff = 20;
            spdbuff = -2;
            tier = 5;
            slot = 3;
        }
    }
    public class ds_kris : Item
    {
        public ds_kris()
        {
            name = "Darksteel Kris";
            desc = "A dagger that was forged by the protectorate's soul.";
            defbuff = 1;
            spdbuff = 2;
            atkbuff = 10;
            slot = 1;
            tier = 5;
            multiplier = 1.35f;
        }
    }
    public class ds_scale : Item
    {
        public ds_scale()
        {
            name = "Darksteel Scalemail";
            desc = "It came to being when the protectorate casted off its darkness.";
            defbuff = 25;
            tier = 5;
            slot = 3;
        }
    }
    public class sb_saber : Item
    {
        public sb_saber()
        {
            name = "Sunburst Saber";
            desc = "Color where there is none. Light in the darkness.";
            atkbuff = 25;
            spdbuff = 10;
            slot = 1;
            tier = 5;
        }
    }
    public class sb_chain : Item
    {
        public sb_chain()
        {
            name = "Sunburst Ringmail";
            desc = "It gleams all the colors of the rainbow.";
            defbuff = 10;
            atkbuff = 18;
            tier = 5;
            slot = 3;
        }
    }
    public class sb_gauntlet : Item
    {
        public sb_gauntlet()
        {
            name = "Sunburst Gauntlet";
            desc = "a beautiful artifact made for blocking and punching with the left hand.";
            atkbuff = 12;
            defbuff = 8;
            intlbuff = 10;
            slot = 4;
            tier = 5;
        }
    }
    public class sb_shield : Item
    {
        public sb_shield()
        {
            name = "Sunburst Shield";
            desc = "A shield that almost looks like it's meant for attacking.";
            atkbuff = 15;
            defbuff = 20;
            slot = 2;
            tier = 5;
        }
    }
    //god tier
    public class phantasmal_claymore : Item
    {
        public phantasmal_claymore()
        {
            name = "Phantasmal Claymore";
            desc = "The claymore is made from the material used to create the realm.";
            defbuff = 10;
            atkbuff = 50;
            spdbuff = 25;
            intlbuff = 10;
            tier = 6;
            slot = 1;
            multiplier = 3.5f;
        }
    }
    public class spectral_bulwark : Item
    {
        public spectral_bulwark()
        {
            name = "Spectral Bulwark";
            desc = "A shield forged in the flames of the souls of the damned.";
            defbuff = 50;
            atkbuff = 10;
            spdbuff = 10;
            intlbuff = 10;
            tier = 6;
            slot = 2;
        }
    }
    public class illusory_plate : Item
    {
        public illusory_plate()
        {
            name = "Illusory Plate";
            desc = "Even though you know it to be an illusion, every attack against it is futile.";
            defbuff = 100;
            atkbuff = 0;
            tier = 6;
            slot = 3;
        }
    }
    public class void_cloak : Item
    {
        public void_cloak()
        {
            name = "Void Cloack";
            desc = "Its existence is an oxymoron. It is made from nothing.";
            atkbuff = 0;
            spdbuff = 50;
            intlbuff = 50;
            tier = 6;
            slot = 4;
        }
    }
    public class GamePlayer
    {
        public int hp;
        public int maxhp;
        public int spd;
        public int atk;
        public int intl;
        public int def;
        public string name;
        public Item primary = new Item();
        public Item secondary = new Item();
        public Item armor = new Item();
        public Item accessory = new Item();
        public List<Item> backpack;
        public int g;
        public int level;
        public int xp;
        public int xp_next;
        public bool on_fire = false;
        public bool cursed = false;
        public bool stunned = false;
        public bool is_phased;
        public int fire;
        public Realm.Combat.CommandTable abilities;
        public void levelup()
        {
            xp_next = level >= 20 ? 62 + (level - 20) * 7 : (level >= 10 ? 17 + (level - 10) * 3 : 17);
            if (xp >= xp_next)
            {
                hp = maxhp;
                level++;
                Formatting.type("Congratulations! You have leveled up! You are now level " + level + ".");
                xp = 0;
                xp_next = level >= 30 ? 62 + (level - 30) * 7 : (level >= 15 ? 17 + (level - 15) * 3 : 17);
                if (xp >= xp_next)
                    levelup();
            }
        }
        public void applybonus()
        {
            maxhp = 10 + (level);
            def = 0 + (level / 2);
            atk = 1 + (level / 2);
            intl = 1 + (level / 2);
            spd = 1 + (level / 2);

            if (!primary.Equals(default(Item)))
            {
                def += primary.defbuff;
                atk += primary.atkbuff;
                intl += primary.intlbuff;
                spd += primary.spdbuff;
            }

            if (!secondary.Equals(default(Item)))
            {
                def += secondary.defbuff;
                atk += secondary.atkbuff;
                intl += secondary.intlbuff;
                spd += secondary.spdbuff;
            }

            if (!armor.Equals(default(Item)))
            {
                def += armor.defbuff;
                atk += armor.atkbuff;
                intl += armor.intlbuff;
                spd += armor.spdbuff;
            }
            if (!accessory.Equals(default(Item)))
            {
                def += accessory.defbuff;
                atk += accessory.atkbuff;
                intl += accessory.intlbuff;
                spd += accessory.spdbuff;
            }

        }
        public void applydevbonus()
        {
            if (!primary.Equals(default(Item)))
            {
                def += primary.defbuff;
                atk += primary.atkbuff;
                intl += primary.intlbuff;
                spd += primary.spdbuff;
            }

            if (!secondary.Equals(default(Item)))
            {
                def += secondary.defbuff;
                atk += secondary.atkbuff;
                intl += secondary.intlbuff;
                spd += secondary.spdbuff;
            }

            if (!armor.Equals(default(Item)))
            {
                def += armor.defbuff;
                atk += armor.atkbuff;
                intl += armor.intlbuff;
                spd += armor.spdbuff;
            }
            if (!accessory.Equals(default(Item)))
            {
                def += accessory.defbuff;
                atk += accessory.atkbuff;
                intl += accessory.intlbuff;
                spd += accessory.spdbuff;
            }
        }
        public GamePlayer()
        {
            maxhp = 11;
            hp = 11;
            level = 1;
            xp = 0;
            g = 15;
            def = 1;
            intl = 1;
            backpack = new List<Item>();
            abilities = new Realm.Combat.CommandTable();
            abilities.AddCommand(new Combat.BasicAttack("Basic Attack", 'b'));
        }
    }
}
