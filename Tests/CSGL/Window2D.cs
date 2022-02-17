﻿using System;
using Zene.Graphics.OpenGL;
using Zene.Graphics;
using Zene.Windowing;
using Zene.Windowing.Base;
using Zene.Graphics.Shaders;
using Zene.Structs;

namespace CSGL
{
    public unsafe class Window2D : Window
    {
        public Window2D(int width, int height, string title)
            : base(width, height, title)
        {
            SetUp();
        }

        protected override void Dispose(bool dispose)
        {
            base.Dispose(dispose);

            if (dispose)
            {
                Shader.Dispose();

                DrawObject.Dispose();
                PointObject.Dispose();
            }
        }

        public void Run()
        {
            string fps = Console.ReadLine();

            int interval = 1000 / int.Parse(fps);

            double[] times = new double[100];
            System.Diagnostics.Stopwatch s = new System.Diagnostics.Stopwatch();

            s.Start();

            int i = 0;

            GLFW.SwapInterval(0);

            while (GLFW.WindowShouldClose(Handle) == 0)
            {
                times[i] = s.ElapsedMilliseconds;
                i++;
                if (i >= times.Length)
                {
                    double total = 0;
                    foreach (double d in times)
                    {
                        total += d;
                    }

                    Console.WriteLine(1000 / (total / times.Length));
                    i = 0;
                }
                s.Restart();

                Draw();

                GLFW.SwapBuffers(Handle);

                GLFW.PollEvents();

                //System.Threading.Thread.Sleep(interval);
            }

            Dispose();
        }

        private readonly float[] vertData = new float[]
        {
            /*Vertex*/ 0.5f, 0.5f, /*-20f, /*Colour*/ 0.0f, 0.0f, 1.0f,
            /*Vertex*/ 0.5f, -0.5f, /*-20f, /*Colour*/ 0.0f, 1.0f, 0.0f,
            //*Vertex*/ 0.5f, -0.5f, /*-20f, /*Colour*/ 0.0f, 1.0f, 0.0f,
            /*Vertex*/ -0.5f, -0.5f, /*-20f, /*Colour*/ 1.0f, 0.0f, 0.0f,
            /*Vertex*/ -0.5f, 0.5f, /*-20f, /*Colour*/ 1.0f, 1.0f, 0.0f
        };

        private readonly byte[] indices = new byte[]
        {
            0, 1, 2,
            2, 3, 0
        };

        private DrawObject<float, byte> DrawObject;

        private DrawingTexture<Vector2> PointObject;

        private BasicShader Shader;

        //private readonly Random r = new Random();

        private Matrix4 matrix;

        private double scale;

        private int _width;
        private int _height;

        private double orthoWidth;
        private double orthoHeight;

        protected virtual void SetUp()
        {
            Shader = new BasicShader();
            
            DrawObject = new DrawObject<float, byte>(vertData, indices, 5, 0, AttributeSize.D2, BufferUsage.DrawFrequent);

            DrawObject.AddAttribute(1, 2, AttributeSize.D3); // Colour attribute

            State.Blending = true;
            GL.BlendFunc(GLEnum.SrcAlpha, GLEnum.OneMinusSrcAlpha);

            PointObject = new DrawingTexture<Vector2>(new Vector2[] 
            {
                new Vector2(-0.628, -0.75),
                new Vector2(-0.75, -0.872),
                new Vector2(-0.872, -0.75),
                new Vector2(-0.75, -0.628)
            }, 2, new Bitmap("Resources/CharacterLeftN.png"), WrapStyle.EdgeClamp, TextureSampling.Nearest, BufferUsage.DrawFrequent, false);

            scale = 100;

            matrix = Matrix4.Identity;

            //GL.PolygonMode(GLEnum.FrontAndBack, GLEnum.Line);
        }

        private bool _bool;

        protected virtual void Draw()
        {
            if (_bool)
            {
                BaseFramebuffer.ClearColour = new Colour(0, 0, 0);
                _bool = false;
            }
            else
            {
                BaseFramebuffer.ClearColour = new Colour(255, 255, 255);
                _bool = true;
            }

            BaseFramebuffer.Clear(BufferBit.Colour);

            /*
            if (_rightShift || _leftShift)
            {
                scale += 1;
            }
            if (_leftControl || _rightControl)
            {
                scale -= 1;
            }

            Shader.Bind();

            Shader.SetMatrix1(matrix * Matrix4.CreateScale(scale) * Matrix4.CreateOrthographic(orthoWidth, orthoHeight, 10, 0));
            //Shader.SetMatrix(Matrix4.CreateTranslation(0, 0, scale) * Matrix4.CreatePerspectiveFieldOfView(Radian.Degrees(60), orthoWidth / orthoHeight, 1, 100));

            GL.ClearColor(0.2f, 0.4f, 0.8f, 1.0f);
            GL.Clear(GLEnum.ColourBufferBit);

            Shader.SetColourSource(ColourSource.AttributeColour);

            DrawObject.Draw();

            Shader.SetColourSource(ColourSource.Texture);
            Shader.SetTextureSlot(0);

            PointObject.Draw();*/
        }

        private bool _leftShift;
        private bool _rightShift;
        private bool _leftControl;
        private bool _rightControl;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Key == Keys.LeftShift)
            {
                _leftShift = true;
            }
            else if (e.Key == Keys.RightShift)
            {
                _rightShift = true;
            }
            else if (e.Key == Keys.LeftControl)
            {
                _leftControl = true;
            }
            else if (e.Key == Keys.RightControl)
            {
                _rightControl = true;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.Key == Keys.LeftShift)
            {
                _leftShift = false;
            }
            else if (e.Key == Keys.RightShift)
            {
                _rightShift = false;
            }
            else if (e.Key == Keys.LeftControl)
            {
                _leftControl = false;
            }
            else if (e.Key == Keys.RightControl)
            {
                _rightControl = false;
            }
        }

        protected override void OnSizeChange(SizeChangeEventArgs e)
        {
            base.OnSizeChange(e);

            _width = (int)e.Width;
            _height = (int)e.Height;

            double mWidth;
            double mHeight;

            if (_width > _height)
            {
                double heightPercent = (double)_height / _width;

                mWidth = 1600;

                mHeight = 1600 * heightPercent;
            }
            else
            {
                double widthPercent = (double)_width / _height;

                mHeight = 900;

                mWidth = 900 * widthPercent;
            }

            orthoWidth = mWidth;
            orthoHeight = mHeight;
        }

        protected override void OnSizePixelChange(SizeChangeEventArgs e)
        {
            base.OnSizePixelChange(e);

            GL.Viewport(0, 0, (int)e.Width, (int)e.Height);
        }
    }
}
