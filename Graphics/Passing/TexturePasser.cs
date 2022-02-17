﻿using System;
using Zene.Graphics.OpenGL;

namespace Zene.Graphics.Passing
{
    /// <summary>
    /// An object for coping and externally managing texture objects.
    /// </summary>
    public class TexturePasser : ITexture
    {
        public TexturePasser(ITexture texture)
        {
            Id = texture.Id;
            ReferanceSlot = texture.ReferanceSlot;
            Target = texture.Target;
            InternalFormat = texture.InternalFormat;
        }
        public TexturePasser(TextureTarget target, uint id, TextureFormat format)
        {
            Id = id;
            Target = target;
            InternalFormat = format;
        }
        public TexturePasser(TextureTarget target, uint id, TextureFormat format, TextureData type)
        {
            Id = id;
            Target = target;
            InternalFormat = format;
            _dataType = type;
        }

        public uint Id { get; }
        public uint ReferanceSlot { get; private set; } = 0;
        public TextureTarget Target { get; }
        public TextureFormat InternalFormat { get; }
        private readonly TextureData _dataType = 0;

        public void Bind(uint slot)
        {
            if (!this.Bound(slot))
            {
                GL.ActiveTexture(GLEnum.Texture0 + slot);
                ReferanceSlot = slot;
                GL.BindTexture((uint)Target, Id);
                return;
            }

            if (State.ActiveTexture != slot)
            {
                GL.ActiveTexture(GLEnum.Texture0 + slot);
            }
        }
        public void Bind()
        {
            if (this.Bound(State.ActiveTexture)) { return; }

            GL.ActiveTexture(GLEnum.Texture0 + State.ActiveTexture);
            ReferanceSlot = State.ActiveTexture;
            GL.BindTexture((uint)Target, Id);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Unbind()
        {
            State.ActiveTexture = ReferanceSlot;
            GL.BindTexture((uint)Target, 0);
        }

        /// <summary>
        /// Returns the relevent targeted texture object based on <see cref="Target"/>.
        /// </summary>
        /// <returns></returns>
        public ITexture Pass()
        {
            if (InternalFormat.IsCompressed())
            {
                if (Target.Is1D())
                {
                    return new Texture1DComp(Id, InternalFormat);
                }
                if (Target.Is2D())
                {
                    return new Texture2DComp(Target, Id, InternalFormat);
                }
                if (Target.Is3D())
                {
                    return new Texture3DComp(Target, Id, InternalFormat);
                }

                return this;
            }

            return Target switch
            {
                TextureTarget.Texture1D => new Texture1D(Id, InternalFormat, _dataType),
                TextureTarget.Texture1DArray => new Texture1DArray(Id, InternalFormat, _dataType),
                TextureTarget.Texture2D => new Texture2D(Id, InternalFormat, _dataType),
                TextureTarget.Texture2DArray => new Texture2DArray(Id, InternalFormat, _dataType),
                TextureTarget.Multisample2D => new Texture2DMultisample(Id, InternalFormat),
                TextureTarget.MultisampleArray2D => new Texture2DArrayMultisample(Id, InternalFormat),
                TextureTarget.Texture3D => new Texture3D(Id, InternalFormat, _dataType),
                TextureTarget.CubeMap => new CubeMap(Id, InternalFormat, _dataType),
                TextureTarget.CubeMapArray => new CubeMap(Id, InternalFormat, _dataType),
                TextureTarget.Rectangle => new TextureRect(Id, InternalFormat, _dataType),
                _ => this
            };
        }

        /// <summary>
        /// Returns a new targeted texture object based on <paramref name="target"/>.
        /// </summary>
        /// <param name="target">The target of the texture.</param>
        /// <param name="id">The id of the texture.</param>
        /// <param name="format">The internal format of the texture.</param>
        /// <returns></returns>
        public static ITexture Pass(TextureTarget target, uint id, TextureFormat format)
        {
            if (format.IsCompressed())
            {
                if (target.Is1D())
                {
                    return new Texture1DComp(id, format);
                }
                if (target.Is2D())
                {
                    return new Texture2DComp(target, id, format);
                }
                if (target.Is3D())
                {
                    return new Texture3DComp(target, id, format);
                }

                return new TexturePasser(target, id, format);
            }

            return target switch
            {
                TextureTarget.Texture1D => new Texture1D(id, format, 0),
                TextureTarget.Texture1DArray => new Texture1DArray(id, format, 0),
                TextureTarget.Texture2D => new Texture2D(id, format, 0),
                TextureTarget.Texture2DArray => new Texture2DArray(id, format, 0),
                TextureTarget.Multisample2D => new Texture2DMultisample(id, format),
                TextureTarget.MultisampleArray2D => new Texture2DArrayMultisample(id, format),
                TextureTarget.Texture3D => new Texture3D(id, format, 0),
                TextureTarget.CubeMap => new CubeMap(id, format, 0),
                TextureTarget.CubeMapArray => new CubeMap(id, format, 0),
                TextureTarget.Rectangle => new TextureRect(id, format, 0),
                _ => new TexturePasser(target, id, format)
            };
        }
    }
}
