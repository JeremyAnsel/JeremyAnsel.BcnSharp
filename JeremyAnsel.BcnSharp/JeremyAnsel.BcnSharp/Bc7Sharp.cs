using System;
using System.Runtime.InteropServices;

namespace JeremyAnsel.BcnSharp
{
    public static class Bc7Sharp
    {
        public static int GetEncodedArrayLength(int width, int height)
        {
            int blocksWidth = (width + 3) / 4;
            int blocksHeight = (height + 3) / 4;
            int blocksLength = blocksWidth * blocksHeight * 16;
            return blocksLength;
        }

        public static byte[] CreateEncodedArray(int width, int height)
        {
            int blocksWidth = (width + 3) / 4;
            int blocksHeight = (height + 3) / 4;
            int blocksLength = blocksWidth * blocksHeight * 16;

            var pBlock = new byte[blocksLength];
            return pBlock;
        }

        public static void Encode(IntPtr pBlock, IntPtr pPixelsRGBA, int width, int height)
        {
            NativeMethods.BC7_Encode(pBlock, pPixelsRGBA, width, height);
        }

        public static void Encode(byte[] pBlock, byte[] pPixelsRGBA, int width, int height)
        {
            GCHandle handle = GCHandle.Alloc(pPixelsRGBA, GCHandleType.Pinned);
            GCHandle handleCompressed = GCHandle.Alloc(pBlock, GCHandleType.Pinned);

            try
            {
                NativeMethods.BC7_Encode(handleCompressed.AddrOfPinnedObject(), handle.AddrOfPinnedObject(), width, height);
            }
            finally
            {
                handle.Free();
                handleCompressed.Free();
            }
        }

        public static byte[] Encode(byte[] pPixelsRGBA, int width, int height)
        {
            byte[] pBlock = CreateEncodedArray(width, height);

            GCHandle handle = GCHandle.Alloc(pPixelsRGBA, GCHandleType.Pinned);
            GCHandle handleCompressed = GCHandle.Alloc(pBlock, GCHandleType.Pinned);

            try
            {
                NativeMethods.BC7_Encode(handleCompressed.AddrOfPinnedObject(), handle.AddrOfPinnedObject(), width, height);
            }
            finally
            {
                handle.Free();
                handleCompressed.Free();
            }

            return pBlock;
        }

        public static int GetDecodedArrayLength(int width, int height)
        {
            int length = width * height * 4;
            return length;
        }

        public static byte[] CreateDecodedArray(int width, int height)
        {
            int length = width * height * 4;
            var pPixelsRGBA = new byte[length];
            return pPixelsRGBA;
        }

        public static void Decode(IntPtr pBlock, IntPtr pPixelsRGBA, int width, int height)
        {
            NativeMethods.BC7_Decode(pBlock, pPixelsRGBA, width, height);
        }

        public static void Decode(byte[] pBlock, byte[] pPixelsRGBA, int width, int height)
        {
            GCHandle handle = GCHandle.Alloc(pPixelsRGBA, GCHandleType.Pinned);
            GCHandle handleCompressed = GCHandle.Alloc(pBlock, GCHandleType.Pinned);

            try
            {
                NativeMethods.BC7_Decode(handleCompressed.AddrOfPinnedObject(), handle.AddrOfPinnedObject(), width, height);
            }
            finally
            {
                handle.Free();
                handleCompressed.Free();
            }
        }

        public static byte[] Decode(byte[] pBlock, int width, int height)
        {
            byte[] pPixelsRGBA = CreateDecodedArray(width, height);

            GCHandle handle = GCHandle.Alloc(pPixelsRGBA, GCHandleType.Pinned);
            GCHandle handleCompressed = GCHandle.Alloc(pBlock, GCHandleType.Pinned);

            try
            {
                NativeMethods.BC7_Decode(handleCompressed.AddrOfPinnedObject(), handle.AddrOfPinnedObject(), width, height);
            }
            finally
            {
                handle.Free();
                handleCompressed.Free();
            }

            return pPixelsRGBA;
        }
    }
}
