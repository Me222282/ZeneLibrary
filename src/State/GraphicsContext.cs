﻿using System;
using System.Collections.Generic;
using Zene.Graphics.Base;
using Zene.Structs;

namespace Zene.Graphics
{
    public class GraphicsContext
    {
        public unsafe GraphicsContext(bool stereo, bool doubleBuffered, int width, int height, floatv version)
        {
            ThreadChange();
            
            // Helper constants
            // Only works with 1 context in use at a time
            // Shapes.Init();
            
            baseFrameBuffer = new FramebufferGL(0, stereo, doubleBuffered, width, height);
            boundFrameBuffers.Draw = baseFrameBuffer;
            boundFrameBuffers.Read = baseFrameBuffer;

            this.version = version;
            viewport = baseFrameBuffer.Viewport;
            scissor = baseFrameBuffer.Scissor;
            depth = DepthState.Default;
            renderState = RenderState.Default;

            // Setup texture binding referance
            int size = 0;
            GL.GetIntegerv(GLEnum.MaxTextureImageUnits, &size);
            boundTextures = new GL.TextureBinding[size];

            // Setup indexed buffer
            boundBuffers = new GL.BufferBinding();

            if (version >= 3.0f)
            {
                int tfSize = 0;
                GL.GetIntegerv(GLEnum.MaxTransformFeedbackBuffers, &tfSize);
                boundBuffers.TransformFeedback = new IBuffer[tfSize];
            }
            else
            {
                boundBuffers.TransformFeedback = new IBuffer[1];
            }
            if (version >= 3.1f)
            {
                int uSize = 0;
                GL.GetIntegerv(GLEnum.MaxUniformBufferBindings, &uSize);
                boundBuffers.Uniform = new IBuffer[uSize];
            }
            else
            {
                boundBuffers.Uniform = new IBuffer[1];
            }
            if (version >= 4.2f)
            {
                int acSize = 0;
                GL.GetIntegerv(GLEnum.MaxAtomicCounterBufferBindings, &acSize);
                boundBuffers.AtomicCounter = new IBuffer[acSize];
            }
            else
            {
                boundBuffers.AtomicCounter = new IBuffer[1];
            }
            if (version >= 4.3f)
            {
                int ssSize = 0;
                GL.GetIntegerv(GLEnum.MaxShaderStorageBufferBindings, &ssSize);
                boundBuffers.ShaderStorage = new IBuffer[ssSize];
            }
            else
            {
                boundBuffers.ShaderStorage = new IBuffer[1];
            }
        }

        public ActionManager Actions { get; } = new ActionManager();

        internal IShaderProgram boundShaderProgram;
        internal GL.BufferBinding boundBuffers;

        internal IRenderbuffer boundRenderbuffer;

        internal IVertexArray boundVertexArray;
        internal VertexArrayGL baseVertexArray = new VertexArrayGL(0);

        internal uint activeTextureUnit = 0;
        internal GL.TextureBinding[] boundTextures;

        internal Viewport viewport;
        internal Scissor scissor;
        internal DepthState depth;
        internal RenderState renderState;

        internal floatv version;

        internal GL.FrameBufferBinding boundFrameBuffers = new GL.FrameBufferBinding();
        internal FramebufferGL baseFrameBuffer;
        internal ColourF frameClearColour = ColourF.Zero;
        internal floatv frameClearDepth = 1;
        internal int frameClearStencil = 0;

        public static GraphicsContext None { get; } = new GraphicsContext(false, false, 0, 0, 0);

        private readonly List<IIdentifiable> _tracked = new List<IIdentifiable>();

        public void TrackObject(IIdentifiable obj) => _tracked.Add(obj);
        public bool RemoveTrack(IIdentifiable obj) => _tracked.Remove(obj);
        public IIdentifiable GetTrack(Type type) => _tracked.Find((i) => i.GetType() == type);
        
        public void ThreadChange() => Actions.ThreadChange();
    }
}
