# JeremyAnsel.BcnSharp

[![Build status](https://ci.appveyor.com/api/projects/status/ycubxjdfryf40rwl/branch/main?svg=true)](https://ci.appveyor.com/project/JeremyAnsel/jeremyansel-bcnsharp/branch/main)
[![NuGet Version](https://img.shields.io/nuget/v/JeremyAnsel.BcnSharp)](https://www.nuget.org/packages/JeremyAnsel.BcnSharp)
![License](https://img.shields.io/github/license/JeremyAnsel/JeremyAnsel.BcnSharp)

JeremyAnsel.BcnSharp is a .Net library to encode and decode BCn BC3 BC5 BC7 texture compression formats.

Description     | Value
----------------|----------------
License         | [The MIT License (MIT)](https://github.com/JeremyAnsel/JeremyAnsel.BcnSharp/blob/main/LICENSE.txt)
Documentation   | http://jeremyansel.github.io/JeremyAnsel.BcnSharp
Source code     | https://github.com/JeremyAnsel/JeremyAnsel.BcnSharp
Nuget           | https://www.nuget.org/packages/JeremyAnsel.BcnSharp
Build           | https://ci.appveyor.com/project/JeremyAnsel/jeremyansel-bcnsharp/branch/main

The JeremyAnsel.BcnSharp library is based on the bc7enc_rdo library.
See https://github.com/richgel999/bc7enc_rdo

# Usage

The methods to encode and decode textures are in these static classes: `Bc7Sharp`, `Bc5Sharp`, `Bc3Sharp`.

The methods are:
```csharp
int GetEncodedArrayLength(int width, int height)
byte[] CreateEncodedArray(int width, int height)
void Encode(IntPtr pBlock, IntPtr pPixelsRGBA, int width, int height)
void Encode(byte[] pBlock, byte[] pPixelsRGBA, int width, int height)
byte[] Encode(byte[] pPixelsRGBA, int width, int height)
int GetDecodedArrayLength(int width, int height)
byte[] CreateDecodedArray(int width, int height)
void Decode(IntPtr pBlock, IntPtr pPixelsRGBA, int width, int height)
void Decode(byte[] pBlock, byte[] pPixelsRGBA, int width, int height)
byte[] Decode(byte[] pBlock, int width, int height)
```

The length of encoded array is
```csharp
((width + 3) / 4) * ((height + 3) / 4) * 16
```

The length of decoded array is
```csharp
width * height * 4
```

The encode and decode methods can create a new output array or can be called with an existing output array.
