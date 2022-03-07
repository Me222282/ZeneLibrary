﻿using System;

namespace Zene.Structs
{
    /// <summary>
    /// A box stored by the <see cref="X"/>, <see cref="Y"/>, <see cref="Width"/> and <see cref="Height"/> values.
    /// </summary>
    public struct Rectangle : IBox
    {
        public Rectangle(double x, double y, double w, double h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }
        public Rectangle(Vector2 location, Vector2 size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.X;
            Height = size.Y;
        }
        public Rectangle(IBox box)
        {
            X = box.Left;
            Y = box.Top;
            Width = box.Width;
            Height = box.Height;
        }

        /// <summary>
        /// The left x location of the box.
        /// </summary>
        public double X { get; set; }
        /// <summary>
        /// The top y location of the box.
        /// </summary>
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public Vector2 Centre => new Vector2(X + (Width * 0.5), Y - (Height * 0.5));

        /// <summary>
        /// The top-left location of the box.
        /// </summary>
        public Vector2 Location
        {
            get => new Vector2(X, Y);
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }
        /// <summary>
        /// The width and height of the box.
        /// </summary>
        public Vector2 Size
        {
            get => new Vector2(Width, Height);
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        public double Left
        {
            get => X;
            set
            {
                Width += X - value;
                X = value;
            }
        }
        public double Right
        {
            get => X + Width;
            set => Width = value - X;
        }
        public double Bottom
        {
            get => Y - Height;
            set
            {
                Height = Y - value;
                Y = value;
            }
        }
        public double Top
        {
            get => Y;
            set => Height += value - Y;
        }

#nullable enable
        public override string ToString()
        {
            return $"X:{X}, Y:{X}, Width:{Width}, Height:{Height}";
        }
        public string ToString(string? format)
        {
            return $"X:{X.ToString(format)}, Y:{Y.ToString(format)}, Width:{Width.ToString(format)}, Height:{Height.ToString(format)}";
        }
#nullable disable

        public override bool Equals(object obj)
        {
            return obj is IBox b &&
                    X == b.Left && Width == b.Width &&
                    Y == b.Top && Height == b.Height;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Width, Height);
        }

        public static bool operator ==(Rectangle l, Rectangle r)
        {
            return l.Equals(r);
        }
        public static bool operator !=(Rectangle l, Rectangle r)
        {
            return !l.Equals(r);
        }

        public static explicit operator Rectangle(Box box)
        {
            return new Rectangle(box);
        }

        public static Rectangle Zero { get; } = new Rectangle(0, 0, 0, 0);
        public static Rectangle One { get; } = new Rectangle(-1, 1, 2, 2);
    }
}
