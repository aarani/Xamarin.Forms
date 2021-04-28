using System;
using System.ComponentModel;
using Xamarin.Forms.Platform.GTK.Controls;
using Xamarin.Forms.Platform.GTK.Extensions;
using Xamarin.Forms.PlatformConfiguration.GTKSpecific;
using Xamarin.Forms.Shapes;
using FormsPath = Xamarin.Forms.Shapes.Path;

namespace Xamarin.Forms.Platform.GTK.Renderers
{
	public class PathRenderer : ViewRenderer<FormsPath, PathShape>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<FormsPath> e)
		{
			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new PathShape());
				}

				SetFill(Element.Fill);
				SetData(Element.Data);
			}

			base.OnElementChanged(e);
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == FormsPath.FillProperty.PropertyName)
				SetFill(Element.Fill);
			else if (e.PropertyName == FormsPath.DataProperty.PropertyName)
				SetData(Element.Data);
		}

		private void SetData(Shapes.Geometry data)
		{
			Control.UpdateGeometry(data as PathGeometry);
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

	}
}
