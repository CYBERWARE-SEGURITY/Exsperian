using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Kernel32;
using System.Windows.Forms;
using Vanara.PInvoke;

namespace Exsperian
{
    public class LsdEffects
    {
        private const int AC_SRC_OVER = 0x00;
        private const int BI_RGB = 0;
        private const uint DIB_RGB_COLORS = 0;

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        public static void EfeitoLSDExtreme()
        {
            var dc = GetDC(IntPtr.Zero);
            var dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h; // Corrigir para orientação correta
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            var hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            rgbquad[index].rgbRed = (byte)(128 + 127 * Math.Sin((x + y) * 0.05 + Environment.TickCount * 0.01));
                            rgbquad[index].rgbGreen = (byte)(128 + 127 * Math.Sin((x + y) * 0.05 + Environment.TickCount * 0.02)); // FORMAS
                            rgbquad[index].rgbBlue = (byte)(128 + 127 * Math.Sin((x + y) * 0.05 + Environment.TickCount * 0.03));
                            rgbquad[index].rgbReserved = 100;
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = 1 // Use AC_SRC_ALPHA
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                Sleep(10);
            }

        }
        public static void Lsd2EffectHole()
        {
            IntPtr dc = GetDC(IntPtr.Zero);
            var dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h; // Corrigir para orientação correta
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            var hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            int radius = 0;

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int dx = x - w / 2;
                            int dy = y - h / 2;
                            double distance = Math.Sqrt(dx * dx + dy * dy);

                            if (distance <= radius)
                            {
                                int index = y * w + x;
                                rgbquad[index].rgbRed = (byte)(128 + 127 * Math.Sin(x * 0.1 + radius * 0.1));
                                rgbquad[index].rgbGreen = (byte)(128 + 127 * Math.Sin(y * 0.1 + radius * 0.1));  // FORMAS
                                rgbquad[index].rgbBlue = (byte)(128 + 127 * Math.Sin((x + y) * 0.1 + radius * 0.1));
                                rgbquad[index].rgbReserved = 255;
                            }
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 200,
                    AlphaFormat = 1
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                radius += 10;
                if (radius > 1000)
                {
                    radius = 0;
                }

                Sleep(50);
            }
        }

        public static void Lsd3()
        {
            var dc = GetDC(IntPtr.Zero);
            var dcCopy = CreateCompatibleDC(dc);
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;

            BITMAPINFO bmpi = new BITMAPINFO();
            bmpi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmpi.bmiHeader);
            bmpi.bmiHeader.biWidth = w;
            bmpi.bmiHeader.biHeight = -h; // Corrigir para orientação correta
            bmpi.bmiHeader.biPlanes = 1;
            bmpi.bmiHeader.biBitCount = 32;
            bmpi.bmiHeader.biCompression = BI_RGB;

            IntPtr bits;
            var hBitmap = CreateDIBSection(dc, ref bmpi, DIB_RGB_COLORS, out bits, IntPtr.Zero, 0);
            SelectObject(dcCopy, hBitmap);

            while (true)
            {
                StretchBlt(dcCopy, 0, 0, w, h, dc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                unsafe
                {
                    RGBQUAD* rgbquad = (RGBQUAD*)bits;

                    for (int x = 0; x < w; x++)
                    {
                        for (int y = 0; y < h; y++)
                        {
                            int index = y * w + x;
                            float wave = (float)Math.Sin(x * 0.1 + Environment.TickCount * 0.01) * (float)Math.Sin(y * 0.1 + Environment.TickCount * 0.01);
                            rgbquad[index].rgbRed = (byte)(1 + 127 * wave);
                            rgbquad[index].rgbGreen = (byte)(1 + 127 * wave);
                            rgbquad[index].rgbBlue = (byte)(1 - 127 * wave);
                            rgbquad[index].rgbReserved = 100;
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 255,
                    AlphaFormat = 1 // Use AC_SRC_ALPHA
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                Sleep(1);
            }
        }
    }
}
