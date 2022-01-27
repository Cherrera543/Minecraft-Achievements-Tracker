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
        public string Type { get; set; }
        public int CompletedPercent
        {
            get
            {
                if (MultiStep)
                {
                    int itemsDone = 0;
                    foreach (Label l in ItemsNeeded)
                    {
                        if (l.Font.Strikeout) { itemsDone++; }
                    }
                    return itemsDone / ItemsNeeded.Count;
                }
                if (Item.Font.Strikeout)
                {
                    return 100;
                }
                return 0;
            }
            set
            {
                CompletedPercent = value;
            }
        }
        public bool Completed {
            get
            {
                if(CompletedPercent == 100)
                {
                    return true;
                }
                return Completed;
            }
            set {
                if(value == true)
                {
                    CompletedPercent = 100;
                    if (MultiStep)
                    {
                        foreach (Label l in ItemsNeeded)
                        {
                            l.Font = new Font(l.Font, FontStyle.Strikeout);
                        }
                    }
                    else { Item.Font = new Font(Item.Font, FontStyle.Strikeout); }
                    
                }
                Completed = value;
            } 
        }
        public bool MultiStep { get; set; } = false;
        public List<Label> ItemsNeeded { get; set; } = new List<Label>();
        public Label Item { get; set; } = new Label();
        public string location { get; set; }

        public Achievement(String name, String description, string type, Label item)
        {
            Name = name;
            Description = description;
            Type = type;
            Item = item;
            MultiStep = false;
            Completed = false;
        }
        public Achievement(String name, String description, string type, List<Label> items)
        {
            Name=name;
            Description = description;
            Type=type;
            ItemsNeeded = items;
            MultiStep = true;
            Completed = false;
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
           
            ProgressBar pb = new ProgressBar();
            pb.ForeColor = Color.Green;
            pb.Value = CompletedPercent;

            labels.Add(pb);
            if (MultiStep)
            {
                foreach(Label label in ItemsNeeded)
                {
                    labels.Add(label);
                }
            }
            else {
                
                labels.Add(Item);
            }

            return labels; 

        }

    }
}
