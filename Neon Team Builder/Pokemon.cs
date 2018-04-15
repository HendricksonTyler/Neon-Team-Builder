using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace Neon_Team_Builder
{
    class Pokemon
    {
        private string name;
        private int position;
        private int dexNo;

        private int hp;
        private int atk;
        private int def;
        private int spAtk;
        private int spDef;
        private int speed;
        private int total;

        private string type1;
        private string type2;

        private string ability1;
        private string ability2;
        private string hiddenAbility;
        private string selectedAbility;

        private string tier;
        private int[] matchup;



        public Pokemon()
        {
            name = "";
            position = 0;
            dexNo = 0;

            hp = 0;
            atk = 0;
            def = 0;
            spAtk = 0;
            spDef = 0;
            speed = 0;
            total = 0;
            type1 = "";
            type2 = "";
            ability1 = "";
            ability2 = "";

            hiddenAbility = "";
            selectedAbility = "";
            tier = "";
            matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };
    }

        public string Name
        { 
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int Position
        { 
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public int DexNo
        { 
            get
            {
                return dexNo;
            }

            set
            {
                dexNo = value;
            }
        }

        public int HP
        { 
            get
            {
                return hp;
            }

            set
            {
                hp = value;
            }
        }

        public int Atk
        { 
            get
            {
                return atk;
            }

            set
            {
                atk = value;
            }
        }

        public int Def
        {
            get
            {
                return def;
            }

            set
            {
                def = value;
            }
        }

        public int SpAtk
        {
            get
            {
                return spAtk;
            }

            set
            {
                spAtk = value;
            }
        }

        public int SpDef
        {
            get
            {
                return spDef;
            }

            set
            {
                spDef = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }

            set
            {
                speed = value;
            }
        }

        public int Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public string Type1
        {
            get
            {
                return type1;
            }

            set
            {
                type1 = value;
            }
        }

        public string Type2
        {
            get
            {
                return type2;
            }

            set
            {
                type2 = value;
            }
        }

        public string Ability1
        {
            get
            {
                return ability1;
            }

            set
            {
                ability1 = value;
            }
        }

        public string Ability2
        {
            get
            {
                return ability2;
            }

            set
            {
                ability2 = value;
            }
        }

        public string HiddenAbility
        {
            get
            {
                return hiddenAbility;
            }

            set
            {
                hiddenAbility = value;
            }
        }

        public string SelectedAbility
        {
            get
            {
                return selectedAbility;
            }

            set
            {
                selectedAbility = value;
            }
        }

        public string Tier
        {
            get
            {
                return tier;
            }

            set
            {
                tier = value;
            }
        }

        public int[] Matchup
        {
            get
            {
                return matchup;
            }

            set
            {
                matchup = value;
            }
        }
    }
}
