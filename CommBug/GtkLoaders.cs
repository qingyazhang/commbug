// --------------------------------------------------------------------------------------
// 本软件是自由软件,使用的是GNU通用公共许可证,许可证应使用第二版本或您所选择的更新的版本.
// 发布本软件的目的是希望它能够在一定程度上帮到您.但我们并不为它提供任何形式的担保，
// 也无法保证它可以在特定用途中得到您希望的结果.请参看GNU GPL许可中的更多细节.
// 使用本软件或者与本软件相关的代码,文档,图标之前,您必须接受本软件的协议及许可.
// 您应该在获取本代码同时获得了GNU GPL协议的副本.
// 如果您没有获得GNU GPL协议的副本的话,请给自由软件基金会写信,地址是:
// 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
// 本软件及其代码的作者是黄锐,(Email:vowstar@gmail.com),Lanzhou University
// --------------------------------------------------------------------------------------

using System;
using Gtk;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
namespace Gtk
{
	namespace Loaders
	{
		public static class ImageLoader
		{
			public static void LoadImage (Gtk.Image GtkImage, Bitmap SourceBitmap)
			{
				GtkImage.Pixbuf = LoadImage (SourceBitmap);
			}
			public static Gdk.Pixbuf LoadImage (Bitmap SourceBitmap)
			{
				Gdk.Pixbuf Result;
				using (MemoryStream imgstream = new MemoryStream ()) {
					imgstream.Position = 0;
					SourceBitmap.Save (imgstream, ImageFormat.Bmp);
					imgstream.Position = 0;
					Result = new global::Gdk.Pixbuf (imgstream);
					imgstream.Close ();
				}
				return Result;
				
			}
			public static Bitmap LoadBitmap (byte[][] BitmapBytes)
			{
				int i, j, Width = BitmapBytes[0].Length, Height = BitmapBytes.Length;
				Bitmap Result = new Bitmap (Width, Height);
				for (i = 0; i < Width; i++)
					for (j = 0; j < Height; j++)						
						Result.SetPixel (i, j, System.Drawing.Color.FromArgb (BitmapBytes[i][j]));
				return Result;
			}
			
		}
		
	}
}
