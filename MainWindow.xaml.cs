#region
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using Microsoft.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Composition.SystemBackdrops;
using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media.Imaging;
using WinRT.Interop;
using WinRT;
using System.Runtime.InteropServices;
using System;
#endregion

namespace sysinfo;

public sealed partial class MainWindow : Window
{
    private readonly DispatcherTimer _dispatcherTimer = new();

   
    /* ------------------------------- MainWindow Constructor ------------------------------- */
    public MainWindow()

    {
        InitializeComponent();

        // Set the window appearance
        WindowAppearanceController.SetWindowsSize(this, 230, 1000);
        var hwnd = WindowNative.GetWindowHandle(this);
        WindowAppearanceController.NakedWindow(hwnd);
        WindowAppearanceController.SetTopMost(this, true);
        WindowAppearanceController.SetCornerRadius(hwnd, WindowCornerPreference.ROUND);

        // Set image
        var bitmapImage = new BitmapImage(FunnyGif.Morning);
        FunnyStateGif.Source = bitmapImage;
        ImageShadowContainer.Loaded += (s, e) =>
        {
            //Shadows should be applied after the image has been loaded and the size has been set.
            AddDropShadow(ImageShadowContainer);
        };
        }

        private void AddDropShadow(UIElement target)
        {
            var visual = ElementCompositionPreview.GetElementVisual(target);
            var compositor = visual.Compositor;

            var dropShadow = compositor.CreateDropShadow();
            dropShadow.Color = new Windows.UI.Color { A = 255, R = 0, G = 0, B = 0 };
            dropShadow.BlurRadius = 20;
            dropShadow.Opacity = 0.4f;
            dropShadow.Offset = new System.Numerics.Vector3(0, 4, 0);

            var shadowVisual = compositor.CreateSpriteVisual();
            shadowVisual.Shadow = dropShadow;

           
            var containerVisual = ElementCompositionPreview.GetElementVisual(target);
            ElementCompositionPreview.SetElementChildVisual(target, shadowVisual);

            if (target is FrameworkElement element)
            {
                shadowVisual.Size = new System.Numerics.Vector2((float)element.ActualWidth, (float)element.ActualHeight);

                element.SizeChanged += (sender, args) =>
                {
                    shadowVisual.Size = new System.Numerics.Vector2((float)args.NewSize.Width, (float)args.NewSize.Height);
                };
            }
        }

}


//    public void HandleGridPointerPressed(object sender, PointerRoutedEventArgs e)
//    {
//        Point mousePosition; // Added declaration for mousePosition
//        var mousePositionFromWindow = e.GetCurrentPoint((UIElement)sender);
//        Debug.WriteLine(mousePositionFromWindow.Position.X);
//        _dispatcherTimer.Tick += (s, m) =>
//        {
//            mousePosition = MouseController.GetMousePosition();
//            WindowAppearanceController.SetWindowsPosition(this, mousePosition.X - (int)mousePositionFromWindow.Position.X, mousePosition.Y - (int)mousePositionFromWindow.Position.Y);
//        };

//        _dispatcherTimer.Start();
//    }

//    public void HandleGridPointerRelased(object sender, PointerRoutedEventArgs e)
//    {
//        _dispatcherTimer.Stop();
//    }
//}
