using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Controls;
using Xamarin.Forms.Platform.GTK.Extensions;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using FormsEllipse = Xamarin.Forms.Shapes.Ellipse;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class EllipseRenderer: ViewRenderer<FormsEllipse, EllipseShape>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<FormsEllipse> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new EllipseShape());
				}

				SetFill(Element.Fill);

				SetSize();
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == FormsEllipse.FillProperty.PropertyName)
			{
				SetFill(Element.Fill);
			}
		}

		protected override void OnSizeAllocated(Gdk.Rectangle allocation)
		{
			SetSize();

			base.OnSizeAllocated(allocation);
		}


		private void SetFill(Brush brush)
		{
			if (Element == null || Control == null)
				return;

			if (brush is SolidColorBrush colorBrush && !colorBrush.Color.IsDefaultOrTransparent()) 
			{
				Control.UpdateColor(colorBrush.Color);
			}
			else
			{
				Control.ResetColor();
			}
		}


		private void SetSize()
		{
			int height = HeightRequest;
			int width = WidthRequest;

			Control.UpdateSize(height, width);
		}

	}
}
