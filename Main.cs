
using MyPhotoshop.Filters;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
		[STAThread]
		public static void Main(string[] args)
		{
			var window = new MainWindow();
			window.AddFilter(new PixelFilter<LighteningParameters>(
				"Осветление/Затемление",
				(Pixel, parametes) => Pixel * parametes.Coefficient
				));

			window.AddFilter(new PixelFilter<EmptyParameters>(
			"Оттенки серого",
			(original, parametes) =>
			{
				var liteness = original.R + original.G + original.B;
				liteness /= 3;
				return new Pixel(liteness, liteness, liteness);
			}
			));

			window.AddFilter(new TransformFilter(
			"Отразить по горизонтали",
			size => size,
			(point, size) => new Point(size.Width - point.X - 1, point.Y)
			));

			window.AddFilter(new TransformFilter(
			"Повернуть",
			size => new Size(size.Height,size.Width),
			(point, size) => new Point(point.Y,point.X)
			));

			Application.Run(window);
		}
	}
}
