using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Achievements.Resources
{
    internal class CreateLists
    {
        public List<Achievement> AddAchievements()
        {
            List<Achievement> list = new List<Achievement>();
            StreamReader reader = new StreamReader("listOfAchievements.csv");
            string line = reader.ReadLine();
            while ((line = reader.ReadLine()) != null)
            {
                
                string[] parts = line.Split(',');
                string name = parts[0];
                string description = parts[1];
                string type = parts[2];
                bool multistep = parts[3].Contains("TRUE");
                string location = parts[4];
                
               
                if (multistep)
                {
                    List<Label> items = new List<Label>();
                    for (int i = 5; i < parts.Length; i++)
                    {
                        Label label = new Label();
                        label.BackColor = Color.Transparent;
                        label.Font = new Font("Minecraft", 12);
                        label.Text = parts[i];
                        label.AutoSize = true;
                        items.Add(label);
                    }
                    list.Add(new Achievement(name, description, type,location, items));
                }
                else
                {
                    Label item = new Label();
                    item.BackColor = Color.Transparent;
                    item.Font = new Font("Minecraft", 12);
                    item.Text = parts[5];
                    item.AutoSize = true;
                    list.Add(new Achievement(name, description, type,location, item));
                }
            }
            reader.Close();
            
            return list;

        }
    }
   
}
