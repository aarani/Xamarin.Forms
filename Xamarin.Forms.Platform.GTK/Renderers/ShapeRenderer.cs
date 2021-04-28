using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Controls;
using Xamarin.Forms.Platform.GTK.Extensions;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Shapes;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class ShapeRenderer<TShape, TNativeShape> : ViewRenderer<TShape, TNativeShape>
		where TShape : Shape
		where TNativeShape : ShapeView, new()
	{
		protected override void OnElementChanged(ElementChangedEventArgs<TShape> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new TNativeShape());
				}

				SetFill(Element.Fill);

				SetSize();
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == Shape.FillProperty.PropertyName)
				SetFill(Element.Fill);
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

			Control.UpdateFill(brush);
		}


		private void SetSize()
		{
			int height = HeightRequest;
			int width = WidthRequest;

			Control.UpdateSize(height, width);
		}

	}
}
