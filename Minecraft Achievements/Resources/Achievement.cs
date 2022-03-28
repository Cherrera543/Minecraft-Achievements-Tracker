using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft_Achievements.Resources
{
    internal class Achievement
    {
        public Label nameLabel = new Label();
        public Label descriptionLabel = new Label();
        public ProgressBar progressBar = new ProgressBar();
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        private int _completedPercent = 0;
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
                    _completedPercent = 100 * (itemsDone / ItemsNeeded.Count);
                    return _completedPercent;
                }
                if (Item.Font.Strikeout)
                {
                    _completedPercent = 100;
                    return _completedPercent;
                }
                return _completedPercent;
            }
            set
            {
                _completedPercent = value;
            }
        }
        private bool _completed = false;
        public bool Completed {
            get
            {
                if(CompletedPercent == 100)
                {
                    _completed = true;
                    return _completed;
                }
                return _completed;
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
                _completed = value;
            } 
        }
        public bool MultiStep { get; set; } = false;
        public List<Label> ItemsNeeded { get; set; } = new List<Label>();
        public Label Item { get; set; } = new Label();
        public string Location { get; set; }

        public Achievement(String name, String description, string type,string location, Label item)
        {
            Name = name;
            Description = description;
            Type = type;

            nameLabel.Text = name;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Minecraft", 12);
            nameLabel.AutoSize = true;

            descriptionLabel.Text = description;
            descriptionLabel.BackColor = Color.Transparent;
            descriptionLabel.Font = new Font("Minecraft", 12);
            descriptionLabel.AutoSize = true;

            if (type == "end" || type == "adventure")
            {
                nameLabel.ForeColor = Color.Black;
                descriptionLabel.ForeColor = Color.Black;
            }
            else
            {
                nameLabel.ForeColor = Color.White;
                descriptionLabel.ForeColor = Color.White;
            }

            
            Item = item;
            MultiStep = false;
            Completed = false;
            Location = location;
            progressBar.ForeColor = Color.Green;
            progressBar.Width = 224;
            progressBar.Height = 23;
            progressBar.Value = this.CompletedPercent;
        }
        public Achievement(String name, String description, string type,string location, List<Label> items)
        {
            Name=name;
            Description = description;
            Type = type;

            nameLabel.Text = name;
            nameLabel.BackColor = Color.Transparent;
            nameLabel.Font = new Font("Minecraft", 12);
            nameLabel.AutoSize = true;

            descriptionLabel.Text = description;
            descriptionLabel.BackColor = Color.Transparent;
            descriptionLabel.Font = new Font("Minecraft", 12);
            descriptionLabel.AutoSize = true;

            if (type == "end" || type == "adventure")
            {
                nameLabel.ForeColor = Color.Black;
                descriptionLabel.ForeColor = Color.Black;
            }
            else
            {
                nameLabel.ForeColor = Color.White;
                descriptionLabel.ForeColor = Color.White;
            }

           
            ItemsNeeded = items;
            MultiStep = true;
            Completed = false;
            Location = location;
            progressBar.ForeColor = Color.Green;
            progressBar.Width = 224;
            progressBar.Height = 23;
            progressBar.Value = this.CompletedPercent;
        }

       /* public List<Object> createLabels()
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

        }*/

    }
}
