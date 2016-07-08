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
        public Vector2 goal;

        public Ray(Vector2 pixel, Vector2 licht)
        {
            // teken de ray vanuit de lamp naar je pixel
            origin = licht;
            goal = pixel;
        }
    }
}
