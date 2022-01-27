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
            do
            {
                line = reader.ReadLine();
            }while (reader.Peek() != null);
            
            return list;

        }
    }
   
}
