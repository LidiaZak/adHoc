﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adHoc
{
    public abstract class Vertex
    {
        public abstract bool Intersects(Vertex other);
        public abstract bool NotLiesIn(Vertex other);
        public abstract bool NotInterrupt(Vertex a, Vertex b);
    }
    public class Vertex2D : Vertex
    {
        public readonly double X, Y, Radius;
        public override bool Intersects(Vertex other)
        {
            if (!(other is Vertex2D))
            {
                return false;
            }
            var v = other as Vertex2D;
            Func<double, double> Sqr = x => x * x;
            var distance = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y));
            return (distance <= this.Radius && distance <= v.Radius && distance > 0);
        }
        public override bool NotLiesIn(Vertex other)
        {
            if (!(other is Vertex2D))
            {
                return false;
            }
            var v = other as Vertex2D;
            Func<double, double> Sqr = x => x * x;
            var distance = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y));
            return (distance > v.Radius);
        }
        public override bool NotInterrupt(Vertex a, Vertex b)
        {
            if (!(a is Vertex2D))
            {
                return false;
            }
            if (!(b is Vertex2D))
            {
                return false;
            }
            var v = a as Vertex2D;
            var w = b as Vertex2D;
            Func<double, double> Sqr = x => x * x;
            var distanceToV = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y));
            var distanceToW = Math.Sqrt(Sqr(w.X - X) + Sqr(w.Y - Y));
            var distanceVW = Math.Sqrt(Sqr(w.X - v.X) + Sqr(w.Y - v.Y));
            return (distanceToV+distanceToW > this.Radius+distanceVW);
        }
        public Vertex2D(double x, double y, double radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
    public class Vertex3D : Vertex
    {
        public readonly double X, Y, Z, Radius;
        public override bool Intersects(Vertex other)
        {
            if (!(other is Vertex3D))
            {
                return false;
            }
            var v = other as Vertex3D;
            Func<double, double> Sqr = x => x * x;
            var distance = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y) + Sqr(v.Z - Z));
            return (distance <= this.Radius && distance <= v.Radius && distance > 0);
        }
        public override bool NotLiesIn(Vertex other)
        {
            if (!(other is Vertex3D))
            {
                return false;
            }
            var v = other as Vertex3D;
            Func<double, double> Sqr = x => x * x;
            var distance = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y) + Sqr(v.Z - Z));
            return (distance > v.Radius);
        }
        public override bool NotInterrupt(Vertex a, Vertex b)
        {
            if (!(a is Vertex3D))
            {
                return false;
            }
            if (!(b is Vertex3D))
            {
                return false;
            }
            var v = a as Vertex3D;
            var w = b as Vertex3D;
            Func<double, double> Sqr = x => x * x;
            var distanceToV = Math.Sqrt(Sqr(v.X - X) + Sqr(v.Y - Y) + Sqr(v.Z - Z));
            var distanceToW = Math.Sqrt(Sqr(w.X - X) + Sqr(w.Y - Y) + Sqr(w.Z - Z));
            var distanceVW = Math.Sqrt(Sqr(w.X - v.X) + Sqr(w.Y - v.Y) + Sqr(w.Z - v.Z));
            return (distanceToV + distanceToW > this.Radius + distanceVW);
        }
        public Vertex3D(double x, double y, double z, double radius)
        {
            X = x;
            Y = y;
            Z = z;
            Radius = radius;
        }

    }
}
