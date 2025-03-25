#region

using System.Numerics;
using Windows.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Hosting;

#endregion

namespace sysinfo;

/// <summary>
///     Provides visual effects for UI elements.
/// </summary>
public class ApplyBlur
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="ApplyBlur" /> class.
    /// </summary>
    /// <param name="element">The UI element to which the blur effect will be applied.</param>
    /// <param name="dropShadowColor">The color of the drop shadow.</param>
    /// <param name="blurRadius">The radius of the blur effect.</param>
    /// <param name="opacity">The opacity of the drop shadow.</param>
    /// <param name="dropShadowOffset">The offset of the drop shadow.</param>
    public ApplyBlur(FrameworkElement element, Color dropShadowColor, float blurRadius, float opacity,
        Vector3 dropShadowOffset)
    {
        Element = element;
        DropShadowColor = dropShadowColor;
        BlurRadius = blurRadius;
        Opacity = opacity;
        DropShadowOffset = dropShadowOffset;
    }


    private FrameworkElement Element { get; }


    private Color DropShadowColor { get; }


    private float BlurRadius { get; }


    private float Opacity { get; }


    private Vector3 DropShadowOffset { get; }


    public void AddDropShadow()
    {
        Element.Loaded +=  (sender, args) =>
        {
            var visual = ElementCompositionPreview.GetElementVisual(Element);
            var compositor = visual.Compositor;
            // Get graphic engine
            var dropShadow = compositor.CreateDropShadow();
            dropShadow.Color = DropShadowColor;
            dropShadow.BlurRadius = BlurRadius;
            dropShadow.Opacity = Opacity;
            dropShadow.Offset = DropShadowOffset;

            var shadowVisual = compositor.CreateSpriteVisual();
            shadowVisual.Shadow = dropShadow;
            // Create layer for shadow
            var maskBrush = compositor.CreateMaskBrush();
            var surfaceBrush = compositor.CreateSurfaceBrush();
            var containerVisual = ElementCompositionPreview.GetElementVisual(Element);
            ElementCompositionPreview.SetElementChildVisual(Element, shadowVisual);

            if (Element is not FrameworkElement element) return;
            shadowVisual.Size = new Vector2((float)element.ActualWidth, (float)element.ActualHeight);

            element.SizeChanged += (sender, args) =>
            {
                shadowVisual.Size = new Vector2((float)args.NewSize.Width, (float)args.NewSize.Height);
            };
  
    
        };
    }
}