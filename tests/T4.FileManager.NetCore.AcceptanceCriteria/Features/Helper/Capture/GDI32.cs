namespace T4.FileManager.NetCore.AcceptanceCriteria.Features.Helper.Capture
{
    using System;
    using System.Runtime.InteropServices;

    public class GDI32
    {

        public const int SRCCOPY = 0x00CC0020; // BitBlt dwRop parameter
        public const int CAPTUREBLT = 0x40000000;

        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport("gdi32.dll")]

        public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest,
                                         int nWidth, int nHeight, IntPtr hObjectSource,
                                         int nXSrc, int nYSrc, int dwRop);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth,
                                                           int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteDC(IntPtr hDC);

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    }
}