using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class Ray
    {
        public Vector2 origin;
        public Vector2 lightsource;

        public Ray(Vector2 bron, Vector2 licht)
        {
            origin = bron;
            lightsource = licht;
        }
    }
}
