using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace JeremyAnsel.BcnSharp
{
    [SecurityCritical, SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods
    {
        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC3_Encode")]
        private static extern int BC3_Encode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC3_Encode")]
        private static extern int BC3_Encode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC3_Encode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC3_Encode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC3_Encode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }

        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC3_Decode")]
        private static extern int BC3_Decode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC3_Decode")]
        private static extern int BC3_Decode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC3_Decode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC3_Decode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC3_Decode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }

        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC5_Encode")]
        private static extern int BC5_Encode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC5_Encode")]
        private static extern int BC5_Encode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC5_Encode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC5_Encode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC5_Encode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }

        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC5_Decode")]
        private static extern int BC5_Decode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC5_Decode")]
        private static extern int BC5_Decode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC5_Decode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC5_Decode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC5_Decode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }

        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC7_Encode")]
        private static extern int BC7_Encode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC7_Encode")]
        private static extern int BC7_Encode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC7_Encode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC7_Encode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC7_Encode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }

        [DllImport("JeremyAnsel.BcnSharpLib32.dll", EntryPoint = "BC7_Decode")]
        private static extern int BC7_Decode32(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [DllImport("JeremyAnsel.BcnSharpLib64.dll", EntryPoint = "BC7_Decode")]
        private static extern int BC7_Decode64(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int BC7_Decode(IntPtr pBlock, IntPtr pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
        {
            if (Environment.Is64BitProcess)
            {
                return BC7_Decode64(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
            else
            {
                return BC7_Decode32(pBlock, pPixelsRGBA, pPixelsRGBAWidth, pPixelsRGBAHeight);
            }
        }
    }
}
