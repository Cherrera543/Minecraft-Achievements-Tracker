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
        public AchievementsForm(Form1 parent)
        {
            InitializeComponent();
            parentForm = parent;
        }
        public bool LoadPlayerData(string fileName)
        {
            return false;
        }

        private void FileOpen(object sender, EventArgs e)
        {
            parentForm.FileOpen(sender, e);
        }
    }
}
