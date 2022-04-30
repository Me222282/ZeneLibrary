﻿using System;
using Zene.Graphics.Base;

namespace Zene.Graphics
{
    public enum Target : uint
    {
        Framebuffer = GLEnum.Framebuffer,
        ReadFramebuffer = GLEnum.ReadFramebuffer,
        DrawFramebuffer = GLEnum.DrawFramebuffer,
        Renderbuffer = GLEnum.Renderbuffer,

        Texture1D = GLEnum.Texture1d,
        Texture1DArray = GLEnum.Texture1dArray,
        Texture2D = GLEnum.Texture2d,
        Texture2DArray = GLEnum.Texture2dArray,
        Texture3D = GLEnum.Texture3d,
        Texture2DMS = GLEnum.Texture2dMultisample,
        Texture2DArrayMS = GLEnum.Texture2dMultisampleArray,
        TextureCubeMap = GLEnum.TextureCubeMap,
        TextureCubeMapArray = GLEnum.TextureCubeMapArray,
        TextureRectangle = GLEnum.TextureRectangle,

        TextureBuffer = GLEnum.TextureBuffer,

        BufferArray = GLEnum.ArrayBuffer,
        BufferAtomicCounter = GLEnum.AtomicCounterBuffer,
        BufferCopyRead = GLEnum.CopyReadBuffer,
        BufferCopyWrite = GLEnum.CopyWriteBuffer,
        BufferDispatchIndirect = GLEnum.DispatchIndirectBuffer,
        BufferDrawIndirect = GLEnum.DrawIndirectBuffer,
        BufferElementArray = GLEnum.ElementArrayBuffer,
        BufferPixelPack = GLEnum.PixelPackBuffer,
        BufferPixelUnPack = GLEnum.PixelUnpackBuffer,
        BufferQuery = GLEnum.QueryBuffer,
        BufferShaderStorage = GLEnum.ShaderStorageBuffer,
        BufferTransformFeedback = GLEnum.TransformFeedbackBuffer,
        BufferUniform = GLEnum.UniformBuffer
    }

    public static unsafe class State
    {
        /// <summary>
        /// Determines whether to blend the computed fragment colour values with the values in the colour buffers.
        /// </summary>
        public static bool Blending
        {
            get
            {
                return GL.IsEnabled(GLEnum.Blend);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.Blend);
                    return;
                }

                GL.Disable(GLEnum.Blend);
            }
        }
        /// <summary>
        /// Determines whether to apply the currently selected logical operation to the computed fragment colour and colour buffer values.
        /// </summary>
        public static bool LogicOPColour
        {
            get
            {
                return GL.IsEnabled(GLEnum.ColourLogicOp);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.ColourLogicOp);
                    return;
                }

                GL.Disable(GLEnum.ColourLogicOp);
            }
        }
        /// <summary>
        /// Determines whether to cull polygons based on their winding in window coordinates.
        /// </summary>
        public static bool FaceCulling
        {
            get
            {
                return GL.IsEnabled(GLEnum.CullFace);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.CullFace);
                    return;
                }

                GL.Disable(GLEnum.CullFace);
            }
        }
        /// <summary>
        /// Determines whether debug messages are produced by a debug context.
        /// </summary>
        public static bool OutputDebug
        {
            get
            {
                return GL.IsEnabled(GLEnum.DebugOutput);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.DebugOutput);
                    return;
                }

                GL.Disable(GLEnum.DebugOutput);
            }
        }
        /// <summary>
        /// Determines whether debug messages are produced synchronously by a debug context.
        /// </summary>
        public static bool OutputDebugSynchronous
        {
            get
            {
                return GL.IsEnabled(GLEnum.DebugOutputSynchronous);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.DebugOutputSynchronous);
                    return;
                }

                GL.Disable(GLEnum.DebugOutputSynchronous);
            }
        }
        /// <summary>
        /// Determines whether there is no near or far plane clipping.
        /// </summary>
        public static bool ClampDepth
        {
            get
            {
                return GL.IsEnabled(GLEnum.DepthClamp);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.DepthClamp);
                    return;
                }

                GL.Disable(GLEnum.DepthClamp);
            }
        }
        /// <summary>
        /// Determines whether to do depth comparisons and update the depth buffer.
        /// </summary>
        public static bool DepthTesting
        {
            get
            {
                return GL.IsEnabled(GLEnum.DepthTest);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.DepthTest);
                    return;
                }

                GL.Disable(GLEnum.DepthTest);
            }
        }
        /// <summary>
        /// Determines whether to dither colour components or indices before they are written to the colour buffer.
        /// </summary>
        public static bool Dither
        {
            get
            {
                return GL.IsEnabled(GLEnum.Dither);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.Dither);
                    return;
                }

                GL.Disable(GLEnum.Dither);
            }
        }
        /// <summary>
        /// Determines whether the R, G, and B destination colour values (after conversion from fixed-point to floating-point)
        /// are considered to be encoded for the sRGB colour space and hence are linearized prior to their use in blending.
        /// </summary>
        public static bool FramebufferSRGB
        {
            get
            {
                return GL.IsEnabled(GLEnum.FramebufferSrgb);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.FramebufferSrgb);
                    return;
                }

                GL.Disable(GLEnum.FramebufferSrgb);
            }
        }
        /// <summary>
        /// Determines whether to draw lines with correct filtering. Otherwise, draw aliased lines.
        /// </summary>
        public static bool SmoothLines
        {
            get
            {
                return GL.IsEnabled(GLEnum.LineSmooth);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.LineSmooth);
                    return;
                }

                GL.Disable(GLEnum.LineSmooth);
            }
        }
        /// <summary>
        /// Determines whether to use multiple fragment samples in computing the final colour of a pixel.
        /// </summary>
        public static bool Multisampleing
        {
            get
            {
                return GL.IsEnabled(GLEnum.Multisample);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.Multisample);
                    return;
                }

                GL.Disable(GLEnum.Multisample);
            }
        }
        /// <summary>
        /// Determines whether an offset is added to depth values of a polygon's fragments before the depth comparison is performed.
        /// </summary>
        public static bool PolygonFillOffset
        {
            get
            {
                return GL.IsEnabled(GLEnum.PolygonOffsetFill);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PolygonOffsetFill);
                    return;
                }

                GL.Disable(GLEnum.PolygonOffsetFill);
            }
        }
        /// <summary>
        /// Determines whether an offset is added to depth values of a polygon's fragments before the depth comparison is performed.
        /// </summary>
        public static bool PolygonLineOffset
        {
            get
            {
                return GL.IsEnabled(GLEnum.PolygonOffsetLine);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PolygonOffsetLine);
                    return;
                }

                GL.Disable(GLEnum.PolygonOffsetLine);
            }
        }
        /// <summary>
        /// Determines whether an offset is added to depth values of a polygon's fragments before the depth comparison is performed.
        /// </summary>
        public static bool PolygonPointOffset
        {
            get
            {
                return GL.IsEnabled(GLEnum.PolygonOffsetPoint);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PolygonOffsetPoint);
                    return;
                }

                GL.Disable(GLEnum.PolygonOffsetPoint);
            }
        }
        /// <summary>
        /// Determines whether to draw polygons with proper filtering. Otherwise, draw aliased polygons.
        /// </summary>
        public static bool SmoothPolygons
        {
            get
            {
                return GL.IsEnabled(GLEnum.PolygonSmooth);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PolygonSmooth);
                    return;
                }

                GL.Disable(GLEnum.PolygonSmooth);
            }
        }
        /// <summary>
        /// Determines whether GL will restart the primitive when the index of the vertex is equal to the primitive restart index
        /// when any one of the draw commands which transfers a set of generic attribute array elements.
        /// </summary>
        public static bool PrimitiveRestart
        {
            get
            {
                return GL.IsEnabled(GLEnum.PrimitiveRestart);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PrimitiveRestart);
                    return;
                }

                GL.Disable(GLEnum.PrimitiveRestart);
            }
        }
        /// <summary>
        /// Determines whether GL will restart the primitive when the index of the vertex is equal to the primitive restart index
        /// when any one of the draw commands which transfers a set of generic attribute array elements.
        /// </summary>
        public static bool FixedIndexPrimitiveRestart
        {
            get
            {
                return GL.IsEnabled(GLEnum.PrimitiveRestartFixedIndex);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.PrimitiveRestartFixedIndex);
                    return;
                }

                GL.Disable(GLEnum.PrimitiveRestartFixedIndex);
            }
        }
        /// <summary>
        /// Determines whether before rasterization, primitives are discarded after the optional transform feedback stage.
        /// </summary>
        public static bool RasterizerDiscarding
        {
            get
            {
                return GL.IsEnabled(GLEnum.RasterizerDiscard);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.RasterizerDiscard);
                    return;
                }

                GL.Disable(GLEnum.RasterizerDiscard);
            }
        }
        /// <summary>
        /// Determines whether to compute a temporary coverage value where each bit is determined by the alpha value at the corresponding sample location.
        /// </summary>
        public static bool SampleAlphaToCoverage
        {
            get
            {
                return GL.IsEnabled(GLEnum.SampleAlphaToCoverage);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.SampleAlphaToCoverage);
                    return;
                }

                GL.Disable(GLEnum.SampleAlphaToCoverage);
            }
        }
        /// <summary>
        /// Determines whether each sample alpha value is replaced by the maximum representable alpha value.
        /// </summary>
        public static bool SampleAlphaToOne
        {
            get
            {
                return GL.IsEnabled(GLEnum.SampleAlphaToOne);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.SampleAlphaToOne);
                    return;
                }

                GL.Disable(GLEnum.SampleAlphaToOne);
            }
        }
        /// <summary>
        /// Determines whether the fragment's coverage is ANDed with the temporary coverage value.
        /// </summary>
        public static bool SampleCoverage
        {
            get
            {
                return GL.IsEnabled(GLEnum.SampleCoverage);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.SampleCoverage);
                    return;
                }

                GL.Disable(GLEnum.SampleCoverage);
            }
        }
        /// <summary>
        /// Determines whether the sample coverage mask generated for a fragment during rasterization will be ANDed before shading occurs.
        /// </summary>
        public static bool SampleShading
        {
            get
            {
                return GL.IsEnabled(GLEnum.SampleShading);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.SampleShading);
                    return;
                }

                GL.Disable(GLEnum.SampleShading);
            }
        }
        /// <summary>
        /// Determines whether to discard fragments that are outside the scissor rectangle.
        /// </summary>
        public static bool ScissorTesting
        {
            get
            {
                return GL.IsEnabled(GLEnum.ScissorTest);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.ScissorTest);
                    return;
                }

                GL.Disable(GLEnum.ScissorTest);
            }
        }
        /// <summary>
        /// Determines whether to do stencil testing and update the stencil buffer.
        /// </summary>
        public static bool StencilTesting
        {
            get
            {
                return GL.IsEnabled(GLEnum.StencilTest);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.StencilTest);
                    return;
                }

                GL.Disable(GLEnum.StencilTest);
            }
        }
        /// <summary>
        /// Determines whether cubemap textures are sampled such that when linearly sampling from the border between two adjacent faces,
        /// texels from both faces are used to generate the final sample value.
        /// </summary>
        public static bool SeamlessCubeMaps
        {
            get
            {
                return GL.IsEnabled(GLEnum.TextureCubeMapSeamless);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.TextureCubeMapSeamless);
                    return;
                }

                GL.Disable(GLEnum.TextureCubeMapSeamless);
            }
        }
        /// <summary>
        /// Determines whether then the derived point size is taken from the (potentially clipped)
        /// shader builtin gl_PointSize and clamped to the implementation-dependent point size range.
        /// </summary>
        public static bool ProgramPointSize
        {
            get
            {
                return GL.IsEnabled(GLEnum.ProgramPointSize);
            }
            set
            {
                if (value)
                {
                    GL.Enable(GLEnum.ProgramPointSize);
                    return;
                }

                GL.Disable(GLEnum.ProgramPointSize);
            }
        }

        /// <summary>
        /// Force execution of GL commands in finite time.
        /// </summary>
        public static void Flush()
        {
            GL.Flush();
        }
        /// <summary>
        /// Block until all GL execution is complete.
        /// </summary>
        public static void Finish()
        {
            GL.Finish();
        }

        /// <summary>
        /// Gets the Id of the currently bound texture.
        /// </summary>
        /// <param name="target">The texture target to test.</param>
        /// <returns></returns>
        public static uint GetBoundTexture(uint unit, TextureTarget target)
        {
            return target switch
            {
                TextureTarget.Texture1D => GL.BoundTextures[unit].Texture1D,
                TextureTarget.Texture1DArray => GL.BoundTextures[unit].Texture1DArray,
                TextureTarget.Texture2D => GL.BoundTextures[unit].Texture2D,
                TextureTarget.Texture2DArray => GL.BoundTextures[unit].Texture2DArray,
                TextureTarget.Texture3D => GL.BoundTextures[unit].Texture3D,
                TextureTarget.Rectangle => GL.BoundTextures[unit].Rectangle,
                TextureTarget.CubeMap => GL.BoundTextures[unit].CubeMap,
                TextureTarget.CubeMapArray => GL.BoundTextures[unit].CubeMapArray,
                TextureTarget.Multisample2D => GL.BoundTextures[unit].Texture2DMS,
                TextureTarget.Multisample2DArray => GL.BoundTextures[unit].Texture2DArrayMS,
                TextureTarget.Buffer => GL.BoundTextures[unit].Buffer,
                _ => 0
            };
        }
        /// <summary>
        /// Gets the Id of the currently bound framebufer.
        /// </summary>
        /// <param name="target">The framebuffer target to test.</param>
        /// <returns></returns>
        public static uint GetBoundFrameBuffer(FrameTarget target)
        {
            return target switch
            {
                FrameTarget.FrameBuffer => GL.BoundFrameBuffers.Draw,
                FrameTarget.Read => GL.BoundFrameBuffers.Read,
                FrameTarget.Draw => GL.BoundFrameBuffers.Draw,
                _ => 0
            };
        }
        /// <summary>
        /// Gets the Id of the currently bound renderbuffer.
        /// </summary>
        /// <returns></returns>
        public static uint GetBoundRenderbuffer()
        {
            return GL.BoundRenderbuffer;
        }
        /// <summary>
        /// Gets the Id of the currently bound shader program.
        /// </summary>
        /// <returns></returns>
        public static uint GetBoundShaderProgram()
        {
            return GL.BoundShaderProgram;
        }
        /// <summary>
        /// Gets the Id of the currently bound buffer object.
        /// </summary>
        /// <returns></returns>
        public static uint GetBoundBuffer(BufferTarget target)
        {
            return target switch
            {
                BufferTarget.Array => GL.BoundBuffers.Array,
                BufferTarget.AtomicCounter => GL.BoundBuffers.AtomicCounter,
                BufferTarget.CopyRead => GL.BoundBuffers.CopyRead,
                BufferTarget.CopyWrite => GL.BoundBuffers.CopyWrite,
                BufferTarget.DispatchIndirect => GL.BoundBuffers.DispatchIndirect,
                BufferTarget.DrawIndirect => GL.BoundBuffers.DrawIndirect,
                BufferTarget.ElementArray => GL.BoundBuffers.ElementArray,
                BufferTarget.PixelPack => GL.BoundBuffers.PixelPack,
                BufferTarget.PixelUnPack => GL.BoundBuffers.PixelUnpack,
                BufferTarget.Query => GL.BoundBuffers.Query,
                BufferTarget.ShaderStorage => GL.BoundBuffers.ShaderStorage,
                BufferTarget.Texture => GL.BoundBuffers.Texture,
                BufferTarget.TransformFeedback => GL.BoundBuffers.TransformFeedback,
                BufferTarget.Uniform => GL.BoundBuffers.Uniform,
                _ => 0
            };
        }
        /// <summary>
        /// Gets or sets the active texture referance.
        /// </summary>
        /// <returns></returns>
        public static uint ActiveTexture
        {
            get
            {
                return GL.ActiveTextureUnit;
            }
            set
            {
                GL.ActiveTexture(value + GLEnum.Texture0);
            }
        }

        /// <summary>
        /// Sets the binding for <paramref name="target"/> to 0.
        /// </summary>
        /// <param name="target">The target to nullify.</param>
        public static void NullBind(Target target)
        {
            switch (target)
            {
                case Target.Texture1D:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture1D == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture1DArray:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture1DArray == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture2D:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture2D == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture2DArray:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture2DArray == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture3D:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture3D == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture2DMS:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture2DMS == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.Texture2DArrayMS:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Texture2DArrayMS == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.TextureCubeMap:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].CubeMap == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.TextureCubeMapArray:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].CubeMapArray == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.TextureRectangle:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Rectangle == 0) { return; }
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case Target.TextureBuffer:
                    if (GL.BoundTextures[GL.ActiveTextureUnit].Buffer != 0)
                    {
                        GL.BindTexture(GLEnum.TextureBuffer, 0);
                    }
                    if (GL.BoundBuffers.Texture != 0)
                    {
                        GL.BindBuffer(GLEnum.TextureBuffer, 0);
                    }
                    return;

                case Target.DrawFramebuffer:
                case Target.ReadFramebuffer:
                case Target.Framebuffer:
                    BaseFramebuffer.Bind((FrameTarget)target);
                    return;

                case Target.Renderbuffer:
                    if (GL.BoundRenderbuffer == 0) { return; }
                    GL.BindRenderbuffer(GLEnum.Renderbuffer, 0);
                    return;

                case Target.BufferArray:
                    if (GL.BoundBuffers.Array == 0) { return; }
                    GL.BindBuffer(GLEnum.ArrayBuffer, 0);
                    return;

                case Target.BufferAtomicCounter:
                    if (GL.BoundBuffers.AtomicCounter == 0) { return; }
                    GL.BindBuffer(GLEnum.AtomicCounterBuffer, 0);
                    return;

                case Target.BufferCopyRead:
                    if (GL.BoundBuffers.CopyRead == 0) { return; }
                    GL.BindBuffer(GLEnum.CopyReadBuffer, 0);
                    return;

                case Target.BufferCopyWrite:
                    if (GL.BoundBuffers.CopyWrite == 0) { return; }
                    GL.BindBuffer(GLEnum.CopyWriteBuffer, 0);
                    return;

                case Target.BufferDispatchIndirect:
                    if (GL.BoundBuffers.DispatchIndirect == 0) { return; }
                    GL.BindBuffer(GLEnum.DispatchIndirectBuffer, 0);
                    return;

                case Target.BufferDrawIndirect:
                    if (GL.BoundBuffers.DrawIndirect == 0) { return; }
                    GL.BindBuffer(GLEnum.DrawIndirectBuffer, 0);
                    return;

                case Target.BufferElementArray:
                    if (GL.BoundBuffers.ElementArray == 0) { return; }
                    GL.BindBuffer(GLEnum.ElementArrayBuffer, 0);
                    return;

                case Target.BufferPixelPack:
                    if (GL.BoundBuffers.PixelPack == 0) { return; }
                    GL.BindBuffer(GLEnum.PixelPackBuffer, 0);
                    return;

                case Target.BufferPixelUnPack:
                    if (GL.BoundBuffers.PixelUnpack == 0) { return; }
                    GL.BindBuffer(GLEnum.PixelUnpackBuffer, 0);
                    return;

                case Target.BufferQuery:
                    if (GL.BoundBuffers.Query == 0) { return; }
                    GL.BindBuffer(GLEnum.QueryBuffer, 0);
                    return;

                case Target.BufferShaderStorage:
                    if (GL.BoundBuffers.ShaderStorage == 0) { return; }
                    GL.BindBuffer(GLEnum.ShaderStorageBuffer, 0);
                    return;

                case Target.BufferTransformFeedback:
                    if (GL.BoundBuffers.TransformFeedback == 0) { return; }
                    GL.BindBuffer(GLEnum.TransformFeedbackBuffer, 0);
                    return;

                case Target.BufferUniform:
                    if (GL.BoundBuffers.Uniform == 0) { return; }
                    GL.BindBuffer(GLEnum.UniformBuffer, 0);
                    return;
            }
        }
        /// <summary>
        /// Sets the binding for <paramref name="target"/> to 0 at texture slot <paramref name="slot"/>.
        /// </summary>
        /// <param name="target">The texture target to nullify at <paramref name="slot"/>.</param>
        /// <param name="slot">The texture slot to nullify <paramref name="target"/> at.</param>
        public static void NullBind(TextureTarget target, uint slot)
        {
            switch (target)
            {
                case TextureTarget.Texture1D:
                    if (GL.BoundTextures[slot].Texture1D == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Texture1DArray:
                    if (GL.BoundTextures[slot].Texture1DArray == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Texture2D:
                    if (GL.BoundTextures[slot].Texture2D == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Texture2DArray:
                    if (GL.BoundTextures[slot].Texture2DArray == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Texture3D:
                    if (GL.BoundTextures[slot].Texture3D == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Multisample2D:
                    if (GL.BoundTextures[slot].Texture2DMS == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Multisample2DArray:
                    if (GL.BoundTextures[slot].Texture2DArrayMS == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.CubeMap:
                    if (GL.BoundTextures[slot].CubeMap == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.CubeMapArray:
                    if (GL.BoundTextures[slot].CubeMapArray == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Rectangle:
                    if (GL.BoundTextures[slot].Rectangle == 0) { return; }
                    GL.ActiveTexture(slot);
                    GL.BindTexture(GLEnum.Texture1d, 0);
                    return;

                case TextureTarget.Buffer:
                    if (GL.BoundTextures[slot].Buffer != 0)
                    {
                        GL.ActiveTexture(slot);
                        GL.BindTexture(GLEnum.TextureBuffer, 0);
                    }
                    if (GL.BoundBuffers.Texture != 0)
                    {
                        GL.BindBuffer(GLEnum.TextureBuffer, 0);
                    }
                    return;
            }
        }
        /// <summary>
        /// Retrieve the range and precision for numeric formats supported by the shader compiler.
        /// </summary>
        /// <param name="type">Specifies the type of shader whose precision to query.
        /// Must be <see cref="ShaderType.Vertex"/> or <see cref="ShaderType.Fragment"/>.</param>
        /// <param name="precisionType">Specifies the numeric format whose precision and range to query.</param>
        /// <param name="min">The minimum range.</param>
        /// <param name="max">The maximum rnage.</param>
        /// <param name="precision">Specifies the numeric precision of the implementation.</param>
        public static void GetShaderPrecisionFormat(ShaderType type, ShaderPrecision precisionType, out int min, out int max, out int precision)
        {
            precision = 0;

            int[] range = new int[2];

            fixed (int* rangePtr = &range[0])
            {
                fixed (int* precPtr = &precision)
                {
                    GL.GetShaderPrecisionFormat((uint)type, (uint)precisionType, rangePtr, precPtr);
                }
            }

            min = range[0];
            max = range[1];
        }

        /// <summary>
        /// Gets or sets the minimum rate at which sample shading takes place.
        /// </summary>
        public static double MinSampleShading
        {
            get
            {
                float value = 0;

                GL.GetFloatv(GLEnum.MinSampleShadingValue, &value);

                return value;
            }
            set
            {
                GL.MinSampleShading((float)value);
            }
        }

        /// <summary>
        /// Release the resources consumed by the implementation's shader compiler.
        /// </summary>
        public static void ReleaseShaderCompiler()
        {
            GL.ReleaseShaderCompiler();
        }

        static State()
        {
            if (GL.Version >= 3.0)
            {
                int value = 0;
                GL.GetIntegerv(GLEnum.MaxColourAttachments, ref value);
                MaxColourAttach = value;
            }
            if (GL.Version >= 2.0)
            {
                int value = 0;
                GL.GetIntegerv(GLEnum.MaxDrawBuffers, ref value);
                MaxDrawBuffers = value;
            }
        }

        /// <summary>
        /// Gets the maximum colour attachments of framebuffers for the hardware being used.
        /// </summary>
        [OpenGLSupport(3.0)]
        public static int MaxColourAttach { get; } = 8;
        /// <summary>
        /// Gets the maximum colour attachments of framebuffers for the hardware being used.
        /// </summary>
        [OpenGLSupport(2.0)]
        public static int MaxDrawBuffers { get; } = 1;

        /// <summary>
        /// Clears all errors in gl error stack.
        /// </summary>
        public static void ClearErrors()
        {
            while (GL.GetError() != GLEnum.NoError)
            {
                // Nothing happens - content is in check statment
            }
        }
    }
}
