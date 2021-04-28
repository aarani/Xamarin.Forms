using System;
using Cairo;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Controls
{
	public class ShapeView : GtkFormsContainer
	{
		protected Brush _fill;
		protected int _height, _width;

		public void UpdateFill(Brush brush)
		{
			_fill = brush;
			QueueDraw();
		}

		public void UpdateSize(int height, int width)
		{
			_height = height;
			_width = width;
			QueueDraw();
		}

		protected override void Draw(Gdk.Rectangle area, Context cr)
		{
			if (_fill is SolidColorBrush colorBrush)
			{
				cr.SetSourceRGBA(colorBrush.Color.R, colorBrush.Color.G, colorBrush.Color.B, colorBrush.Color.A);
				cr.Fill();
			}
			else
				throw new NotImplementedException("Brushes other than SolidColorBrush are not implemented yet!");
		}
	}
}
