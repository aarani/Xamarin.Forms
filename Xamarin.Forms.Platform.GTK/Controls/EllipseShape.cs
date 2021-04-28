using System;
using Cairo;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Controls
{
	public class EllipseShape : GtkFormsContainer
	{
		private Color _color;
		private int _height;
		private int _width;

		public void UpdateColor(Color color)
		{
			_color = color;
			QueueDraw();
		}

		public void ResetColor()
		{
			UpdateColor(Color.Default);
		}

		public void UpdateSize(int height, int width)
		{
			_height = height;
			_width = width;
			QueueDraw();
		}

		//public void UpdateBorderRadius(int topLeftRadius = 5, int topRightRadius = 5, int bottomLeftRadius = 5, int bottomRightRadius = 5)
		//{
		//	_topLeftRadius = topLeftRadius > 0 ? topLeftRadius : 0;
		//	_topRightRadius = topRightRadius > 0 ? topRightRadius : 0;
		//	_bottomLeftRadius = bottomLeftRadius > 0 ? bottomLeftRadius : 0;
		//	_bottomRightRadius = bottomRightRadius > 0 ? bottomRightRadius : 0;
		//	QueueDraw();
		//}

		protected override void Draw(Gdk.Rectangle area, Context cr)
		{
			if (_color.IsDefaultOrTransparent())
			{
				return;
			}

			int width = _width;
			int height = _height;
			int radius = Math.Min(width / 2, height / 2);

			cr.Arc(width/2 , height/2, radius, 0, 2 * Math.PI);

			cr.SetSourceRGBA(_color.R, _color.G, _color.B, _color.A);

			cr.Fill();
		}
	}
}
