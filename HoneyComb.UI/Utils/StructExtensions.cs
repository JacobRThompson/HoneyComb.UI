using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Utils
{
    public static class StructExtensions 
    {
        public static Point Subtract(this Point p1, Point p2) => new(p1.X - p2.X, p1.Y - p2.Y);
        public static Point  Add(this Point p1, Point p2) => new(p1.X + p2.X, p1.Y + p2.Y);

        public static Rectangle Deflate(this Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }

        public static float GetAspectRatio(this Image image) =>  image.Width / image.Height;
 
        public static Point GetCenter(this Rectangle rect) => new(rect.X + rect.Width/2, rect.Y + rect.Height/2);

        public static Rectangle ScaleToAspectRatio(this Rectangle rect, float aspectRatio)
        {
            var currentAspectRatio = (float)rect.Width / rect.Height;
            if (currentAspectRatio > aspectRatio)
            {
                // Scale the width to match the new aspect ratio
                var newWidth = (int)(rect.Height * aspectRatio);
                var x = rect.X + (rect.Width - newWidth) / 2;
                return new Rectangle(x, rect.Y, newWidth, rect.Height);
            }
            else
            {
                // Scale the height to match the new aspect ratio
                var newHeight = (int)(rect.Width / aspectRatio);
                var y = rect.Y + (rect.Height - newHeight) / 2;
                return new Rectangle(rect.X, y, rect.Width, newHeight);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Bitmap ReplaceOpaquePixels(this Image image, Color newColor)
        {
            Bitmap bitmap = new Bitmap(image.Width, image.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Lock the bits of the new Bitmap for reading and writing
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get a pointer to the first byte of the bitmap data
            IntPtr ptr = bitmapData.Scan0;

            // Calculate the number of bytes per pixel and the stride of the bitmap data
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int stride = bitmapData.Stride;

            byte[] pixelValues = new byte[Math.Abs(stride) * bitmap.Height];

            // Copy the bitmap data to the byte array
            Marshal.Copy(ptr, pixelValues, 0, pixelValues.Length);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    int index = y * stride + x * bytesPerPixel;

                    pixelValues[index] = newColor.B;
                    pixelValues[index + 1] = newColor.G;
                    pixelValues[index + 2] = newColor.R;

                }
            }

            // Copy the modified pixel values back to the bitmap data
            Marshal.Copy(pixelValues, 0, ptr, pixelValues.Length);

            // Unlock the bits of the bitmap data
            bitmap.UnlockBits(bitmapData);

            return bitmap;
        }

        public static unsafe void UnsafeReplaceOpaquePixels(Bitmap bitmap, Color newColor)
        {
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            // Lock the bits of the Bitmap for reading and writing
            BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            // Get a pointer to the first byte of the Bitmap data
            byte* ptr = (byte*)bitmapData.Scan0.ToPointer();

            // Calculate the number of bytes per pixel and the stride of the Bitmap data
            int bytesPerPixel = Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
            int stride = bitmapData.Stride;

            for (int y = 0; y < bitmap.Height; y++)
            {
                byte* row = ptr + y * stride;

                for (int x = 0; x < bitmap.Width; x++)
                {
                    byte* pixel = row + x * bytesPerPixel;

                    pixel[0] = newColor.B;
                    pixel[1] = newColor.G;
                    pixel[2] = newColor.R;
                }
            }

            // Unlock the bits of the Bitmap data
            bitmap.UnlockBits(bitmapData);
        }
    }

}
