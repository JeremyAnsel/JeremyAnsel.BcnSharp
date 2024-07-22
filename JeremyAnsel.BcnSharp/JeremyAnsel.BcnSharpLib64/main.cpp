#include "rgbcx.h"
#include "bc7enc.h"
#include "bc7decomp.h"
#include <algorithm>

extern "C" __declspec(dllexport) int BC3_Encode(char* pBlock, const char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	rgbcx::init();

	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			for (int j = 0; j < 4; j++)
			{
				for (int i = 0; i < 4; i++)
				{
					int currentJ = maxJ == 4 ? j : 0;
					int currentI = maxI == 4 ? i : 0;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(block + destinationOffset) = *(unsigned int*)(pPixelsRGBA + sourceOffset);

					block[destinationOffset + 0] = pPixelsRGBA[sourceOffset + 2];
					block[destinationOffset + 2] = pPixelsRGBA[sourceOffset + 0];
				}
			}

			rgbcx::encode_bc3(0xffffffff, pBlock, (unsigned char*)block);
			pBlock += 16;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) int BC3_Decode(const char* pBlock, char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	rgbcx::init();

	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			rgbcx::unpack_bc3(pBlock, block);

			for (int j = 0; j < maxJ; j++)
			{
				for (int i = 0; i < maxI; i++)
				{
					int currentJ = j;
					int currentI = i;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(pPixelsRGBA + sourceOffset) = *(unsigned int*)(block + destinationOffset);

					pPixelsRGBA[sourceOffset + 2] = block[destinationOffset + 0];
					pPixelsRGBA[sourceOffset + 0] = block[destinationOffset + 2];
				}
			}

			pBlock += 16;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) int BC5_Encode(char* pBlock, const char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	rgbcx::init();

	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			for (int j = 0; j < 4; j++)
			{
				for (int i = 0; i < 4; i++)
				{
					int currentJ = maxJ == 4 ? j : 0;
					int currentI = maxI == 4 ? i : 0;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(block + destinationOffset) = *(unsigned int*)(pPixelsRGBA + sourceOffset);

					block[destinationOffset + 0] = pPixelsRGBA[sourceOffset + 2];
					block[destinationOffset + 2] = pPixelsRGBA[sourceOffset + 0];
				}
			}

			rgbcx::encode_bc5(pBlock, (unsigned char*)block);
			pBlock += 16;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) int BC5_Decode(const char* pBlock, char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	rgbcx::init();

	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			rgbcx::unpack_bc5(pBlock, block);

			for (int j = 0; j < maxJ; j++)
			{
				for (int i = 0; i < maxI; i++)
				{
					int currentJ = j;
					int currentI = i;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(pPixelsRGBA + sourceOffset) = *(unsigned int*)(block + destinationOffset);

					pPixelsRGBA[sourceOffset + 2] = block[destinationOffset + 0];
					pPixelsRGBA[sourceOffset + 0] = block[destinationOffset + 2];
					pPixelsRGBA[sourceOffset + 3] = (char)0xff;
				}
			}

			pBlock += 16;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) int BC7_Encode(char* pBlock, const char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	bc7enc_compress_block_init();

	bc7enc_compress_block_params compress_params;
	bc7enc_compress_block_params_init(&compress_params);
	compress_params.m_force_alpha = true;

	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			for (int j = 0; j < 4; j++)
			{
				for (int i = 0; i < 4; i++)
				{
					int currentJ = maxJ == 4 ? j : 0;
					int currentI = maxI == 4 ? i : 0;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(block + destinationOffset) = *(unsigned int*)(pPixelsRGBA + sourceOffset);

					block[destinationOffset + 0] = pPixelsRGBA[sourceOffset + 2];
					block[destinationOffset + 2] = pPixelsRGBA[sourceOffset + 0];
				}
			}

			bc7enc_compress_block(pBlock, block, &compress_params);
			pBlock += 16;
		}
	}

	return 0;
}

extern "C" __declspec(dllexport) int BC7_Decode(const char* pBlock, char* pPixelsRGBA, int pPixelsRGBAWidth, int pPixelsRGBAHeight)
{
	char block[4 * 4 * 4]{};

	for (int y = 0; y < pPixelsRGBAHeight; y += 4)
	{
		for (int x = 0; x < pPixelsRGBAWidth; x += 4)
		{
			int maxJ = std::min(pPixelsRGBAHeight - y, 4);
			int maxI = std::min(pPixelsRGBAWidth - x, 4);

			bc7decomp::unpack_bc7(pBlock, (bc7decomp::color_rgba*)block);

			for (int j = 0; j < maxJ; j++)
			{
				for (int i = 0; i < maxI; i++)
				{
					int currentJ = j;
					int currentI = i;

					int sourceOffset = (y + currentJ) * pPixelsRGBAWidth * 4 + (x + currentI) * 4;
					int destinationOffset = j * 4 * 4 + i * 4;

					*(unsigned int*)(pPixelsRGBA + sourceOffset) = *(unsigned int*)(block + destinationOffset);

					pPixelsRGBA[sourceOffset + 2] = block[destinationOffset + 0];
					pPixelsRGBA[sourceOffset + 0] = block[destinationOffset + 2];
				}
			}

			pBlock += 16;
		}
	}

	return 0;
}
