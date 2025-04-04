using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;

namespace sysinfo
{
    public sealed partial class MainWindow : Window
    {
        public void FillIedaTb()
        {
            string getFromFile = Task.Run(async () => await Tools.ReadFromIdea()).Result;
            List<string> listFromFile = getFromFile.Split([Environment.NewLine], StringSplitOptions.None).ToList();

            // Assuming you want to display the list in some way, for example, joining it back to a single string
            IdeaTextBox.Text = string.Join(Environment.NewLine, listFromFile);
        }
    }
}
