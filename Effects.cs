using System.Numerics;
using Windows.UI;
using Microsoft.UI;
using Microsoft.UI.Composition;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Hosting;
using Microsoft.UI.Xaml.Media.Imaging;

namespace sysinfo
{
    /// <summary>
    /// Provides visual effects for UI elements.
    /// </summary>
  
        public class ShadowApplier
        {
            private readonly Compositor _compositor;
            private DropShadow _dropShadow;
            private SpriteVisual _shadowVisual;

            // سازنده با تنظیمات اولیه سایه
            public ShadowApplier(Grid rootGrid)
            {
                _compositor = ElementCompositionPreview.GetElementVisual(rootGrid).Compositor;

                // ایجاد سایه و تنظیمات اولیه
                _dropShadow = _compositor.CreateDropShadow();
                _dropShadow.Color = Colors.Black;
                _dropShadow.BlurRadius = 20.0f;
                _dropShadow.Opacity = 0.5f;

                // ایجاد یک Visual برای نمایش سایه
                _shadowVisual = _compositor.CreateSpriteVisual();
            }

            public void ApplyDropShadow(Border targetBorder)
            {
                // تنظیم سایز Visual به سایز کنترل هدف
                _shadowVisual.Size = new Vector2(
                    (float)targetBorder.ActualWidth,
                    (float)targetBorder.ActualHeight
                );

                // تنظیم سایه به Visual
                _shadowVisual.Shadow = _dropShadow;

                // اتصال Visual به کنترل هدف
                ElementCompositionPreview.SetElementChildVisual(targetBorder, _shadowVisual);
            }

            public void UpdateShadowSettings(Color color, float blurRadius, float opacity)
            {
                _dropShadow.Color = color;
                _dropShadow.BlurRadius = blurRadius;
                _dropShadow.Opacity = opacity;
            }
        }
    }
