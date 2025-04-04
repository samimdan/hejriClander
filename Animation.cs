using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;

namespace sysinfo
{
    public sealed partial class MainWindow : Window
    {
        private IEnumerable<FrameworkElement> FindElementsByTag(DependencyObject parent, string tag)
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is FrameworkElement fe && fe.Tag?.ToString() == tag)
                {
                    yield return fe;
                }

                foreach (var match in FindElementsByTag(child, tag))
                {
                    yield return match;
                }
            }
        }
        private void StartBlinking(string tag)
        {
            Storyboard blinkingStoryboard = new Storyboard
            {
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true,
            };
            IEnumerable<FrameworkElement> uIElement = FindElementsByTag(RootGrid, tag);
           
            foreach (var element in uIElement )
            {
               
                var animation = new DoubleAnimation
                {
                    From = 1,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(500)
                };

                Storyboard.SetTarget(animation,element);
                Storyboard.SetTargetProperty(animation, "Opacity");
                blinkingStoryboard.Children.Add(animation);
            }
            blinkingStoryboard.Begin();
        }


               
                }
            }
        
    