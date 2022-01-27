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
            foreach (Achievement a in allAchievements)
            {
                List<Object> labels = a.createLabels();
                if (ShowCompleted || (!ShowCompleted && !a.Completed){


                    if (a.Type == "story")
                    {
                        minecraftTable.Controls.Add((Control)labels[0], 0, minecraftTable.RowCount - 1);
                        minecraftTable.Controls.Add((Control)labels[1], 1, minecraftTable.RowCount - 1);

                        if (a.MultiStep)
                        {
                            for (int i = 3; i < labels.Count; i++)
                            {
                                minecraftTable.Controls.Add((Control)labels[i], 2, minecraftTable.RowCount - 1);
                            }
                        }
                        else
                        {
                            minecraftTable.Controls.Add((Control)labels[3], 2, minecraftTable.RowCount - 1);
                        }
                        minecraftTable.Controls.Add((Control)labels[2], 3, minecraftTable.RowCount - 1);
                    }
                    else if (a.Type == "nether")
                    {
                        netherTable.Controls.Add((Control)labels[0], 0, netherTable.RowCount - 1);
                        netherTable.Controls.Add((Control)labels[1], 1, netherTable.RowCount - 1);

                        if (a.MultiStep)
                        {
                            for (int i = 3; i < labels.Count; i++)
                            {
                                netherTable.Controls.Add((Control)labels[i], 2, netherTable.RowCount - 1);
                            }
                        }
                        else
                        {
                            netherTable.Controls.Add((Control)labels[3], 2, netherTable.RowCount - 1);
                        }
                        netherTable.Controls.Add((Control)labels[2], 3, netherTable.RowCount - 1);
                    }
                    else if (a.Type == "end")
                    {
                        endTable.Controls.Add((Control)labels[0], 0, endTable.RowCount - 1);
                        endTable.Controls.Add((Control)labels[1], 1, endTable.RowCount - 1);

                        if (a.MultiStep)
                        {
                            for (int i = 3; i < labels.Count; i++)
                            {
                                endTable.Controls.Add((Control)labels[i], 2, endTable.RowCount - 1);
                            }
                        }
                        else
                        {
                            endTable.Controls.Add((Control)labels[3], 2, endTable.RowCount - 1);
                        }
                        endTable.Controls.Add((Control)labels[2], 3, endTable.RowCount - 1);
                    }
                    else if (a.Type == "adventure")
                    {
                        adventureTable.Controls.Add((Control)labels[0], 0, adventureTable.RowCount - 1);
                        adventureTable.Controls.Add((Control)labels[1], 1, adventureTable.RowCount - 1);

                        if (a.MultiStep)
                        {
                            for (int i = 3; i < labels.Count; i++)
                            {
                                adventureTable.Controls.Add((Control)labels[i], 2, adventureTable.RowCount - 1);
                            }
                        }
                        else
                        {
                            adventureTable.Controls.Add((Control)labels[3], 2, adventureTable.RowCount - 1);
                        }
                        adventureTable.Controls.Add((Control)labels[2], 3, adventureTable.RowCount - 1);
                    }
                    else if (a.Type == "husbandry")
                    {
                        husbandryTable.Controls.Add((Control)labels[0], 0, husbandryTable.RowCount - 1);
                        husbandryTable.Controls.Add((Control)labels[1], 1, husbandryTable.RowCount - 1);

                        if (a.MultiStep)
                        {
                            for (int i = 3; i < labels.Count; i++)
                            {
                                husbandryTable.Controls.Add((Control)labels[i], 2, husbandryTable.RowCount - 1);
                            }
                        }
                        else
                        {
                            husbandryTable.Controls.Add((Control)labels[3], 2, husbandryTable.RowCount - 1);
                        }
                        husbandryTable.Controls.Add((Control)labels[2], 3, husbandryTable.RowCount - 1);
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
                            if (a.location.Equals(line))
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
    }
}
