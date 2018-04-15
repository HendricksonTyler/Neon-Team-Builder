using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neon_Team_Builder
{
    public partial class Form1 : Form
    {
        const int NORMAL = 0;
        const int FIRE = 1;
        const int WATER = 2;
        const int ELECTRIC = 3;
        const int GRASS = 4;
        const int ICE = 5;
        const int FIGHTING = 6;
        const int POISON = 7;
        const int GROUND = 8;
        const int FLYING = 9;
        const int PSYCHIC = 10;
        const int BUG = 11;
        const int ROCK = 12;
        const int GHOST = 13;
        const int DRAGON = 14;
        const int DARK = 15;
        const int STEEL = 16;

        double natDex = 0;

        Pokemon Poke1 = new Pokemon();
        Pokemon Poke2 = new Pokemon();
        Pokemon Poke3 = new Pokemon();
        Pokemon Poke4 = new Pokemon();
        Pokemon Poke5 = new Pokemon();
        Pokemon Poke6 = new Pokemon();
        DataTable Pokedex;

        public Form1()
        {
            InitializeComponent();
            Pokedex = pokedexDataSet.Pokedex;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pokedexDataSet.Pokedex' table. You can move, or remove it, as needed.
            this.pokedexTableAdapter.Fill(this.pokedexDataSet.Pokedex);

        }

        private void cboPoke1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke1.Text != "")
            {
                // reset all boxes
                rbnPoke1Ability1.Text = "-";
                rbnPoke1Ability1.Visible = false;
                rbnPoke1Ability1.Checked = false;
                rbnPoke1Ability2.Text = "-";
                rbnPoke1Ability2.Visible = false;
                rbnPoke1Ability2.Checked = false;
                rbnPoke1Ability3.Text = "-";
                rbnPoke1Ability3.Visible = false;
                rbnPoke1Ability3.Checked = false;
                cboArceusType1.Visible = false;

                ResetPokeMatchup(Poke1);

                natDex = double.Parse(cboPoke1.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke1.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke1.Position = 1;
                Poke1.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke1.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke1.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke1.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke1.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke1.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke1.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke1.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke1.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke1.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke1.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke1.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke1.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke1.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke1.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke1);
                DetermineTier();
                DetermineTypeMatchup(Poke1);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }

        private void cboPoke2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke2.Text != "")
            {
                // reset all boxes
                rbnPoke2Ability1.Text = "-";
                rbnPoke2Ability1.Visible = false;
                rbnPoke2Ability1.Checked = false;
                rbnPoke2Ability2.Text = "-";
                rbnPoke2Ability2.Visible = false;
                rbnPoke2Ability2.Checked = false;
                rbnPoke2Ability3.Text = "-";
                rbnPoke2Ability3.Visible = false;
                rbnPoke2Ability3.Checked = false;
                cboArceusType2.Visible = false;

                ResetPokeMatchup(Poke2);

                natDex = double.Parse(cboPoke2.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke2.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke2.Position = 2;
                Poke2.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke2.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke2.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke2.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke2.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke2.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke2.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke2.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke2.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke2.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke2.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke2.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke2.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke2.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke2.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke2);
                DetermineTier();
                DetermineTypeMatchup(Poke2);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }

        private void cboPoke3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke3.Text != "")
            {
                // reset all boxes
                rbnPoke3Ability1.Text = "-";
                rbnPoke3Ability1.Visible = false;
                rbnPoke3Ability1.Checked = false;
                rbnPoke3Ability2.Text = "-";
                rbnPoke3Ability2.Visible = false;
                rbnPoke3Ability2.Checked = false;
                rbnPoke3Ability3.Text = "-";
                rbnPoke3Ability3.Visible = false;
                rbnPoke3Ability3.Checked = false;
                cboArceusType3.Visible = false;

                ResetPokeMatchup(Poke3);

                natDex = double.Parse(cboPoke3.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke3.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke3.Position = 3;
                Poke3.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke3.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke3.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke3.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke3.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke3.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke3.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke3.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke3.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke3.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke3.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke3.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke3.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke3.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke3.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke3);
                DetermineTier();
                DetermineTypeMatchup(Poke3);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }

        private void cboPoke4_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke4.Text != "")
            {
                // reset all boxes
                rbnPoke4Ability1.Text = "-";
                rbnPoke4Ability1.Visible = false;
                rbnPoke4Ability1.Checked = false;
                rbnPoke4Ability2.Text = "-";
                rbnPoke4Ability2.Visible = false;
                rbnPoke4Ability2.Checked = false;
                rbnPoke4Ability3.Text = "-";
                rbnPoke4Ability3.Visible = false;
                rbnPoke4Ability3.Checked = false;
                cboArceusType4.Visible = false;

                ResetPokeMatchup(Poke4);

                natDex = double.Parse(cboPoke4.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke4.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke4.Position = 4;
                Poke4.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke4.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke4.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke4.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke4.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke4.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke4.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke4.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke4.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke4.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke4.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke4.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke4.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke4.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke4.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke4);
                DetermineTier();
                DetermineTypeMatchup(Poke4);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }

        private void cboPoke5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke5.Text != "")
            {
                // reset all boxes
                rbnPoke5Ability1.Text = "-";
                rbnPoke5Ability1.Visible = false;
                rbnPoke5Ability1.Checked = false;
                rbnPoke5Ability2.Text = "-";
                rbnPoke5Ability2.Visible = false;
                rbnPoke5Ability2.Checked = false;
                rbnPoke5Ability3.Text = "-";
                rbnPoke5Ability3.Visible = false;
                rbnPoke5Ability3.Checked = false;
                cboArceusType5.Visible = false;

                ResetPokeMatchup(Poke5);

                natDex = double.Parse(cboPoke5.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke5.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke5.Position = 5;
                Poke5.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke5.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke5.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke5.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke5.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke5.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke5.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke5.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke5.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke5.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke5.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke5.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke5.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke5.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke5.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke5);
                DetermineTier();
                DetermineTypeMatchup(Poke5);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }

        private void cboPoke6_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPokemon;

            if (cboPoke6.Text != "")
            {
                // reset all boxes
                rbnPoke6Ability1.Text = "-";
                rbnPoke6Ability1.Visible = false;
                rbnPoke6Ability1.Checked = false;
                rbnPoke6Ability2.Text = "-";
                rbnPoke6Ability2.Visible = false;
                rbnPoke6Ability2.Checked = false;
                rbnPoke6Ability3.Text = "-";
                rbnPoke6Ability3.Visible = false;
                rbnPoke6Ability3.Checked = false;
                cboArceusType6.Visible = false;

                ResetPokeMatchup(Poke6);

                natDex = double.Parse(cboPoke6.SelectedValue.ToString());
                selectedPokemon = ConvertToRow(natDex);

                Poke6.Name = Pokedex.Rows[selectedPokemon]["Pokemon"].ToString();
                Poke6.Position = 6;
                Poke6.DexNo = (int)double.Parse(Pokedex.Rows[selectedPokemon]["Nat"].ToString());

                Poke6.HP = int.Parse(Pokedex.Rows[selectedPokemon]["HP"].ToString());
                Poke6.Atk = int.Parse(Pokedex.Rows[selectedPokemon]["Atk"].ToString());
                Poke6.Def = int.Parse(Pokedex.Rows[selectedPokemon]["Def"].ToString());
                Poke6.SpAtk = int.Parse(Pokedex.Rows[selectedPokemon]["SpA"].ToString());
                Poke6.SpDef = int.Parse(Pokedex.Rows[selectedPokemon]["SpD"].ToString());
                Poke6.Speed = int.Parse(Pokedex.Rows[selectedPokemon]["Spe"].ToString());
                Poke6.Total = int.Parse(Pokedex.Rows[selectedPokemon]["Total"].ToString());

                Poke6.Type1 = Pokedex.Rows[selectedPokemon]["Type I"].ToString();
                Poke6.Type2 = Pokedex.Rows[selectedPokemon]["Type II"].ToString();

                Poke6.Ability1 = Pokedex.Rows[selectedPokemon]["Ability I"].ToString();
                Poke6.Ability2 = Pokedex.Rows[selectedPokemon]["Ability II"].ToString();
                Poke6.HiddenAbility = Pokedex.Rows[selectedPokemon]["Hidden Ability"].ToString();

                Poke6.Tier = Pokedex.Rows[selectedPokemon]["Tier"].ToString();
                Poke6.Matchup = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

                UpdateStats();
                DetermineAbility(Poke6);
                DetermineTier();
                DetermineTypeMatchup(Poke6);
                UpdateTypeMatchup();
                CompetitivePlayTest();
            }
        }


        private void ResetPokeMatchup(Pokemon Pkmn)
        {
            for (int i = 0; i <= 16; i++)
            {
                Pkmn.Matchup[i] = 100;
            }
        }

        private void ResetTypeChart()
        {
            Label[][] typeBox = new Label[17][];

            typeBox[0] = new Label[] { lblNormal0, lblNormal25, lblNormal50, lblNormal100, lblNormal200, lblNormal400 };
            typeBox[1] = new Label[] { lblFire0, lblFire25, lblFire50, lblFire100, lblFire200, lblFire400 };
            typeBox[2] = new Label[] { lblWater0, lblWater25, lblWater50, lblWater100, lblWater200, lblWater400 };
            typeBox[3] = new Label[] { lblElectric0, lblElectric25, lblElectric50, lblElectric100, lblElectric200, lblElectric400 };
            typeBox[4] = new Label[] { lblGrass0, lblGrass25, lblGrass50, lblGrass100, lblGrass200, lblGrass400 };
            typeBox[5] = new Label[] { lblIce0, lblIce25, lblIce50, lblIce100, lblIce200, lblIce400 };
            typeBox[6] = new Label[] { lblFight0, lblFight25, lblFight50, lblFight100, lblFight200, lblFight400 };
            typeBox[7] = new Label[] { lblPoison0, lblPoison25, lblPoison50, lblPoison100, lblPoison200, lblPoison400 };
            typeBox[8] = new Label[] { lblGround0, lblGround25, lblGround50, lblGround100, lblGround200, lblGround400 };
            typeBox[9] = new Label[] { lblFlying0, lblFlying25, lblFlying50, lblFlying100, lblFlying200, lblFlying400 };
            typeBox[10] = new Label[] { lblPsychic0, lblPsychic25, lblPsychic50, lblPsychic100, lblPsychic200, lblPsychic400 };
            typeBox[11] = new Label[] { lblBug0, lblBug25, lblBug50, lblBug100, lblBug200, lblBug400 };
            typeBox[12] = new Label[] { lblRock0, lblRock25, lblRock50, lblRock100, lblRock200, lblRock400 };
            typeBox[13] = new Label[] { lblGhost0, lblGhost25, lblGhost50, lblGhost100, lblGhost200, lblGhost400 };
            typeBox[14] = new Label[] { lblDragon0, lblDragon25, lblDragon50, lblDragon100, lblDragon200, lblDragon400 };
            typeBox[15] = new Label[] { lblDark0, lblDark25, lblDark50, lblDark100, lblDark200, lblDark400 };
            typeBox[16] = new Label[] { lblSteel0, lblSteel25, lblSteel50, lblSteel100, lblSteel200, lblSteel400 };

            for (int type = 0; type <= 16; type++)
            {
                for (int element = 0; element <= 5; element++)
                {
                    typeBox[type][element].Text = "-";
                    typeBox[type][element].ForeColor = SystemColors.ControlLight;
                    typeBox[type][element].Image = null;
                    typeBox[type][element].BackColor = SystemColors.ControlDarkDark;
                }
            }
        }

        private int ConvertToRow(double natDex)
        {
            int rowNo = (int)natDex - 1;

            if (natDex > 386)
            {
                rowNo++;

                if (natDex > 386.1)
                {
                    rowNo++;

                    if (natDex > 386.2)
                    {
                        rowNo++;

                        if (natDex > 413)
                        {
                            rowNo++;

                            if (natDex > 413.1)
                            {
                                rowNo++;

                                if (natDex > 479)
                                {
                                    rowNo++;

                                    if (natDex > 479.1)
                                    {
                                        rowNo++;

                                        if (natDex > 479.2)
                                        {
                                            rowNo++;

                                            if (natDex > 479.3)
                                            {
                                                rowNo++;

                                                if (natDex > 479.4)
                                                {
                                                    rowNo++;

                                                    if (natDex > 487)
                                                    {
                                                        rowNo++;

                                                        if (natDex > 492)
                                                        {
                                                            rowNo++;

                                                            if (natDex > 550)
                                                            {
                                                                rowNo++;

                                                                if (natDex > 555)
                                                                {
                                                                    rowNo++;

                                                                    if (natDex > 641)
                                                                    {
                                                                        rowNo++;

                                                                        if (natDex > 642)
                                                                        {
                                                                            rowNo++;

                                                                            if (natDex > 645)
                                                                            {
                                                                                rowNo++;

                                                                                if (natDex > 646)
                                                                                {
                                                                                    rowNo++;

                                                                                    if (natDex > 646.1)
                                                                                    {
                                                                                        rowNo++;

                                                                                        if (natDex > 648)
                                                                                        {
                                                                                            rowNo++;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return rowNo;
        }

        private void UpdateStats()
        {
            lblHP.Text = (Poke1.HP + Poke2.HP + Poke3.HP + Poke4.HP + Poke5.HP + Poke6.HP).ToString();
            lblAtk.Text = (Poke1.Atk + Poke2.Atk + Poke3.Atk + Poke4.Atk + Poke5.Atk + Poke6.Atk).ToString();
            lblDef.Text = (Poke1.Def + Poke2.Def + Poke3.Def + Poke4.Def + Poke5.Def + Poke6.Def).ToString();
            lblSpAtk.Text = (Poke1.SpAtk + Poke2.SpAtk + Poke3.SpAtk + Poke4.SpAtk + Poke5.SpAtk + Poke6.SpAtk).ToString();
            lblSpDef.Text = (Poke1.SpDef + Poke2.SpDef + Poke3.SpDef + Poke4.SpDef + Poke5.SpDef + Poke6.SpDef).ToString();
            lblSpeed.Text = (Poke1.Speed + Poke2.Speed + Poke3.Speed + Poke4.Speed + Poke5.Speed + Poke6.Speed).ToString();
            lblTotal.Text = (Poke1.Total + Poke2.Total + Poke3.Total + Poke4.Total + Poke5.Total + Poke6.Total).ToString();
        }

        private void UpdateTypeMatchup()
        {
            ResetTypeChart();

            Label[][] typeBox = new Label[17][];

            typeBox[0] = new Label[] { lblNormal0, lblNormal25, lblNormal50, lblNormal100, lblNormal200, lblNormal400 };
            typeBox[1] = new Label[] { lblFire0, lblFire25, lblFire50, lblFire100, lblFire200, lblFire400 };
            typeBox[2] = new Label[] { lblWater0, lblWater25, lblWater50, lblWater100, lblWater200, lblWater400 };
            typeBox[3] = new Label[] { lblElectric0, lblElectric25, lblElectric50, lblElectric100, lblElectric200, lblElectric400 };
            typeBox[4] = new Label[] { lblGrass0, lblGrass25, lblGrass50, lblGrass100, lblGrass200, lblGrass400 };
            typeBox[5] = new Label[] { lblIce0, lblIce25, lblIce50, lblIce100, lblIce200, lblIce400 };
            typeBox[6] = new Label[] { lblFight0, lblFight25, lblFight50, lblFight100, lblFight200, lblFight400 };
            typeBox[7] = new Label[] { lblPoison0, lblPoison25, lblPoison50, lblPoison100, lblPoison200, lblPoison400 };
            typeBox[8] = new Label[] { lblGround0, lblGround25, lblGround50, lblGround100, lblGround200, lblGround400 };
            typeBox[9] = new Label[] { lblFlying0, lblFlying25, lblFlying50, lblFlying100, lblFlying200, lblFlying400 };
            typeBox[10] = new Label[] { lblPsychic0, lblPsychic25, lblPsychic50, lblPsychic100, lblPsychic200, lblPsychic400 };
            typeBox[11] = new Label[] { lblBug0, lblBug25, lblBug50, lblBug100, lblBug200, lblBug400 };
            typeBox[12] = new Label[] { lblRock0, lblRock25, lblRock50, lblRock100, lblRock200, lblRock400 };
            typeBox[13] = new Label[] { lblGhost0, lblGhost25, lblGhost50, lblGhost100, lblGhost200, lblGhost400 };
            typeBox[14] = new Label[] { lblDragon0, lblDragon25, lblDragon50, lblDragon100, lblDragon200, lblDragon400 };
            typeBox[15] = new Label[] { lblDark0, lblDark25, lblDark50, lblDark100, lblDark200, lblDark400 };
            typeBox[16] = new Label[] { lblSteel0, lblSteel25, lblSteel50, lblSteel100, lblSteel200, lblSteel400 };

            var pkmn = new[] { Poke1, Poke2, Poke3, Poke4, Poke5, Poke6 };

            // goes through every type
            for (int type = 0; type <= 16; type++)
            {
                // goes through every pokemon
                for (int pokemonNo = 0; pokemonNo < pkmn.Length; pokemonNo++)
                {
                    // determines whether to increment label value
                    if (pkmn[pokemonNo].Matchup[type] == 0)
                    {
                        if (typeBox[type][0].Text == "-")
                        {
                            typeBox[type][0].Text = "1";
                        }

                        else
                        {
                            typeBox[type][0].Text = (int.Parse(typeBox[type][0].Text) + 1).ToString();
                        }
                    }

                    else if (pkmn[pokemonNo].Matchup[type] == 25)
                    {
                        if (typeBox[type][1].Text == "-")
                        {
                            typeBox[type][1].Text = "1";
                        }

                        else
                        {
                            typeBox[type][1].Text = (int.Parse(typeBox[type][1].Text) + 1).ToString();
                        }
                    }

                    else if (pkmn[pokemonNo].Matchup[type] == 50)
                    {
                        if (typeBox[type][2].Text == "-")
                        {
                            typeBox[type][2].Text = "1";
                        }

                        else
                        {
                            typeBox[type][2].Text = (int.Parse(typeBox[type][2].Text) + 1).ToString();
                        }
                    }

                    else if (pkmn[pokemonNo].Matchup[type] == 100)
                    {
                        if (typeBox[type][3].Text == "-")
                        {
                            typeBox[type][3].Text = "1";
                        }

                        else
                        {
                            typeBox[type][3].Text = (int.Parse(typeBox[type][3].Text) + 1).ToString();
                        }
                    }

                    else if (pkmn[pokemonNo].Matchup[type] == 200)
                    {
                        if (typeBox[type][4].Text == "-")
                        {
                            typeBox[type][4].Text = "1";
                        }

                        else
                        {
                            typeBox[type][4].Text = (int.Parse(typeBox[type][4].Text) + 1).ToString();
                        }
                    }

                    else if (pkmn[pokemonNo].Matchup[type] == 400)
                    {
                        if (typeBox[type][5].Text == "-")
                        {
                            typeBox[type][5].Text = "1";
                        }

                        else
                        {
                            typeBox[type][5].Text = (int.Parse(typeBox[type][5].Text) + 1).ToString();
                        }
                    }
                }
            }

            int pokemonUsed = 0;

            // determines how many pokemon are selected
            if (typeBox[NORMAL][0].Text != "-")
                pokemonUsed += int.Parse(typeBox[NORMAL][0].Text);

            if (typeBox[NORMAL][1].Text != "-")
                pokemonUsed += int.Parse(typeBox[NORMAL][1].Text);

            if (typeBox[NORMAL][2].Text != "-")
                pokemonUsed += int.Parse(typeBox[NORMAL][2].Text);

            if (typeBox[NORMAL][3].Text != "-")
                pokemonUsed += int.Parse(typeBox[NORMAL][3].Text);


            for (int type = 0; type <= 16; type++)
            {
                // goes through each box number and adjusts color based on the value contained
                for (int boxNo = 0; boxNo <= 5; boxNo++)
                {
                    int thisBox = 0;
                    double thisPercentage = 0;

                    // reads in text from active box
                    if (typeBox[type][boxNo].Text != "-")
                    {
                        thisBox = int.Parse(typeBox[type][boxNo].Text);

                        thisPercentage = (double)thisBox / (double)pokemonUsed;
                    }

                    // not very effective GREEN
                    if (boxNo == 0 || boxNo == 1 || boxNo == 2)
                    {
                        if (boxNo == 0 && thisBox > 0)
                        {
                            typeBox[type][0].Image = NeonTeamBuilder.Properties.Resources.BrightGreen;
                            typeBox[type][0].ForeColor = Color.Black;
                        }

                        if (boxNo != 0)
                        {
                            if (thisPercentage >= .50)
                            {
                                typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.BrightGreen;
                                typeBox[type][boxNo].ForeColor = Color.Black;
                            }

                            else if (thisPercentage >= .33)
                            {
                                typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.MediumGreen;
                                typeBox[type][boxNo].ForeColor = Color.Black;
                            }

                            else if (thisPercentage >= .1)
                            {
                                typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.DarkGreen;
                                typeBox[type][boxNo].ForeColor = Color.Black;
                            }
                        }
                    }

                    // normal effective
                    else if (boxNo == 3)
                    {
                        if (thisBox > 0)
                        {
                            typeBox[type][boxNo].BackColor = SystemColors.AppWorkspace;
                        }
                    }


                    // super effective RED
                    else if (boxNo == 4 || boxNo == 5)
                    {
                        if (thisPercentage >= .50)
                        {
                            typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.BrightRed;
                            typeBox[type][boxNo].ForeColor = Color.Black;
                        }

                        else if (thisPercentage >= .33)
                        {
                            typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.MediumRed;
                            typeBox[type][boxNo].ForeColor = Color.Black;
                        }

                        else if (thisPercentage >= .01)
                        {
                            typeBox[type][boxNo].Image = NeonTeamBuilder.Properties.Resources.DarkRed;
                            typeBox[type][boxNo].ForeColor = Color.Black;
                        }
                    }
                }

            }
        }

        private void DetermineAbility(Pokemon Pkmn)
        {
            var modAbilities = new[] { "Flash Fire", "Levitate", "Water Absorb", "Motor Drive", "Lightningrod", "Pure Power", "Huge Power", "Wonder Guard", "Storm Drain", "Thick Fat", "Hustle", "Sap Sipper", "Heat Proof" };
            RadioButton[] abilityButton = new RadioButton[] { rbnPoke6Ability3 };

            if (Pkmn.Position == 1)
            {
                abilityButton = new[] { rbnPoke1Ability1, rbnPoke1Ability2, rbnPoke1Ability3 };
            }

            else if (Pkmn.Position == 2)
            {
                abilityButton = new[] { rbnPoke2Ability1, rbnPoke2Ability2, rbnPoke2Ability3 };
            }

            else if (Pkmn.Position == 3)
            {
                abilityButton = new[] { rbnPoke3Ability1, rbnPoke3Ability2, rbnPoke3Ability3 };
            }

            else if (Pkmn.Position == 4)
            {
                abilityButton = new[] { rbnPoke4Ability1, rbnPoke4Ability2, rbnPoke4Ability3 };
            }

            else if (Pkmn.Position == 5)
            {
                abilityButton = new[] { rbnPoke5Ability1, rbnPoke5Ability2, rbnPoke5Ability3 };
            }

            else if (Pkmn.Position == 6)
            {
                abilityButton = new[] { rbnPoke6Ability1, rbnPoke6Ability2, rbnPoke6Ability3 };
            }


            if (modAbilities.Any(x => x == Pkmn.Ability1))
            {
                abilityButton[0].Text = Pkmn.Ability1;
                abilityButton[0].Visible = true;
            }

            if (modAbilities.Any(x => x == Pkmn.Ability2))
            {
                if (abilityButton[0].Text == "-")
                {
                    abilityButton[0].Text = Pkmn.Ability2;
                    abilityButton[0].Visible = true;
                }

                else
                {
                    abilityButton[1].Text = Pkmn.Ability2;
                    abilityButton[1].Visible = true;
                }
            }

            if (modAbilities.Any(x => x == Pkmn.HiddenAbility))
            {
                if (abilityButton[0].Text == "-")
                {
                    abilityButton[0].Text = Pkmn.HiddenAbility;
                    abilityButton[0].Visible = true;
                }

                else if (abilityButton[1].Text == "-")
                {
                    abilityButton[1].Text = Pkmn.HiddenAbility;
                    abilityButton[1].Visible = true;
                }

                else
                {
                    abilityButton[2].Text = Pkmn.HiddenAbility;
                    abilityButton[2].Visible = true;
                }
            }

            if (Pkmn.Ability1 == "Multitype")
            {
                abilityButton[0].Text = Pkmn.Ability1;
                abilityButton[0].Visible = true;
            }
        }

        private void DetermineTypeMatchup(Pokemon Pkmn)
        {
            var pokeType = new[] { Pkmn.Type1, Pkmn.Type2 };

            for (int i = 0; i <= 1; i++)
            {
                // normal attacks
                if (pokeType[i] == "Rock" || pokeType[i] == "Steel")
                {
                    Pkmn.Matchup[NORMAL] /= 2;
                }

                else if (pokeType[i] == "Ghost")
                {
                    Pkmn.Matchup[NORMAL] *= 0;
                }

                // fire attacks
                if (pokeType[i] == "Grass" || pokeType[i] == "Steel" || pokeType[i] == "Bug" || pokeType[i] == "Ice")
                {
                    Pkmn.Matchup[FIRE] *= 2;
                }

                else if (pokeType[i] == "Rock" || pokeType[i] == "Fire" || pokeType[i] == "Water" || pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[FIRE] /= 2;
                }

                // water attacks
                if (pokeType[i] == "Rock" || pokeType[i] == "Fire" || pokeType[i] == "Ground")
                {
                    Pkmn.Matchup[WATER] *= 2;
                }

                else if (pokeType[i] == "Water" || pokeType[i] == "Grass" || pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[WATER] /= 2;
                }

                // electric attacks
                if (pokeType[i] == "Water" || pokeType[i] == "Flying")
                {
                    Pkmn.Matchup[ELECTRIC] *= 2;
                }

                else if (pokeType[i] == "Grass" || pokeType[i] == "Electric" || pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[ELECTRIC] /= 2;
                }

                else if (pokeType[i] == "Ground")
                {
                    Pkmn.Matchup[ELECTRIC] *= 0;
                }

                // grass attacks
                if (pokeType[i] == "Rock" || pokeType[i] == "Water" || pokeType[i] == "Ground")
                {
                    Pkmn.Matchup[GRASS] *= 2;
                }

                else if (pokeType[i] == "Flying" || pokeType[i] == "Poison" || pokeType[i] == "Bug" || pokeType[i] == "Steel" || pokeType[i] == "Fire" || pokeType[i] == "Grass" || pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[GRASS] /= 2;
                }

                // ice attacks
                if (pokeType[i] == "Flying" || pokeType[i] == "Ground" || pokeType[i] == "Grass" || pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[ICE] *= 2;
                }

                else if (pokeType[i] == "Steel" || pokeType[i] == "Fire" || pokeType[i] == "Water" || pokeType[i] == "Ice")
                {
                    Pkmn.Matchup[ICE] /= 2;
                }

                // fighting attacks
                if (pokeType[i] == "Normal" || pokeType[i] == "Rock" || pokeType[i] == "Steel" || pokeType[i] == "Dark" || pokeType[i] == "Ice")
                {
                    Pkmn.Matchup[FIGHTING] *= 2;
                }

                else if (pokeType[i] == "Flying" || pokeType[i] == "Poison" || pokeType[i] == "Bug" || pokeType[i] == "Psychic")
                {
                    Pkmn.Matchup[FIGHTING] /= 2;
                }

                if (pokeType[i] == "Ghost")
                {
                    Pkmn.Matchup[FIGHTING] *= 0;
                }

                // poison attacks
                if (pokeType[i] == "Grass")
                {
                    Pkmn.Matchup[POISON] *= 2;
                }

                else if (pokeType[i] == "Poison" || pokeType[i] == "Ground" || pokeType[i] == "Rock" || pokeType[i] == "Ghost")
                {
                    Pkmn.Matchup[POISON] /= 2;
                }

                else if (pokeType[i] == "Steel")
                {
                    Pkmn.Matchup[POISON] *= 0;
                }

                // ground attacks
                if (pokeType[i] == "Poison" || pokeType[i] == "Rock" || pokeType[i] == "Steel" || pokeType[i] == "Fire" || pokeType[i] == "Electric")
                {
                    Pkmn.Matchup[GROUND] *= 2;
                }

                else if (pokeType[i] == "Bug" || pokeType[i] == "Grass")
                {
                    Pkmn.Matchup[GROUND] /= 2;
                }

                else if (pokeType[i] == "Flying")
                {
                    Pkmn.Matchup[GROUND] *= 0;
                }

                // flying attacks
                if (pokeType[i] == "Fighting" || pokeType[i] == "Bug" || pokeType[i] == "Grass")
                {
                    Pkmn.Matchup[FLYING] *= 2;
                }

                else if (pokeType[i] == "Rock" || pokeType[i] == "Steel" || pokeType[i] == "Electric")
                {
                    Pkmn.Matchup[FLYING] /= 2;
                }

                // psychic attacks
                if (pokeType[i] == "Fighting" || pokeType[i] == "Poison")
                {
                    Pkmn.Matchup[PSYCHIC] *= 2;
                }

                else if (pokeType[i] == "Steel" || pokeType[i] == "Psychic")
                {
                    Pkmn.Matchup[PSYCHIC] /= 2;
                }

                else if (pokeType[i] == "Dark")
                {
                    Pkmn.Matchup[PSYCHIC] *= 0;
                }

                // bug attacks
                if (pokeType[i] == "Grass" || pokeType[i] == "Psychic" || pokeType[i] == "Dark")
                {
                    Pkmn.Matchup[BUG] *= 2;
                }

                else if (pokeType[i] == "Fighting" || pokeType[i] == "Flying" || pokeType[i] == "Poison" || pokeType[i] == "Ghost" || pokeType[i] == "Steel" || pokeType[i] == "Fire")
                {
                    Pkmn.Matchup[BUG] /= 2;
                }

                // rock attacks
                if (pokeType[i] == "Flying" || pokeType[i] == "Bug" || pokeType[i] == "Fire" || pokeType[i] == "Ice")
                {
                    Pkmn.Matchup[ROCK] *= 2;
                }

                else if (pokeType[i] == "Fighting" || pokeType[i] == "Ground" || pokeType[i] == "Steel")
                {
                    Pkmn.Matchup[ROCK] /= 2;
                }

                // ghost attacks
                if (pokeType[i] == "Ghost" || pokeType[i] == "Psychic")
                {
                    Pkmn.Matchup[GHOST] *= 2;
                }

                else if (pokeType[i] == "Steel" || pokeType[i] == "Dark")
                {
                    Pkmn.Matchup[GHOST] /= 2;
                }

                else if (pokeType[i] == "Normal")
                {
                    Pkmn.Matchup[GHOST] *= 0;
                }

                // dragon attacks
                if (pokeType[i] == "Dragon")
                {
                    Pkmn.Matchup[DRAGON] *= 2;
                }

                else if (pokeType[i] == "Steel")
                {
                    Pkmn.Matchup[DRAGON] /= 2;
                }

                // dark attacks
                if (pokeType[i] == "Ghost" || pokeType[i] == "Psychic")
                {
                    Pkmn.Matchup[DARK] *= 2;
                }

                else if (pokeType[i] == "Fighting" || pokeType[i] == "Steel" || pokeType[i] == "Dark")
                {
                    Pkmn.Matchup[DARK] /= 2;
                }

                // steel attacks
                if (pokeType[i] == "Rock" || pokeType[i] == "Ice")
                {
                    Pkmn.Matchup[STEEL] *= 2;
                }

                else if (pokeType[i] == "Steel" || pokeType[i] == "Fire" || pokeType[i] == "Water" || pokeType[i] == "Electric")
                {
                    Pkmn.Matchup[STEEL] /= 2;
                }
            }
        }

        private void DetermineTier()
        {
            if (Poke1.Tier == "Uber" || Poke2.Tier == "Uber" || Poke3.Tier == "Uber" || Poke4.Tier == "Uber" || Poke5.Tier == "Uber" || Poke6.Tier == "Uber")
            {
                lblTier.Text = "Uber";
            }

            else if (Poke1.Tier == "OU" || Poke2.Tier == "OU" || Poke3.Tier == "OU" || Poke4.Tier == "OU" || Poke5.Tier == "OU" || Poke6.Tier == "OU")
            {
                lblTier.Text = "OU";
            }

            else if (Poke1.Tier == "BL" || Poke2.Tier == "BL" || Poke3.Tier == "BL" || Poke4.Tier == "BL" || Poke5.Tier == "BL" || Poke6.Tier == "BL")
            {
                lblTier.Text = "BL";
            }

            else if (Poke1.Tier == "UU" || Poke2.Tier == "UU" || Poke3.Tier == "UU" || Poke4.Tier == "UU" || Poke5.Tier == "UU" || Poke6.Tier == "UU")
            {
                lblTier.Text = "UU";
            }

            else if (Poke1.Tier == "BL2" || Poke2.Tier == "BL2" || Poke3.Tier == "BL2" || Poke4.Tier == "BL2" || Poke5.Tier == "BL2" || Poke6.Tier == "BL2")
            {
                lblTier.Text = "BL2";
            }

            else if (Poke1.Tier == "RU" || Poke2.Tier == "RU" || Poke3.Tier == "RU" || Poke4.Tier == "RU" || Poke5.Tier == "RU" || Poke6.Tier == "RU")
            {
                lblTier.Text = "RU";
            }

            else if (Poke1.Tier == "NU" || Poke2.Tier == "NU" || Poke3.Tier == "NU" || Poke4.Tier == "NU" || Poke5.Tier == "NU" || Poke6.Tier == "NU")
            {
                lblTier.Text = "NU";
            }

            else if (Poke1.Tier == "LC" || Poke2.Tier == "LC" || Poke3.Tier == "LC" || Poke4.Tier == "LC" || Poke5.Tier == "LC" || Poke6.Tier == "LC")
            {
                lblTier.Text = "LC";
            }

            else
            {
                lblTier.Text = "NFE";
            }
        }

        private void CompetitivePlayTest()
        {
            bool usable = true;

            var legendaries = new[] { 150, 151, 249, 250, 251, 382, 383, 384, 385, 386, 483, 484, 487, 489, 490, 491, 492, 493, 494, 643, 644, 646, 647, 648, 649 };

            // no legendaries
            if (legendaries.Any(x => x == Poke1.DexNo || x == Poke2.DexNo || x == Poke3.DexNo || x == Poke4.DexNo || x == Poke5.DexNo || x == Poke6.DexNo))
            {
                usable = false;
            }

            // no duplicates
            if (Poke1.DexNo == Poke2.DexNo || Poke1.DexNo == Poke3.DexNo || Poke1.DexNo == Poke4.DexNo || Poke1.DexNo == Poke5.DexNo || Poke1.DexNo == Poke6.DexNo)
            {
                usable = false;
            }

            else if (Poke2.DexNo == Poke1.DexNo || Poke2.DexNo == Poke3.DexNo || Poke2.DexNo == Poke4.DexNo || Poke2.DexNo == Poke5.DexNo || Poke2.DexNo == Poke6.DexNo)
            {
                usable = false;
            }

            else if (Poke3.DexNo == Poke1.DexNo || Poke3.DexNo == Poke2.DexNo || Poke3.DexNo == Poke4.DexNo || Poke3.DexNo == Poke5.DexNo || Poke3.DexNo == Poke6.DexNo)
            {
                usable = false;
            }

            else if (Poke4.DexNo == Poke1.DexNo || Poke4.DexNo == Poke2.DexNo || Poke4.DexNo == Poke3.DexNo || Poke4.DexNo == Poke5.DexNo || Poke4.DexNo == Poke6.DexNo)
            {
                usable = false;
            }

            else if (Poke5.DexNo == Poke1.DexNo || Poke5.DexNo == Poke2.DexNo || Poke5.DexNo == Poke3.DexNo || Poke5.DexNo == Poke4.DexNo || Poke5.DexNo == Poke6.DexNo)
            {
                usable = false;
            }

            else if (Poke6.DexNo == Poke1.DexNo || Poke6.DexNo == Poke2.DexNo || Poke6.DexNo == Poke3.DexNo || Poke6.DexNo == Poke4.DexNo || Poke6.DexNo == Poke5.DexNo)
            {
                usable = false;
            }


            // display
            if (usable == true)
            {
                lblUsable.Text = "Yes";
            }

            else if (usable == false)
            {
                lblUsable.Text = "No";
            }
        }

        private void AbilityStatChange(Pokemon Pkmn)
        {
            if (Pkmn.SelectedAbility == "Pure Power" || Pkmn.SelectedAbility == "Huge Power")
            {
                Pkmn.Atk *= 2;
            }

            else if (Pkmn.SelectedAbility == "Hustle")
            {
                Pkmn.Atk += (Pkmn.Atk / 2);
            }
        }

        private void AbilityTypeChange(Pokemon Pkmn)
        {
            if (Pkmn.SelectedAbility == "Flash Fire")
            {
                Pkmn.Matchup[FIRE] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Levitate")
            {
                Pkmn.Matchup[GROUND] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Water Absorb")
            {
                Pkmn.Matchup[WATER] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Motor Drive")
            {
                Pkmn.Matchup[ELECTRIC] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Lightningrod")
            {
                Pkmn.Matchup[ELECTRIC] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Wonder Guard")
            {
                Pkmn.Matchup[NORMAL] *= 0;
                Pkmn.Matchup[WATER] *= 0;
                Pkmn.Matchup[ELECTRIC] *= 0;
                Pkmn.Matchup[GRASS] *= 0;
                Pkmn.Matchup[ICE] *= 0;
                Pkmn.Matchup[FIGHTING] *= 0;
                Pkmn.Matchup[POISON] *= 0;
                Pkmn.Matchup[GROUND] *= 0;
                Pkmn.Matchup[PSYCHIC] *= 0;
                Pkmn.Matchup[BUG] *= 0;
                Pkmn.Matchup[DRAGON] *= 0;
                Pkmn.Matchup[STEEL] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Storm Drain")
            {
                Pkmn.Matchup[WATER] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Thick Fat")
            {
                Pkmn.Matchup[FIRE] /= 2;
                Pkmn.Matchup[ICE] /= 2;
            }

            else if (Pkmn.SelectedAbility == "Sap Sipper")
            {
                Pkmn.Matchup[GRASS] *= 0;
            }

            else if (Pkmn.SelectedAbility == "Heat Proof")
            {
                Pkmn.Matchup[ELECTRIC] /= 2;
            }
        }

        private void rbnPoke1Ability1_CheckedChanged(object sender, EventArgs e)
        {
            Poke1.SelectedAbility = rbnPoke1Ability1.Text;

            if (Poke1.SelectedAbility == "Multitype")
            {
                rbnPoke1Ability1.Visible = false;
                cboArceusType1.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke1);
                UpdateStats();
                AbilityTypeChange(Poke1);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke1Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke1.SelectedAbility = rbnPoke1Ability2.Text;

            AbilityStatChange(Poke1);
            UpdateStats();
        }

        private void rbnPoke1Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke1.SelectedAbility = rbnPoke1Ability3.Text;

            AbilityStatChange(Poke1);
            UpdateStats();
        }

        private void rbnPoke2Ability1_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke2.SelectedAbility = rbnPoke2Ability1.Text;

            if (Poke2.SelectedAbility == "Multitype")
            {
                rbnPoke2Ability1.Visible = false;
                cboArceusType2.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke2);
                UpdateStats();
                AbilityTypeChange(Poke2);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke2Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke2.SelectedAbility = rbnPoke2Ability2.Text;

            AbilityStatChange(Poke2);
            UpdateStats();
        }

        private void rbnPoke2Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke2.SelectedAbility = rbnPoke2Ability3.Text;

            AbilityStatChange(Poke2);
            UpdateStats();
        }

        private void rbnPoke3Ability1_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke3.SelectedAbility = rbnPoke3Ability1.Text;

            if (Poke3.SelectedAbility == "Multitype")
            {
                rbnPoke3Ability1.Visible = false;
                cboArceusType3.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke3);
                UpdateStats();
                AbilityTypeChange(Poke3);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke3Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke3.SelectedAbility = rbnPoke3Ability2.Text;

            AbilityStatChange(Poke3);
            UpdateStats();
        }

        private void rbnPoke3Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke3.SelectedAbility = rbnPoke3Ability3.Text;

            AbilityStatChange(Poke3);
            UpdateStats();
        }

        private void rbnPoke4Ability1_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke4.SelectedAbility = rbnPoke4Ability1.Text;

            if (Poke4.SelectedAbility == "Multitype")
            {
                rbnPoke4Ability1.Visible = false;
                cboArceusType4.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke4);
                UpdateStats();
                AbilityTypeChange(Poke4);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke4Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke4.SelectedAbility = rbnPoke4Ability2.Text;

            AbilityStatChange(Poke4);
            UpdateStats();
        }

        private void rbnPoke4Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke4.SelectedAbility = rbnPoke4Ability3.Text;

            AbilityStatChange(Poke4);
            UpdateStats();
        }

        private void rbnPoke5Ability1_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke5.SelectedAbility = rbnPoke5Ability1.Text;

            if (Poke5.SelectedAbility == "Multitype")
            {
                rbnPoke5Ability1.Visible = false;
                cboArceusType5.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke5);
                UpdateStats();
                AbilityTypeChange(Poke5);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke5Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke5.SelectedAbility = rbnPoke5Ability2.Text;

            AbilityStatChange(Poke5);
            UpdateStats();
        }

        private void rbnPoke5Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke5.SelectedAbility = rbnPoke5Ability3.Text;

            AbilityStatChange(Poke5);
            UpdateStats();
        }

        private void rbnPoke6Ability1_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke6.SelectedAbility = rbnPoke6Ability1.Text;

            if (Poke6.SelectedAbility == "Multitype")
            {
                rbnPoke6Ability1.Visible = false;
                cboArceusType6.Visible = true;
            }

            else
            {
                AbilityStatChange(Poke6);
                UpdateStats();
                AbilityTypeChange(Poke6);
                ResetTypeChart();
                UpdateTypeMatchup();
            }
        }

        private void rbnPoke6Ability2_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke6.SelectedAbility = rbnPoke6Ability2.Text;

            AbilityStatChange(Poke6);
            UpdateStats();
        }

        private void rbnPoke6Ability3_CheckedChanged_1(object sender, EventArgs e)
        {
            Poke6.SelectedAbility = rbnPoke6Ability3.Text;

            AbilityStatChange(Poke6);
            UpdateStats();
        }

        private void cboArceusType1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke1);
            Poke1.Type1 = cboArceusType1.Text;
            DetermineTypeMatchup(Poke1);
            UpdateTypeMatchup();
        }

        private void cboArceusType2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke2);
            Poke2.Type1 = cboArceusType2.Text;
            DetermineTypeMatchup(Poke2);
            UpdateTypeMatchup();
        }

        private void cboArceusType3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke3);
            Poke3.Type1 = cboArceusType3.Text;
            DetermineTypeMatchup(Poke3);
            UpdateTypeMatchup();
        }

        private void cboArceusType4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke4);
            Poke4.Type1 = cboArceusType4.Text;
            DetermineTypeMatchup(Poke4);
            UpdateTypeMatchup();
        }

        private void cboArceusType5_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke5);
            Poke5.Type1 = cboArceusType5.Text;
            DetermineTypeMatchup(Poke5);
            UpdateTypeMatchup();
        }

        private void cboArceusType6_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetPokeMatchup(Poke6);
            Poke6.Type1 = cboArceusType6.Text;
            DetermineTypeMatchup(Poke6);
            UpdateTypeMatchup();
        }
    }
}
