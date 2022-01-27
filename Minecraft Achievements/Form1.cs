
namespace Minecraft_Achievements
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void FileOpen(object sender, EventArgs e)
        {
            string fileName = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Browse JSON Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "Json files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
            }


            AchievementsForm achievements = new AchievementsForm(this);
            achievements.LoadPlayerData(fileName);
            achievements.Closed += (s, args) => this.Show(); 
            achievements.Show();
            this.Hide();
        }
    }
}