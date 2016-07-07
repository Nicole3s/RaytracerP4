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
            Vector2 raydirection = Vector2.Normalize(ray.lightsource - ray.origin);
            
            double delta = Math.Pow(Vector2.Dot(raydirection, ray.origin - locatie), 2) 
                - Vector2.Dot(raydirection, raydirection) * (Vector2.Dot(ray.origin - locatie, ray.origin - locatie) 
                - (radius * radius));

            if (delta <= 0)
                return false;
            else
                return true;
        }
    }
}
