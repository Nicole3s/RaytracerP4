using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    abstract class Primitive
    {
        protected Vector2 locatie;

        public abstract bool intersect(Ray ray);
        public abstract bool incirkel(Ray ray);
        
    }
}
