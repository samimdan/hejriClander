using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace sysinfo
{
    public sealed partial class MainWindow : Window
    {
        public ObservableCollection<string> IdeaList { get; set; } = new();
        public void FillIedaTb()
        {
        string formattedText = string.Empty;
            string getFromFile = Task.Run(async () => await Tools.ReadFromIdea()).Result;
            List<string> lines = getFromFile.Split('\r').ToList();

            for (int i = 0; i < lines.Count - 1; i++)
            {
                IdeaList.Add ($"{i + 1}- {lines[i]}\r");
            }

     
     
        }

      
        
    }
    }

