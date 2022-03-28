using Minecraft_Achievements.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minecraft_Achievements
{
    public partial class AchievementsForm : Form
    {
        private Form1 parentForm;
        List<Achievement> allAchievements;
        bool ShowCompleted = true;
        public AchievementsForm(Form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
            CreateLists cl = new CreateLists();
            allAchievements = cl.AddAchievements();

        }
        private void addAll()
        {
            clearTables();
            int minecraftRow = 1;
            int netherRow = 1;
            int endRow = 1;
            int adventureRow = 1;
            int husbandryRow = 1;


            foreach (Achievement a in allAchievements)
            {
                
                if (ShowCompleted || (!ShowCompleted && !a.Completed)){
                    



                    if (a.Type == "story")
                    {
                        minecraftTable.Controls.Add(a.nameLabel, 0, minecraftRow);
                        minecraftTable.Controls.Add(a.descriptionLabel, 1, minecraftRow);

                        if (a.MultiStep)
                        {
                            TableLayoutPanel tb = new TableLayoutPanel();
                            tb.AutoScroll = true;
                            tb.BackColor = Color.Transparent;
                            for (int i = 0; i < a.ItemsNeeded.Count; i++)
                            {
                                tb.Controls.Add(a.ItemsNeeded[i]);
                            }
                            minecraftTable.Controls.Add(tb,2, minecraftRow);
                        }
                        else
                        {
                            minecraftTable.Controls.Add(a.Item, 2, minecraftRow);
                        }
                        minecraftTable.Controls.Add(a.progressBar, 3, minecraftRow);
                        minecraftRow++;
                    }
                    else if (a.Type == "nether")
                    {
                        
                        netherTable.Controls.Add(a.nameLabel, 0, netherRow);
                        
                        netherTable.Controls.Add(a.descriptionLabel, 1, netherRow);

                        if (a.MultiStep)
                        {
                            TableLayoutPanel tb = new TableLayoutPanel();
                            tb.AutoScroll = true;
                            tb.BackColor = Color.Transparent;
                            for (int i = 0; i < a.ItemsNeeded.Count; i++)
                            {
                                tb.Controls.Add(a.ItemsNeeded[i]);
                            }
                            netherTable.Controls.Add(tb, 2, netherRow);
                        }
                        else
                        {
                            a.Item.ForeColor = Color.White;
                            netherTable.Controls.Add(a.Item, 2, netherRow);
                        }
                        netherTable.Controls.Add(a.progressBar, 3, netherRow);
                        netherRow++;
                    }
                    else if (a.Type == "end")
                    {
                        endTable.Controls.Add(a.nameLabel, 0, endRow);
                        endTable.Controls.Add(a.descriptionLabel, 1, endRow);


                        if (a.MultiStep)
                        {
                            TableLayoutPanel tb = new TableLayoutPanel();
                            tb.AutoScroll = true;
                            tb.BackColor = Color.Transparent;
                            for (int i = 0; i < a.ItemsNeeded.Count; i++)
                            {
                                tb.Controls.Add(a.ItemsNeeded[i]);
                            }
                            endTable.Controls.Add(tb, 2, endRow);
                        }
                        else
                        {
                            endTable.Controls.Add(a.Item, 2, endRow);
                        }
                        endTable.Controls.Add(a.progressBar, 3, endRow);
                        endRow++;

                    }
                    else if (a.Type == "adventure")
                    {
                        adventureTable.Controls.Add(a.nameLabel, 0, adventureRow);
                        adventureTable.Controls.Add(a.descriptionLabel, 1, adventureRow);

                        if (a.MultiStep)
                        {
                            TableLayoutPanel tb = new TableLayoutPanel();
                            tb.AutoScroll = true;
                            tb.BackColor = Color.Transparent;
                            for (int i = 0; i < a.ItemsNeeded.Count; i++)
                            {
                                tb.Controls.Add(a.ItemsNeeded[i]);
                            }
                            adventureTable.Controls.Add(tb, 2, adventureRow);
                        }
                        else
                        {
                            adventureTable.Controls.Add(a.Item, 2, adventureRow);
                        }
                        adventureTable.Controls.Add(a.progressBar, 3, adventureRow);
                        adventureRow++;
                    }
                    else if (a.Type == "husbandry")
                    {
                        husbandryTable.Controls.Add(a.nameLabel, 0, husbandryRow);
                        husbandryTable.Controls.Add(a.descriptionLabel, 1, husbandryRow);

                        if (a.MultiStep)
                        {
                            TableLayoutPanel tb = new TableLayoutPanel();
                            tb.AutoScroll = true;
                            tb.BackColor = Color.Transparent;
                            for (int i = 0; i < a.ItemsNeeded.Count; i++)
                            {
                                tb.Controls.Add(a.ItemsNeeded[i]);
                            }
                            husbandryTable.Controls.Add(tb, 2, husbandryRow);
                        }
                        else
                        {
                            husbandryTable.Controls.Add(a.Item, 2, husbandryRow);
                        }
                        husbandryTable.Controls.Add(a.progressBar, 3, husbandryRow);
                        husbandryRow++;
                    }
                }

            }
        }
        public void LoadPlayerData(string fileName)
        {
            StreamReader reader = new StreamReader(fileName);
            string[] delim = new string[]{
               "{",
               "\"",
               ":",
               "}",
               ",",
               "minecraft"
            };
            try
            {
                do
                {
                    string line = reader.ReadLine();

                    if (line.Contains("minecraft"))
                    {
                        foreach (string s in delim)
                        {
                            line = line.Replace(s, "");
                        }
                        foreach (Achievement a in allAchievements)
                        {
                            if (a.Location.Equals(line))
                            {
                                line = reader.ReadLine();
                                line = reader.ReadLine();
                                List<String> items = new List<String>();
                                while (!line.Contains("done"))
                                {
                                    items.Add(line);
                                    line = reader.ReadLine();
                                }
                                if (line.Contains("true"))
                                {
                                    a.Completed = true;
                                }
                                else
                                {
                                    foreach (string item in items)
                                    {
                                        foreach (Label l in a.ItemsNeeded)
                                        {
                                            if (item.Contains(l.Text))
                                            {
                                                l.Font = new Font(l.Font, FontStyle.Strikeout);
                                                break;
                                            }
                                        }
                                    }

                                }
                                break;  
                            }
                        }
                    }
                    line = reader.ReadLine();

                }
                while (reader.Peek() != -1);
                addAll();
                fileTitle.Text = fileName;
            }
            catch (Exception ex)
            {
                addAll();
                fileTitle.Text = "Unable to Read File";
            }
            reader.Close();
        }
        

        private void FileOpen(object sender, EventArgs e)
        {
            parentForm.FileOpen(sender, e);
        }

        private void showCompletedButton(object sender, EventArgs e)
        {
            ShowCompleted = !ShowCompleted;
            addAll();
        }

        private void clearTables()
        {
            while (minecraftTable.Controls.Count > 4)
            {
                minecraftTable.Controls[0].Dispose();
            }
            while (netherTable.Controls.Count > 4)
            {
                netherTable.Controls[0].Dispose();
            }
            while (endTable.Controls.Count > 4)
            {
                endTable.Controls[0].Dispose();
            }
            while (adventureTable.Controls.Count > 4)
            {
                adventureTable.Controls[0].Dispose();
            }
            while (husbandryTable.Controls.Count > 4)
            {
                husbandryTable.Controls[0].Dispose();
            }
        }
    }
}
