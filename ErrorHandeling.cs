using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Controls;

namespace sysinfo
{
    internal class ErrorHandeling
    {
     
         public static async void ShowError(string errorText,string errorTitle)
        {
            var erroDialog = new ContentDialog
            {
                Title = errorTitle,
                Content = errorTitle,

                CloseButtonText = "Ok"
            };
        }
    }
}
