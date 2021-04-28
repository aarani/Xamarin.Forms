using System;
using Cairo;
using Xamarin.Forms.Platform.GTK.Extensions;

namespace Xamarin.Forms.Platform.GTK.Controls
{
	public class ShapeView : GtkFormsContainer
	{
		protected Brush _fill, _stroke;
		protected int _height, _width;
		private double? _strokeThickness;
		private float? _strokeDashOffset, _strokeMiterLimit;
		private double[] _dashArray;
		private LineCap? _strokeCap;
		private LineJoin? _strokeJoin;

		public void UpdateFill(Brush brush)
		{
			_fill = brush;
			QueueDraw();
		}

		public void UpdateStroke(Brush brush)
		{
			_stroke = brush;
			QueueDraw();
		}

		public void UpdateSize(int height, int width)
		{
			_height = height;
			_width = width;
			QueueDraw();
		}

		public void UpdateStrokeThickness(double strokeThickness)
		{
			_strokeThickness = strokeThickness;
			QueueDraw();
		}

		public void UpdateStrokeDashArray(double[] dashArray)
		{
			_dashArray = dashArray;
			QueueDraw();
		}

		public void UpdateStrokeDashOffset(float strokeDashOffset)
		{
			_strokeDashOffset = strokeDashOffset;
			QueueDraw();
		}

		public void UpdateStrokeLineCap(LineCap strokeCap)
		{
			_strokeCap = strokeCap;
			QueueDraw();
		}

		public void UpdateStrokeLineJoin(LineJoin strokeJoin)
		{
			_strokeJoin = strokeJoin;
			QueueDraw();
		}

		public void UpdateStrokeMiterLimit(float strokeMiterLimit)
		{
			_strokeMiterLimit = strokeMiterLimit;
			QueueDraw();
		}

		protected override void Draw(Gdk.Rectangle area, Context cr)
		{
			if (_strokeThickness.HasValue)
				cr.LineWidth = _strokeThickness.Value;

			if (_strokeDashOffset.HasValue && _dashArray != null)
				cr.SetDash(_dashArray, _strokeDashOffset.Value);

			if (_strokeMiterLimit.HasValue)
				cr.MiterLimit = _strokeMiterLimit.Value;

			if (_strokeCap.HasValue)
				cr.LineCap = _strokeCap.Value;

			if (_strokeJoin.HasValue)
				cr.LineJoin = _strokeJoin.Value;

			if (_stroke is SolidColorBrush strokeBrush)
			{
				cr.SetSourceRGBA(strokeBrush.Color.R, strokeBrush.Color.G, strokeBrush.Color.B, strokeBrush.Color.A);
				cr.StrokePreserve();
			}
			else if (_stroke != null)
				throw new NotImplementedException("Brushes other than SolidColorBrush are not implemented yet!");

			if (_fill is SolidColorBrush fillBrush)
			{
				cr.SetSourceRGBA(fillBrush.Color.R, fillBrush.Color.G, fillBrush.Color.B, fillBrush.Color.A);
				cr.Fill();
			}
			else if (_fill != null)
				throw new NotImplementedException("Brushes other than SolidColorBrush are not implemented yet!");
		}

	}
}