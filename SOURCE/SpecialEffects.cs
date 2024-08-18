using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Vanara.PInvoke.Gdi32;
using System.Windows.Forms;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.User32;
using Vanara.PInvoke;
using System.Threading;

namespace Exsperian
{
    public class SpecialEffects
    {
        public static void EffectZoomMandelbrot()
        {
            var dc = GetDC(IntPtr.Zero);
            var dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h;
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = 0;
            IntPtr bits;
            var bmp = CreateDIBSection(dc, ref bmpi, 0, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, bmp);

            double zoom = 1.0;
            double zoomSpeed = 1.02;
            double centerX = -0.022;
            double centerY = 0.800;

            while (true)
            {
                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;
                    Parallel.For(0, w, x =>
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            double fractalX = (10.0 / w) / zoom;
                            double fractalY = (10.0 / h) / zoom;
                            double cx = centerX + (x - w / 2.0) * fractalX;
                            double cy = centerY + (y - h / 2.0) * fractalY;
                            double zx = 0;
                            double zy = 0;
                            int fx = 0;
                            while (((zx * zx) * (zy * zy) * (zx * zx) * (zy * zy) < 40 && fx < 100))
                            {
                                double fczx = zx * zx - zy * zy + cx;
                                double fczy = 2 * zx * zy + cy;
                                zx = fczx;
                                zy = fczy;
                                fx++;
                            }

                            byte r, g, b;
                            if (fx == 100)
                            {
                                // Parte dentro do conjunto de Mandelbrot (preto)
                                r = 2;
                                g = 2;
                                b = 3;
                            }
                            else
                            {
                                // Cor baseada no número de iterações
                                byte color = (byte)((fx * 9) % 256);
                                r = (byte)((color * 32) % 256);
                                g = (byte)((color * 732) % 256);
                                b = (byte)((color * 532) % 256);
                            }

                            rgbquad[index].rgbRed = r;
                            rgbquad[index].rgbGreen = g;
                            rgbquad[index].rgbBlue = b;
                        }
                    });
                }

                StretchBlt(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, (RasterOperationMode)0xCC0020);
                zoom *= zoomSpeed;
                Sleep(30);
            }

            ReleaseDC(IntPtr.Zero, dc);
        }
    }
}
