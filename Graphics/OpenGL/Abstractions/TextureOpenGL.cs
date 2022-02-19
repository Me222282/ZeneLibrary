﻿using System;
using Zene.Structs;

namespace Zene.Graphics.Base.Extensions
{
    public static unsafe class TextureOpenGL
    {
        /// <summary>
        /// Sets the OpenGL context to referance <paramref name="texture"/>.
        /// </summary>
        public static void SetGLContext(this ITexture texture)
        {
            // Bind if not bound
            if (!texture.Bound())
            {
                texture.Bind();
                return;
            }
            // Set active texture to referance
            if (State.ActiveTexture != texture.ReferanceSlot)
            {
                State.ActiveTexture = texture.ReferanceSlot;
            }
        }

        /// <summary>
        /// Fills all a texture image with a constant value.
        /// </summary>
        /// <typeparam name="T"><paramref name="type"/></typeparam>
        /// <param name="level">The level containing the region to be cleared.</param>
        /// <param name="format">The format of the data whose address in memory is given by <paramref name="data"/>.</param>
        /// <param name="type">The type of the data whose address in memory is given by <paramref name="data"/>.</param>
        /// <param name="data">The data to be used to clear the specified region.</param>
        [OpenGLSupport(4.4)]
        public static void ClearTextureImage<T>(this ITexture texture, int level, BaseFormat format, TextureData type, T data) where T : unmanaged
        {
            GL.ClearTexImage(texture.Id, level, (uint)format, (uint)type, &data);
        }
        /// <summary>
        /// Fills all a texture image with a constant value.
        /// </summary>
        /// <typeparam name="T"><paramref name="type"/></typeparam>
        /// <param name="level">The level containing the region to be cleared.</param>
        /// <param name="xOffset">The coordinate of the left edge of the region to be cleared.</param>
        /// <param name="yOffset">The coordinate of the lower edge of the region to be cleared.</param>
        /// <param name="zOffset">The coordinate of the front of the region to be cleared.</param>
        /// <param name="width">The width of the region to be cleared.</param>
        /// <param name="height">The height of the region to be cleared.</param>
        /// <param name="depth">The depth of the region to be cleared.</param>
        /// <param name="format">The format of the data whose address in memory is given by <paramref name="data"/>.</param>
        /// <param name="type">The type of the data whose address in memory is given by <paramref name="data"/>.</param>
        /// <param name="data">The data to be used to clear the specified region.</param>
        [OpenGLSupport(4.4)]
        public static void ClearTextureSubImage<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, BaseFormat format, TextureData type, T data) where T : unmanaged
        {
            GL.ClearTexSubImage(texture.Id, level, xOffset, yOffset, zOffset, width, height, depth, (uint)format, (uint)type, &data);
        }

        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 64 texels wide. The height of the 1D texture image is 1.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage1D<T>(this ITexture texture, int level, int size, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage1D((uint)texture.Target, level, (uint)texture.InternalFormat, size, 0, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 64 texels wide. The height of the 1D texture image is 1.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage1D<T>(this ITexture texture, int level, int size, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage1D((uint)texture.Target, level, (uint)texture.InternalFormat, size, 0, imageSize, data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 64 texels wide. The height of the 1D texture image is 1.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage1D(this ITexture texture, int level, int size, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexImage1D((uint)texture.Target, level, (uint)texture.InternalFormat, size, 0, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D<T>(this ITexture texture, int level, int width, int height, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, 0, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D<T>(this ITexture texture, CubeMapFace target, int level, int width, int height, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)target, level, (uint)texture.InternalFormat, width, height, 0, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D<T>(this ITexture texture, int level, int width, int height, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, 0, imageSize, data);
        }
        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D<T>(this ITexture texture, CubeMapFace target, int level, int width, int height, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)target, level, (uint)texture.InternalFormat, width, height, 0, imageSize, data);
        }
        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D(this ITexture texture, int level, int width, int height, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, 0, imageSize, data.ToPointer());
        }
        /// <summary>
        /// Specify a two-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 2D texture and cube map texture images that are at least 16384 texels high.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage2D(this ITexture texture, CubeMapFace target, int level, int width, int height, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexImage2D((uint)target, level, (uint)texture.InternalFormat, width, height, 0, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Specify a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 16 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image. All implementations support 3D texture images that are at least 16 texels deep.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage3D<T>(this ITexture texture, int level, int width, int height, int depth, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage3D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, depth, 0, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 16 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image. All implementations support 3D texture images that are at least 16 texels deep.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage3D<T>(this ITexture texture, int level, int width, int height, int depth, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexImage3D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, depth, 0, imageSize, data);
        }
        /// <summary>
        /// Specify a three-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 16 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image. All implementations support 3D texture images that are at least 16 texels deep.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexImage3D(this ITexture texture, int level, int width, int height, int depth, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexImage3D((uint)texture.Target, level, (uint)texture.InternalFormat, width, height, depth, 0, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage1D<T>(this ITexture texture, int level, int offset, int size, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage1D((uint)texture.Target, level, offset, size, (uint)texture.InternalFormat, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage1D<T>(this ITexture texture, int level, int offset, int size, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage1D((uint)texture.Target, level, offset, size, (uint)texture.InternalFormat, imageSize, data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage1D(this ITexture texture, int level, int offset, int size, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage1D((uint)texture.Target, level, offset, size, (uint)texture.InternalFormat, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D<T>(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D<T>(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, imageSize, data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, imageSize, data.ToPointer());
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D<T>(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D<T>(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, imageSize, data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage2D(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)texture.InternalFormat, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage3D<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)texture.InternalFormat, data.Size * sizeof(T), data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage3D<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, int imageSize, T* data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)texture.InternalFormat, imageSize, data);
        }
        /// <summary>
        /// Specify a one-dimensional texture image in a compressed format.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="imageSize">Specifies the number of unsigned bytes of image data starting at the address specified by <paramref name="data"/>.</param>
        /// <param name="data">Specifies the compressed image data.</param>
        [OpenGLSupport(1.3)]
        public static void CompressedTexSubImage3D(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, int imageSize, IntPtr data)
        {
            texture.SetGLContext();
            GL.CompressedTexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)texture.InternalFormat, imageSize, data.ToPointer());
        }

        /// <summary>
        /// Perform a raw data copy between two images.
        /// </summary>
        /// <param name="source">The texture object from which to copy.</param>
        /// <param name="srcLevel">The mipmap level to read from the source.</param>
        /// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcY">The Y coordinate of the top edge of the souce region to copy.</param>
        /// <param name="srcZ">The Z coordinate of the near edge of the souce region to copy.</param>
        /// <param name="width">The width of the region to be copied.</param>
        /// <param name="height">The height of the region to be copied.</param>
        /// <param name="depth">The depth of the region to be copied.</param>
        /// <param name="level">The mipmap level to write to the destination.</param>
        /// <param name="x">The X coordinate of the left edge of the destination region.</param>
        /// <param name="y">The Y coordinate of the top edge of the destination region.</param>
        /// <param name="z">The Z coordinate of the near edge of the destination region.</param>
        [OpenGLSupport(4.3)]
        public static void CopyImageSubData(this ITexture texture, ITexture source, int srcLevel, int srcX, int srcY, int srcZ, int width, int height, int depth, int level, int x, int y, int z)
        {
            texture.SetGLContext();
            GL.CopyImageSubData(source.Id, (uint)source.Target, srcLevel, srcX, srcY, srcZ, texture.Id, (uint)texture.Target, level, x, y, z, width, height, depth);
        }
        /// <summary>
        /// Perform a raw data copy between two images.
        /// </summary>
        /// <param name="source">The texture object from which to copy.</param>
        /// <param name="srcLevel">The mipmap level to read from the source.</param>
        /// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcY">The Y coordinate of the top edge of the souce region to copy.</param>
        /// <param name="srcZ">The Z coordinate of the near edge of the souce region to copy.</param>
        /// <param name="width">The width of the region to be copied.</param>
        /// <param name="height">The height of the region to be copied.</param>
        /// <param name="depth">The depth of the region to be copied.</param>
        /// <param name="level">The mipmap level to write to the destination.</param>
        /// <param name="x">The X coordinate of the left edge of the destination region.</param>
        /// <param name="y">The Y coordinate of the top edge of the destination region.</param>
        /// <param name="z">The Z coordinate of the near edge of the destination region.</param>
        [OpenGLSupport(4.3)]
        public static void CopyImageSubData(this ITexture texture, ITexture source, CubeMapFace srcTarget, int srcLevel, int srcX, int srcY, int srcZ, int width, int height, int depth, CubeMapFace target, int level, int x, int y, int z)
        {
            texture.SetGLContext();
            GL.CopyImageSubData(source.Id, (uint)srcTarget, srcLevel, srcX, srcY, srcZ, texture.Id, (uint)target, level, x, y, z, width, height, depth);
        }
        /// <summary>
        /// Perform a raw data copy between two images.
        /// </summary>
        /// <param name="source">The renderbuffer object from which to copy.</param>
        /// <param name="srcLevel">The mipmap level to read from the source.</param>
        /// <param name="srcX">The X coordinate of the left edge of the souce region to copy.</param>
        /// <param name="srcY">The Y coordinate of the top edge of the souce region to copy.</param>
        /// <param name="srcZ">The Z coordinate of the near edge of the souce region to copy.</param>
        /// <param name="width">The width of the region to be copied.</param>
        /// <param name="height">The height of the region to be copied.</param>
        /// <param name="depth">The depth of the region to be copied.</param>
        /// <param name="level">The mipmap level to write to the destination.</param>
        /// <param name="x">The X coordinate of the left edge of the destination region.</param>
        /// <param name="y">The Y coordinate of the top edge of the destination region.</param>
        /// <param name="z">The Z coordinate of the near edge of the destination region.</param>
        [OpenGLSupport(4.3)]
        public static void CopyImageSubData(this ITexture texture, IRenderbuffer source, int srcLevel, int srcX, int srcY, int srcZ, int width, int height, int depth, int level, int x, int y, int z)
        {
            texture.SetGLContext();
            GL.CopyImageSubData(source.Id, GLEnum.Renderbuffer, srcLevel, srcX, srcY, srcZ, texture.Id, (uint)texture.Target, level, x, y, z, width, height, depth);
        }

        /// <summary>
        /// Copy pixels into a 1D texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="size">Specifies the width of the texture image. The height of the texture image is 1.</param>
        [OpenGLSupport(1.1)]
        public static void CopyTexImage1D(this ITexture texture, int level, int x, int y, int size)
        {
            texture.SetGLContext();
            GL.CopyTexImage1D((uint)texture.Target, level, (uint)texture.InternalFormat, x, y, size, 0);
        }
        /// <summary>
        /// Copy pixels into a 2D texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture image.</param>
        /// <param name="height">Specifies the height of the texture image.</param>
        [OpenGLSupport(1.1)]
        public static void CopyTexImage2D(this ITexture texture, int level, int x, int y, int width, int height)
        {
            texture.SetGLContext();
            GL.CopyTexImage2D((uint)texture.Target, level, (uint)texture.InternalFormat, x, y, width, height, 0);
        }
        /// <summary>
        /// Copy pixels into a 2D texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the internal format of the texture.</param>
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        [OpenGLSupport(1.1)]
        public static void CopyTexImage2D(this ITexture texture, CubeMapFace target, int level, int x, int y, int width, int height)
        {
            texture.SetGLContext();
            GL.CopyTexImage2D((uint)target, level, (uint)texture.InternalFormat, x, y, width, height, 0);
        }

        /// <summary>
        /// Copy a one-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies the texel offset within the texture array.</param>
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        [OpenGLSupport(1.1)]
        public static void CopyTexSubImage1D(this ITexture texture, int level, int offset, int x, int y, int width)
        {
            texture.SetGLContext();
            GL.CopyTexSubImage1D((uint)texture.Target, level, offset, x, y, width);
        }
        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param> 
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        [OpenGLSupport(1.1)]
        public static void CopyTexSubImage2D(this ITexture texture, int level, int xOffset, int yOffset, int x, int y, int width, int height)
        {
            texture.SetGLContext();
            GL.CopyTexSubImage2D((uint)texture.Target, level, xOffset, yOffset, x, y, width, height);
        }
        /// <summary>
        /// Copy a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param> 
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        [OpenGLSupport(1.1)]
        public static void CopyTexSubImage2D(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int x, int y, int width, int height)
        {
            texture.SetGLContext();
            GL.CopyTexSubImage2D((uint)target, level, xOffset, yOffset, x, y, width, height);
        }
        /// <summary>
        /// Copy a three-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="x">Specify the x-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="y">Specify the y-axis window coordinate of the lower left corner of the rectangular region of pixels to be copied.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        [OpenGLSupport(1.2)]
        public static void CopyTexSubImage3D(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int x, int y, int width, int height)
        {
            texture.SetGLContext();
            GL.CopyTexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, x, y, width, height);
        }

        /// <summary>
        /// Return a compressed texture image.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the n-th mipmap reduction image.</param>
        /// <param name="bufferSize">Specifies the size of the buffer to receive the retrieved pixel data.</param>
        /// <returns>The compressed texture image.</returns>
        [OpenGLSupport(1.3)]
        public static T[] GetCompressedTexImage<T>(this ITexture texture, int level, int bufferSize) where T : unmanaged
        {
            texture.SetGLContext();
            T[] output = new T[bufferSize / sizeof(T)];

            fixed (T* pixelData = &output[0])
            {
                GL.GetCompressedTexImage((uint)texture.Target, level, pixelData);
            }

            return output;
        }
        /// <summary>
        /// Return a compressed texture image.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the n-th mipmap reduction image.</param>
        /// <param name="bufferSize">Specifies the size of the buffer to receive the retrieved pixel data.</param>
        /// <returns>The compressed texture image.</returns>
        [OpenGLSupport(1.3)]
        public static T[] GetCompressedTexImage<T>(this ITexture texture, CubeMapFace target, int level, int bufferSize) where T : unmanaged
        {
            texture.SetGLContext();
            T[] output = new T[bufferSize / sizeof(T)];

            fixed (T* pixelData = &output[0])
            {
                GL.GetCompressedTexImage((uint)target, level, pixelData);
            }

            return output;
        }
        /// <summary>
        /// Retrieve a sub-region of a compressed texture image from a compressed texture object.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage. Must be a multiple of the compressed block's width,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="height">Specifies the height of the texture subimage. Must be a multiple of the compressed block's height,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="depth">Specifies the depth of the texture subimage. Must be a multiple of the compressed block's depth,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="bufferSize">Specifies the size of the buffer to receive the retrieved pixel data.</param>
        /// <returns>The texture subimage.</returns>
        [OpenGLSupport(4.5)]
        public static T[] GetCompressedTextureSubImage<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, int bufferSize) where T : unmanaged
        {
            texture.SetGLContext();
            T[] output = new T[bufferSize / sizeof(T)];

            fixed (T* pixelData = &output[0])
            {
                GL.GetCompressedTextureSubImage((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, bufferSize, pixelData);
            }

            return output;
        }
        /// <summary>
        /// Retrieve a sub-region of a compressed texture image from a compressed texture object.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage. Must be a multiple of the compressed block's width,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="height">Specifies the height of the texture subimage. Must be a multiple of the compressed block's height,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="depth">Specifies the depth of the texture subimage. Must be a multiple of the compressed block's depth,
        /// unless the offset is zero and the size equals the texture image size.</param>
        /// <param name="bufferSize">Specifies the size of the buffer to receive the retrieved pixel data.</param>
        /// <returns>The texture subimage.</returns>
        [OpenGLSupport(4.5)]
        public static T[] GetCompressedTextureSubImage<T>(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, int bufferSize) where T : unmanaged
        {
            texture.SetGLContext();
            T[] output = new T[bufferSize / sizeof(T)];

            fixed (T* pixelData = &output[0])
            {
                GL.GetCompressedTextureSubImage((uint)target, level, xOffset, yOffset, zOffset, width, height, depth, bufferSize, pixelData);
            }

            return output;
        }

        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <returns>The texture image. Should be of the type specified by <paramref name="type"/>.</returns>
        [OpenGLSupport(1.0)]
        public static GLArray<T> GetTexImage<T>(this ITexture texture, int level, BaseFormat format, TextureData type) where T : unmanaged
        {
            texture.SetGLContext();
            GLArray<T> output = new GLArray<T>(
                (texture.GetWidth(level) * format.GetSize() * type.GetSize()) / sizeof(T),
                texture.GetHeight(level),
                texture.GetDepth(level));

            GL.GetTexImage((uint)texture.Target, level, (uint)format, (uint)type, output);

            return output;
        }
        /// <summary>
        /// Return a texture image.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="face">The cubemap face to referance.</param>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="format">Specifies a pixel format for the returned data.</param>
        /// <param name="type">Specifies a pixel type for the returned data.</param>
        /// <returns>The texture image. Should be of the type specified by <paramref name="type"/>.</returns>
        [OpenGLSupport(1.0)]
        public static GLArray<T> GetTexImage<T>(this ITexture texture, CubeMapFace face, int level, BaseFormat format, TextureData type) where T : unmanaged
        {
            texture.SetGLContext();
            GLArray<T> output = new GLArray<T>(
                (texture.GetWidth(level) * format.GetSize() * type.GetSize()) / sizeof(T),
                texture.GetHeight(level),
                texture.GetDepth(level));

            GL.GetTexImage((uint)face, level, (uint)format, (uint)type, output);

            return output;
        }
        /// <summary>
        /// Retrieve a sub-region of a texture image from a texture object.
        /// </summary>
        /// <typeparam name="T">The type of the returned array.</typeparam>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <returns>The texture subimage. Should be of the type specified by <paramref name="type"/>.</returns>
        [OpenGLSupport(4.5)]
        public static GLArray<T> GetTextureSubImage3<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, BaseFormat format, TextureData type) where T : unmanaged
        {
            int channelByte = format.GetSize() * type.GetSize();

            GLArray<T> output = new GLArray<T>(
                (width * channelByte) / sizeof(T),
                height, depth);

            GL.GetTextureSubImage(texture.Id, level, xOffset, yOffset, zOffset, width, height, depth, (uint)format, (uint)type, width * height * depth * channelByte, output);

            return output;
        }

        /// <summary>
        /// Generate mipmaps for a specified texture object.
        /// </summary>
        [OpenGLSupport(3.0)]
        public static void GenerateMipmap(this ITexture texture)
        {
            texture.SetGLContext();
            GL.GenerateMipmap((uint)texture.Target);
        }

        /// <summary>
        /// Invalidate the entirety a texture image.
        /// </summary>
        /// <param name="level">The level of detail of the texture object to invalidate.</param>
        [OpenGLSupport(4.3)]
        public static void InvalidateTexImage(this ITexture texture, int level)
        {
            GL.InvalidateTexImage(texture.Id, level);
        }
        /// <summary>
        /// Invalidate a region of a texture image.
        /// </summary>
        /// <param name="level">The level of detail of the texture object within which the region resides.</param>
        /// <param name="xOffset">The X offset of the region to be invalidated.</param>
        /// <param name="yOffset">The Y offset of the region to be invalidated.</param>
        /// <param name="zOffset">The Z offset of the region to be invalidated.</param>
        /// <param name="width">The width of the region to be invalidated.</param>
        /// <param name="height">The height of the region to be invalidated.</param>
        /// <param name="depth">The depth of the region to be invalidated.</param>
        [OpenGLSupport(4.3)]
        public static void InvalidateTexSubImage(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth)
        {
            GL.InvalidateTexSubImage(texture.Id, level, xOffset, yOffset, zOffset, width, height, depth);
        }

        /// <summary>
        /// Attach a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
        /// <param name="">Specifies the internal format of the data in the store belonging to <paramref name="buffer"/>.</param>
        [OpenGLSupport(3.1)]
        public static void TexBuffer(this ITexture texture, IBuffer buffer)
        {
            texture.SetGLContext();
            GL.TexBuffer((uint)texture.Target, (uint)texture.InternalFormat, buffer.Id);
        }
        /// <summary>
        /// Attach a range of a buffer object's data store to a buffer texture object.
        /// </summary>
        /// <param name="buffer">Specifies the name of the buffer object whose storage to attach to the active buffer texture.</param>
        /// <param name="">Specifies the internal format of the data in the store belonging to <paramref name="buffer"/>.</param>
        /// <param name="offset">Specifies the offset of the start of the range of the buffer's data store to attach.</param>
        /// <param name="size">Specifies the size of the range of the buffer's data store to attach.</param>
        [OpenGLSupport(4.3)]
        public static void TexBufferRange(this ITexture texture, IBuffer buffer, int offset, int size)
        {
            texture.SetGLContext();
            GL.TexBufferRange((uint)texture.Target, (uint)texture.InternalFormat, buffer.Id, offset, size);
        }

        /// <summary>
        /// Specify a one-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage1D<T>(this ITexture texture, int level, int size, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage1D((uint)texture.Target, level, (int)texture.InternalFormat, size, 0, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a one-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage1D(this ITexture texture, int level, int size, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexImage1D((uint)texture.Target, level, (int)texture.InternalFormat, size, 0, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a one-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="size">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage1D<T>(this ITexture texture, int level, int size, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage1D((uint)texture.Target, level, (int)texture.InternalFormat, size, 0, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> targets. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D<T>(this ITexture texture, int level, int width, int height, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> target. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D<T>(this ITexture texture, CubeMapFace target, int level, int width, int height, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> targets. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D(this ITexture texture, int level, int width, int height, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> target. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D(this ITexture texture, CubeMapFace target, int level, int width, int height, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> targets. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D<T>(this ITexture texture, int level, int width, int height, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, data);
        }
        /// <summary>
        /// Specify a two-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image. 
        /// If target is <see cref="TextureTarget.Rectangle"/>, level must be 0.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support texture images that are at least 1024 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image, or the number of layers in a texture array, 
        /// in the case of the <see cref="TextureTarget.Array1D"/> target. 
        /// All implementations support 2D texture images that are at least 1024 texels high, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.0)]
        public static void TexImage2D<T>(this ITexture texture, CubeMapFace target, int level, int width, int height, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage2D((uint)target, level, (int)texture.InternalFormat, width, height, 0, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Establish the data storage, format, dimensions, and number of samples of a multisample texture's image.
        /// </summary>
        /// <param name="target">Specifies the target of the operation.</param>
        /// <param name="samples">The number of samples in the multisample texture's image.</param>
        /// <param name="">The internal format to be used to store the multisample texture's image. 
        /// It must specify a colour-renderable, depth-renderable, or stencil-renderable format.</param>
        /// <param name="width">The width of the multisample texture's image, in texels.</param>
        /// <param name="height">The height of the multisample texture's image, in texels.</param>
        /// <param name="fixedsampleLocations">Specifies whether the image will use identical sample locations and the same number of 
        /// samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        [OpenGLSupport(3.2)]
        public static void TexImage2DMultisample(this ITexture texture, int samples, int width, int height, bool fixedsampleLocations)
        {
            texture.SetGLContext();
            GL.TexImage2DMultisample((uint)texture.Target, samples, (uint)texture.InternalFormat, width, height, fixedsampleLocations);
        }

        /// <summary>
        /// Specify a three-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 256 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image, or the number of layers in a texture array. 
        /// All implementations support 3D texture images that are at least 256 texels deep, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.2)]
        public static void TexImage3D<T>(this ITexture texture, int level, int width, int height, int depth, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage3D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, depth, 0, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a three-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 256 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image, or the number of layers in a texture array. 
        /// All implementations support 3D texture images that are at least 256 texels deep, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.2)]
        public static void TexImage3D(this ITexture texture, int level, int width, int height, int depth, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexImage3D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, depth, 0, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a three-dimensional texture image.
        /// </summary>
        /// <param name="target">Specifies the target texture.</param>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="">Specifies the number of colour components in the texture.</param>
        /// <param name="width">Specifies the width of the texture image. All implementations support 3D texture images that are at least 16 texels wide.</param>
        /// <param name="height">Specifies the height of the texture image. All implementations support 3D texture images that are at least 256 texels high.</param>
        /// <param name="depth">Specifies the depth of the texture image, or the number of layers in a texture array. 
        /// All implementations support 3D texture images that are at least 256 texels deep, and texture arrays that are at least 256 layers deep.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        [OpenGLSupport(1.2)]
        public static void TexImage3D<T>(this ITexture texture, int level, int width, int height, int depth, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexImage3D((uint)texture.Target, level, (int)texture.InternalFormat, width, height, depth, 0, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Establish the data storage, format, dimensions, and number of samples of a multisample texture's image.
        /// </summary>
        /// <param name="target">Specifies the target of the operation.</param>
        /// <param name="samples">The number of samples in the multisample texture's image.</param>
        /// <param name="">The internal format to be used to store the multisample texture's image. 
        /// It must specify a colour-renderable, depth-renderable, or stencil-renderable format.</param>
        /// <param name="width">The width of the multisample texture's image, in texels.</param>
        /// <param name="height">The height of the multisample texture's image, in texels.</param>
        /// <param name="depth">The depth of the multisample texture's image, in layers.</param>
        /// <param name="fixedsampleLocations">Specifies whether the image will use identical sample locations and the same number of 
        /// samples for all texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        [OpenGLSupport(3.2)]
        public static void TexImage3DMultisample(this ITexture texture, int samples, int width, int height, int depth, bool fixedsampleLocations)
        {
            texture.SetGLContext();
            GL.TexImage3DMultisample((uint)texture.Target, samples, (uint)texture.InternalFormat, width, height, depth, fixedsampleLocations);
        }

        /// <summary>
        /// Simultaneously specify storage for all levels of a one-dimensional texture.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture object is bound for <see cref="TexStorage1D(ITexture, TextureGL.Target1D, int, int)"/>.</param>
        /// <param name="levels">Specify the number of texture levels.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="size">Specifies the width of the texture, in texels.</param>
        public static void TexStorage1D(this ITexture texture, int levels, int size)
        {
            texture.SetGLContext();
            GL.TexStorage1D((uint)texture.Target, levels, (uint)texture.InternalFormat, size);
        }
        /// <summary>
        /// Simultaneously specify storage for all levels of a two-dimensional or one-dimensional array texture.
        /// </summary>
        /// <param name="levels">Specify the number of texture levels.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="width">Specifies the width of the texture, in texels.</param>
        /// <param name="height">Specifies the height of the texture, in texels.</param>
        public static void TexStorage2D(this ITexture texture, int levels, int width, int height)
        {
            texture.SetGLContext();
            GL.TexStorage2D((uint)texture.Target, levels, (uint)texture.InternalFormat, width, height);
        }
        /// <summary>
        /// Simultaneously specify storage for all levels of a two-dimensional or one-dimensional array texture.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture object is bound for <see cref="TexStorage2D(ITexture, CubeMapFace, int, int, int)"/>.</param>
        /// <param name="levels">Specify the number of texture levels.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="width">Specifies the width of the texture, in texels.</param>
        /// <param name="height">Specifies the height of the texture, in texels.</param>
        public static void TexStorage2D(this ITexture texture, CubeMapFace target, int levels, int width, int height)
        {
            texture.SetGLContext();
            GL.TexStorage2D((uint)target, levels, (uint)texture.InternalFormat, width, height);
        }
        /// <summary>
        /// Specify storage for a two-dimensional multisample texture.
        /// </summary>
        /// <param name="samples">Specify the number of samples in the texture.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="width">Specifies the width of the texture, in texels.</param>
        /// <param name="height">Specifies the height of the texture, in texels.</param>
        /// <param name="fixedsampleLocations">Specifies whether the image will use identical sample locations and the same number of samples for all 
        /// texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public static void TexStorage2DMultisample(this ITexture texture, int samples, int width, int height, bool fixedsampleLocations)
        {
            texture.SetGLContext();
            GL.TexStorage2DMultisample((uint)texture.Target, samples, (uint)texture.InternalFormat, width, height, fixedsampleLocations);
        }
        /// <summary>
        /// Simultaneously specify storage for all levels of a three-dimensional, two-dimensional array or cube-map array texture.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture object is bound for <see cref="TexStorage3D(ITexture, TextureGL.Target3D, int, int, int, int)"/>.</param>
        /// <param name="levels">Specify the number of texture levels.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="width">Specifies the width of the texture, in texels.</param>
        /// <param name="height">Specifies the height of the texture, in texels.</param>
        /// <param name="depth">Specifies the depth of the texture, in texels.</param>
        public static void TexStorage3D(this ITexture texture, int levels, int width, int height, int depth)
        {
            texture.SetGLContext();
            GL.TexStorage3D((uint)texture.Target, levels, (uint)texture.InternalFormat, width, height, depth);
        }
        /// <summary>
        /// Specify storage for a two-dimensional multisample array texture.
        /// </summary>
        /// <param name="target">Specifies the target to which the texture object is bound for 
        /// <see cref="TexStorage3DMultisample(ITexture, TextureGL.Target3DMultisample, int, int, int, int, bool)"/>.</param>
        /// <param name="samples">Specify the number of samples in the texture.</param>
        /// <param name="">Specifies the sized internal format to be used to store texture image data.</param>
        /// <param name="width">Specifies the width of the texture, in texels.</param>
        /// <param name="height">Specifies the height of the texture, in texels.</param>
        /// <param name="depth">Specifies the depth of the texture, in layers.</param>
        /// <param name="fixedsampleLocations">Specifies whether the image will use identical sample locations and the same number of samples for all 
        /// texels in the image, and the sample locations will not depend on the internal format or size of the image.</param>
        public static void TexStorage3DMultisample(this ITexture texture, int samples, int width, int height, int depth, bool fixedsampleLocations)
        {
            texture.SetGLContext();
            GL.TexStorage3DMultisample((uint)texture.Target, samples, (uint)texture.InternalFormat, width, height, depth, fixedsampleLocations);
        }

        /// <summary>
        /// Specify a one-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage1D<T>(this ITexture texture, int level, int offset, int size, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage1D((uint)texture.Target, level, offset, size, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a one-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage1D(this ITexture texture, int level, int offset, int size, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexSubImage1D((uint)texture.Target, level, offset, size, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a one-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="offset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="size">Specifies the width of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage1D<T>(this ITexture texture, int level, int offset, int size, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage1D((uint)texture.Target, level, offset, size, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D<T>(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D<T>(this ITexture texture, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)texture.Target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, data);
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D<T>(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a two-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage2D<T>(this ITexture texture, CubeMapFace target, int level, int xOffset, int yOffset, int width, int height, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage2D((uint)target, level, xOffset, yOffset, width, height, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Specify a three-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage3D<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, BaseFormat format, TextureData type, T* dataPtr) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)format, (uint)type, dataPtr);
        }
        /// <summary>
        /// Specify a three-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="dataPtr">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage3D(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, BaseFormat format, TextureData type, IntPtr dataPtr)
        {
            texture.SetGLContext();
            GL.TexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)format, (uint)type, dataPtr.ToPointer());
        }
        /// <summary>
        /// Specify a three-dimensional texture subimage.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        /// <param name="xOffset">Specifies a texel offset in the x direction within the texture array.</param>
        /// <param name="yOffset">Specifies a texel offset in the y direction within the texture array.</param>
        /// <param name="zOffset">Specifies a texel offset in the z direction within the texture array.</param>
        /// <param name="width">Specifies the width of the texture subimage.</param>
        /// <param name="height">Specifies the height of the texture subimage.</param>
        /// <param name="depth">Specifies the depth of the texture subimage.</param>
        /// <param name="format">Specifies the format of the pixel data.</param>
        /// <param name="type">Specifies the data type of the pixel data.</param>
        /// <param name="data">Specifies a pointer to the image data in memory.</param>
        public static void TexSubImage3D<T>(this ITexture texture, int level, int xOffset, int yOffset, int zOffset, int width, int height, int depth, BaseFormat format, TextureData type, GLArray<T> data) where T : unmanaged
        {
            texture.SetGLContext();
            GL.TexSubImage3D((uint)texture.Target, level, xOffset, yOffset, zOffset, width, height, depth, (uint)format, (uint)type, data);
        }

        /// <summary>
        /// Initialize a texture as a data alias of another texture's data store.
        /// </summary>
        /// <param name="original">Specifies the texture object of which to make a view.</param>
        /// <param name="">Specifies the internal format for the newly created view.</param>
        /// <param name="minLevel">Specifies lowest level of detail of the view.</param>
        /// <param name="numLevels">Specifies the number of levels of detail to include in the view.</param>
        /// <param name="minLayer">Specifies the index of the first layer to include in the view.</param>
        /// <param name="numbLayers">Specifies the number of layers to include in the view.</param>
        public static void TextureView(this ITexture texture, ITexture original, uint minLevel, uint numLevels, uint minLayer, uint numbLayers)
        {
            texture.SetGLContext();
            GL.TextureView(texture.Id, (uint)texture.Target, original.Id, (uint)texture.InternalFormat, minLevel, numLevels, minLayer, numbLayers);
        }

        //
        // Parameter Sets
        //

        /// <summary>
        /// Specifies the mode used to read from depth-stencil format textures.
        /// </summary>
        public static void SetDepthStencilMode(this ITexture texture, DepthStencilMode value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.DepthStencilTextureMode, (int)value);
        }

        /// <summary>
        /// Specifies the index of the lowest defined mipmap level.
        /// </summary>
        /// <param name="value"></param>
        public static void SetBaseLevel(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureBaseLevel, value);
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the values of 
        /// <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> and <paramref name="a"/> are used.
        /// </summary>
        /// <remarks>
        /// This stores the value as an integer.
        /// </remarks>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static void SetBorderColourI(this ITexture texture, int r, int g, int b, int a)
        {
            texture.SetGLContext();
            int[] colour = new int[] { r, g, b, a };

            fixed (int* parameter = &colour[0])
            {
                GL.TexParameterIiv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the values of 
        /// <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> and <paramref name="a"/> are used.
        /// </summary>
        /// <remarks>
        /// This stores the value as an integer.
        /// </remarks>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static void SetBorderColourI(this ITexture texture, byte r, byte g, byte b, byte a)
        {
            texture.SetGLContext();
            int[] colour = new int[] { r, g, b, a };

            fixed (int* parameter = &colour[0])
            {
                GL.TexParameterIiv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the value of <paramref name="colour"/> is used.
        /// </summary>
        /// <remarks>
        /// This stores the value as an integer.
        /// </remarks>
        public static void SetBorderColourI(this ITexture texture, Colour colour)
        {
            texture.SetGLContext();
            int[] iColour = new int[] { colour.R, colour.G, colour.B, colour.A };

            fixed (int* parameter = &iColour[0])
            {
                GL.TexParameterIiv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the value of <paramref name="colour"/> is used.
        /// </summary>
        /// <remarks>
        /// This stores the value as an integer.
        /// </remarks>
        public static void SetBorderColourI(this ITexture texture, ColourF colour)
        {
            texture.SetGLContext();
            // Convert to integer equivelents
            Colour c = (Colour)colour;

            int[] iColour = new int[] { c.R, c.G, c.B, c.A };

            fixed (int* parameter = &iColour[0])
            {
                GL.TexParameterIiv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the values of 
        /// <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> and <paramref name="a"/> are used.
        /// </summary>
        /// <remarks>
        /// This stores the value as a float.
        /// </remarks>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static void SetBorderColour(this ITexture texture, int r, int g, int b, int a)
        {
            texture.SetGLContext();
            int[] colour = new int[] { r, g, b, a };

            fixed (int* parameter = &colour[0])
            {
                GL.TexParameteriv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the values of 
        /// <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> and <paramref name="a"/> are used.
        /// </summary>
        /// <remarks>
        /// This stores the value as a float.
        /// </remarks>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static void SetBorderColour(this ITexture texture, byte r, byte g, byte b, byte a)
        {
            texture.SetGLContext();
            int[] colour = new int[] { r, g, b, a };

            fixed (int* parameter = &colour[0])
            {
                GL.TexParameteriv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the values of 
        /// <paramref name="r"/>, <paramref name="g"/>, <paramref name="b"/> and <paramref name="a"/> are used.
        /// </summary>
        /// <remarks>
        /// This stores the value as a float.
        /// </remarks>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public static void SetBorderColour(this ITexture texture, float r, float g, float b, float a)
        {
            texture.SetGLContext();
            float[] colour = new float[] { r, g, b, a };

            fixed (float* parameter = &colour[0])
            {
                GL.TexParameterfv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the value of <paramref name="colour"/> is used.
        /// </summary>
        /// <remarks>
        /// This stores the value as a float.
        /// </remarks>
        public static void SetBorderColour(this ITexture texture, Colour colour)
        {
            texture.SetGLContext();
            int[] iColour = new int[] { colour.R, colour.G, colour.B, colour.A };

            fixed (int* parameter = &iColour[0])
            {
                GL.TexParameteriv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// If a texel is sampled from the border of the texture, the value of <paramref name="colour"/> is used.
        /// </summary>
        /// <remarks>
        /// This stores the value as a float.
        /// </remarks>
        public static void SetBorderColour(this ITexture texture, ColourF colour)
        {
            texture.SetGLContext();
            float[] iColour = new float[] { colour.R, colour.G, colour.B, colour.A };

            fixed (float* parameter = &iColour[0])
            {
                GL.TexParameterfv((uint)texture.Target, GLEnum.TextureBorderColour, parameter);
            }
        }

        /// <summary>
        /// Specifies a fixed bias value that is to be added to the level-of-detail parameter for the texture before texture sampling.
        /// </summary>
        public static void SetLodBias(this ITexture texture, float value)
        {
            texture.SetGLContext();
            GL.TexParameterf((uint)texture.Target, GLEnum.TextureLodBias, value);
        }

        /// <summary>
        /// The texture minifying function is used whenever the level-of-detail function used when sampling from the texture determines that the texture should be minified.
        /// </summary>
        public static void SetMinFilter(this ITexture texture, TextureSampling value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureMinFilter, (int)value);
        }

        /// <summary>
        /// The texture magnification function is used whenever the level-of-detail function used when sampling from the texture determines that the texture should be magified.
        /// </summary>
        public static void SetMagFilter(this ITexture texture, TextureSampling value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureMagFilter, (int)value);
        }

        /// <summary>
        /// Sets the minimum level-of-detail parameter. This floating-point value limits the selection of highest resolution mipmap (lowest mipmap level).
        /// </summary>
        public static void SetMinLod(this ITexture texture, float value)
        {
            texture.SetGLContext();
            GL.TexParameterf((uint)texture.Target, GLEnum.TextureMinLod, value);
        }

        /// <summary>
        /// Sets the maximum level-of-detail parameter. This floating-point value limits the selection of the lowest resolution mipmap (highest mipmap level).
        /// </summary>
        public static void SetMaxLod(this ITexture texture, float value)
        {
            texture.SetGLContext();
            GL.TexParameterf((uint)texture.Target, GLEnum.TextureMaxLod, value);
        }

        /// <summary>
        /// Sets the index of the highest defined mipmap level.
        /// </summary>
        public static void SetMaxLevel(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureMaxLevel, value);
        }

        /// <summary>
        /// Sets the swizzle that will be applied to the red component of a texel before it is returned to the shader.
        /// </summary>
        public static void SetSwizzleRed(this ITexture texture, Swizzle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureSwizzleR, (int)value);
        }

        /// <summary>
        /// Sets the swizzle that will be applied to the green component of a texel before it is returned to the shader.
        /// </summary>
        public static void SetSwizzleGreen(this ITexture texture, Swizzle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureSwizzleG, (int)value);
        }

        /// <summary>
        /// Sets the swizzle that will be applied to the blue component of a texel before it is returned to the shader.
        /// </summary>
        public static void SetSwizzleBlue(this ITexture texture, Swizzle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureSwizzleB, (int)value);
        }

        /// <summary>
        /// Sets the swizzle that will be applied to the alpha component of a texel before it is returned to the shader.
        /// </summary>
        public static void SetSwizzleAlpha(this ITexture texture, Swizzle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureSwizzleA, (int)value);
        }

        /// <summary>
        /// Sets the swizzle that will be applied to the red, green,e and alpha component of a texel before it is returned to the shader.
        /// </summary>
        public static void SetSwizzle(this ITexture texture, Swizzle r, Swizzle g, Swizzle b, Swizzle a)
        {
            texture.SetGLContext();
            int[] values = new int[] { (int)r, (int)g, (int)b, (int)a };

            fixed (int* parameters = &values[0])
            {
                GL.TexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleA, parameters);
            }
        }

        /// <summary>
        /// Sets the wrap parameter for texture coordinate s.
        /// </summary>
        /// <param name="value"></param>
        public static void SetWrapS(this ITexture texture, WrapStyle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureWrapS, (int)value);
        }

        /// <summary>
        /// Sets the wrap parameter for texture coordinate t.
        /// </summary>
        /// <param name="value"></param>
        public static void SetWrapT(this ITexture texture, WrapStyle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureWrapT, (int)value);
        }

        /// <summary>
        /// Sets the wrap parameter for texture coordinate r.
        /// </summary>
        /// <param name="value"></param>
        public static void SetWrapR(this ITexture texture, WrapStyle value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureWrapR, (int)value);
        }

        /// <summary>
        /// Sets the base level of a texture view relative to its parent.
        /// </summary>
        public static void SetViewMinLevel(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureViewMinLevel, value);
        }

        /// <summary>
        /// Sets the number of levels of detail of a texture view.
        /// </summary>
        public static void SetViewNumLevels(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureViewNumLevels, value);
        }

        /// <summary>
        /// Sets the first level of a texture array view relative to its parent.
        /// </summary>
        public static void SetViewMinLayer(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureViewMinLayer, value);
        }

        /// <summary>
        /// Sets the number of layers in a texture array view.
        /// </summary>
        public static void SetViewNumLayers(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureViewNumLayers, value);
        }

        /// <summary>
        /// Sets the number of immutable texture levels in a texture view.
        /// </summary>
        public static void SetViewImmutableLevels(this ITexture texture, int value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureImmutableLevels, value);
        }

        /// <summary>
        /// Specifies the comparison operator used when <see cref="SetComparisonMode(ComparisonMode)"/> is set to <see cref="ComparisonMode.CompareToDepth"/>.
        /// </summary>
        /// <param name="value"></param>
        public static void SetComparisonFunction(this ITexture texture, ComparisonFunction value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureCompareFunc, (int)value);
        }

        /// <summary>
        /// Specifies the texture comparison mode for currently bound depth textures.
        /// </summary>
        public static void SetComparisonMode(this ITexture texture, ComparisonMode value)
        {
            texture.SetGLContext();
            GL.TexParameteri((uint)texture.Target, GLEnum.TextureCompareMode, (int)value);
        }

        //
        // Parameter Gets
        //


        /// <summary>
        /// Returns the single-value depth stencil texture mode.
        /// </summary>
        public static DepthStencilMode GetDepthStencilMode(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.DepthStencilTextureMode, &output);

            return (DepthStencilMode)output;
        }

        /// <summary>
        /// Returns the single-valued base texture mipmap level.
        /// </summary>
        public static int GetBaseLevel(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureBaseLevel, &output);

            return output;
        }

        private const double IntToByte = byte.MaxValue / int.MaxValue;

        /// <summary>
        /// Returns the RGBA colour of the texture border.
        /// </summary>
        public static Colour GetBorderColourI(this ITexture texture)
        {
            texture.SetGLContext();
            int[] colour = new int[4];

            fixed (int* get = &colour[0])
            {
                GL.GetTexParameterIiv((uint)texture.Target, GLEnum.TextureBorderColour, get);
            }

            return new Colour(
                (byte)Math.Round(colour[0] * IntToByte),    // R
                (byte)Math.Round(colour[1] * IntToByte),    // G
                (byte)Math.Round(colour[2] * IntToByte),    // B
                (byte)Math.Round(colour[3] * IntToByte));   // A
        }

        /// <summary>
        /// Returns the RGBA colour of the texture border.
        /// </summary>
        public static ColourF GetBorderColour(this ITexture texture)
        {
            texture.SetGLContext();
            float[] colour = new float[4];

            fixed (float* get = &colour[0])
            {
                GL.GetTexParameterfv((uint)texture.Target, GLEnum.TextureBorderColour, get);
            }

            return new ColourF(colour[0], colour[1], colour[2], colour[3]);
        }

        /// <summary>
        /// Returns the single-value fixed bias that is added to the level-of-detail parameter for the texture before texture sampling.
        /// </summary>
        public static float GetLodBias(this ITexture texture)
        {
            texture.SetGLContext();
            float output;

            GL.GetTexParameterfv((uint)texture.Target, GLEnum.TextureLodBias, &output);

            return output;
        }

        /// <summary>
        /// Returns the single-valued texture minification filter.
        /// </summary>
        public static TextureSampling GetMinFilter(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureMinFilter, &output);

            return (TextureSampling)output;
        }

        /// <summary>
        /// Returns the single-valued texture magnification filter.
        /// </summary>
        public static TextureSampling GetMagFilter(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureMagFilter, &output);

            return (TextureSampling)output;
        }

        /// <summary>
        /// Returns the single-valued texture minimum level-of-detail value.
        /// </summary>
        public static float GetMinLod(this ITexture texture)
        {
            texture.SetGLContext();
            float output;

            GL.GetTexParameterfv((uint)texture.Target, GLEnum.TextureMinLod, &output);

            return output;
        }

        /// <summary>
        /// Returns the single-valued texture maximum level-of-detail value.
        /// </summary>
        public static float GetMaxLod(this ITexture texture)
        {
            texture.SetGLContext();
            float output;

            GL.GetTexParameterfv((uint)texture.Target, GLEnum.TextureMaxLod, &output);

            return output;
        }

        /// <summary>
        /// Returns the single-valued maximum texture mipmap array level.
        /// </summary>
        public static int GetMaxLevel(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureMaxLevel, &output);

            return output;
        }

        /// <summary>
        /// Returns the red component swizzle.
        /// </summary>
        public static Swizzle GetSwizzleRed(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleR, &output);

            return (Swizzle)output;
        }

        /// <summary>
        /// Returns the green component swizzle.
        /// </summary>
        public static Swizzle GetSwizzleGreen(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleG, &output);

            return (Swizzle)output;
        }

        /// <summary>
        /// Returns the blue component swizzle.
        /// </summary>
        public static Swizzle GetSwizzleBlue(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleB, &output);

            return (Swizzle)output;
        }

        /// <summary>
        /// Returns the alpha component swizzle.
        /// </summary>
        public static Swizzle GetSwizzleAlpha(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleA, &output);

            return (Swizzle)output;
        }

        /// <summary>
        /// Returns the component swizzle for all channels in a single query.
        /// </summary>
        public static void GetSwizzle(this ITexture texture, out Swizzle r, out Swizzle g, out Swizzle b, out Swizzle a)
        {
            texture.SetGLContext();
            int[] outputs = new int[4];

            fixed (int* gets = &outputs[0])
            {
                GL.TexParameteriv((uint)texture.Target, GLEnum.TextureSwizzleA, gets);
            }

            r = (Swizzle)outputs[0];
            g = (Swizzle)outputs[1];
            b = (Swizzle)outputs[2];
            a = (Swizzle)outputs[3];
        }

        /// <summary>
        /// Returns the single-valued wrapping function for texture coordinate s.
        /// </summary>
        public static WrapStyle GetWrapS(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureWrapS, &output);

            return (WrapStyle)output;
        }

        /// <summary>
        /// Returns the single-valued wrapping function for texture coordinate t.
        /// </summary>
        public static WrapStyle GetWrapT(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureWrapT, &output);

            return (WrapStyle)output;
        }

        /// <summary>
        /// Returns the single-valued wrapping function for texture coordinate r.
        /// </summary>
        public static WrapStyle GetWrapR(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureWrapR, &output);

            return (WrapStyle)output;
        }

        /// <summary>
        /// Returns a single-valued base level of a texture view relative to its parent.
        /// </summary>
        public static int GetViewMinLevel(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureViewMinLevel, &output);

            return output;
        }

        /// <summary>
        /// Returns a single-valued number of levels of detail of a texture view.
        /// </summary>
        public static int GetViewNumLevels(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureViewNumLevels, &output);

            return output;
        }

        /// <summary>
        /// Returns a single-valued first level of a texture array view relative to its parent.
        /// </summary>
        public static int GetViewMinLayer(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureViewMinLayer, &output);

            return output;
        }

        /// <summary>
        /// Returns a single-valued number of layers in a texture array view.
        /// </summary>
        public static int GetViewNumLayers(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureViewNumLayers, &output);

            return output;
        }

        /// <summary>
        /// Returns a single-valued number of immutable texture levels in a texture view.
        /// </summary>
        public static int GetViewImmutableLevels(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureImmutableLevels, &output);

            return output;
        }

        /// <summary>
        /// Returns a single-valued texture comparison function.
        /// </summary>
        public static ComparisonFunction GetComparisonFunction(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureCompareFunc, &output);

            return (ComparisonFunction)output;
        }

        /// <summary>
        /// Returns a single-valued texture comparison mode.
        /// </summary>
        public static ComparisonMode GetComparisonMode(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureCompareMode, &output);

            return (ComparisonMode)output;
        }

        /// <summary>
        /// Returns the matching criteria use for the texture when used as an image texture.
        /// </summary>
        public static FormatCompatibilityType GetFormatCompatibilityType(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.ImageFormatCompatibilityType, &output);

            return (FormatCompatibilityType)output;
        }

        /// <summary>
        /// Returns <see cref="true"/> if the texture has an immutable format, otherwise <see cref="false"/>.
        /// </summary>
        public static bool IsImmutableFormat(this ITexture texture)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexParameteriv((uint)texture.Target, GLEnum.TextureImmutableFormat, &output);

            return output > 0;
        }

        /// <summary>
        /// Returns a single value, the width of the texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetWidth(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureWidth, &output);

            return output;
        }

        /// <summary>
        /// Returns a single value, the height of the texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetHeight(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureHeight, &output);

            return output;
        }

        /// <summary>
        /// Returns a single value, the depth of the texture image.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetDepth(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureDepth, &output);

            return output;
        }

        /// <summary>
        /// The data type used to store the red component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static ChannelType GetRedType(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureRedType, &output);

            return (ChannelType)output;
        }

        /// <summary>
        /// The data type used to store the green component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static ChannelType GetGreenType(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureGreenType, &output);

            return (ChannelType)output;
        }

        /// <summary>
        /// The data type used to store the blue component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static ChannelType GetBlueType(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureBlueType, &output);

            return (ChannelType)output;
        }

        /// <summary>
        /// The data type used to store the alpha component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static ChannelType GetAlphaType(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureAlphaType, &output);

            return (ChannelType)output;
        }

        /// <summary>
        /// The data type used to store the depth component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static ChannelType GetDepthType(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureDepthType, &output);

            return (ChannelType)output;
        }

        /// <summary>
        /// The internal storage resolution of the red component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetRedSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureRedSize, &output);

            return output;
        }

        /// <summary>
        /// The internal storage resolution of the green component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetGreenSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureGreenSize, &output);

            return output;
        }

        /// <summary>
        /// The internal storage resolution of the blue component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetBlueSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureBlueSize, &output);

            return output;
        }

        /// <summary>
        /// The internal storage resolution of the alpha component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetAlphaSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureAlphaSize, &output);

            return output;
        }

        /// <summary>
        /// The internal storage resolution of the depth component.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetDepthSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureDepthSize, &output);

            return output;
        }

        /// <summary>
        /// Returns a single boolean value indicating if the texture image is stored in a compressed internal format.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static bool GetIsCompressed(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureCompressed, &output);

            return output > 0;
        }

        /// <summary>
        /// Returns a single integer value, the number of unsigned bytes of the compressed texture image that would be returned from <see cref="GetCompressedTexImage{T}(ITexture, int)"/>.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetCompressedImageSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureCompressedImageSize, &output);

            return output;
        }

        /// <summary>
        /// Returns a single integer value, the offset into the data store of the buffer bound to a buffer texture.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetBufferOffset(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureBufferOffset, &output);

            return output;
        }

        /// <summary>
        /// Returns a single integer value, the size of the range of a data store of the buffer bound to a buffer texture.
        /// </summary>
        /// <param name="level">Specifies the level-of-detail number of the desired image. Level 0 is the base image level. Level n is the nth mipmap reduction image.</param>
        public static int GetBufferSize(this ITexture texture, int level)
        {
            texture.SetGLContext();
            int output;

            GL.GetTexLevelParameteriv((uint)texture.Target, level, GLEnum.TextureBufferSize, &output);

            return output;
        }
    }
}