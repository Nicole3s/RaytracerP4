using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class circle : Primitive
    {
        int radius;
        public circle(Vector2 positie, int rad)
        {
            locatie = positie;
            radius = rad;
        }
        public override bool intersect(Ray ray)
        {
            float dx = Math.Abs(ray.lightsource.X - ray.origin.X);
            float dy = Math.Abs(ray.lightsource.Y - ray.origin.Y);
            float dr = (float)Math.Sqrt(dx * dx + dy * dy);
            float D = ray.origin.X * ray.lightsource.Y - ray.lightsource.X * ray.origin.Y;

            float delta = radius * radius * dr * dr - D * D;

            if (delta < 0)
                return false;
            else
                return true;
        }
    }
}
