using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Achievements.Resources
{
    internal class Achievement
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }
        public double CompletedPercent { get; set; } = 0.0;
        public bool Completed { get; set; } = false;
        public bool MultiStep { get; set; } = false;
        public List<String> ItemsNeeded { get; set; } = new List<String>();
        public String Item { get; set; }

        public Achievement(String name, String description, int type, String item)
        {
            Name = name;
            Description = description;
            Type = type;
            Item = item;
        }
        public Achievement(String name, String description, int type, List<String> items)
        {
            Name=name;
            Description = description;
            ItemsNeeded = items;
        }

        public List<Object> createLabels()
        {
            List<Object> labels = new List<Object>();
            Label name = new Label();
            name.Text = Name;
            labels.Add(name);
            Label description = new Label();
            description.Text = Description;
            labels.Add(description);
            Label itemsNeeded = new Label();
            
            if (MultiStep)
            {
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i<ItemsNeeded.Count; i++)
                {
                    sb.Append(ItemsNeeded[i]);
                    sb.Append("\n");
                }
                itemsNeeded.Text = sb.ToString();
            }
            else { itemsNeeded.Text = Item; }
            

            ProgressBar pb = new ProgressBar();
            pb.ForeColor = Color.Green;

            labels.Add(pb);
            labels.Add(itemsNeeded);

            return labels; 

        }
    }
}
