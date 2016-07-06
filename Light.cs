using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

using System.IO;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Input;

namespace Template
{
    class Light
    {
        Vector2 positie;
        float intensiteit;
        public Light(Vector2 pos, float intens)
        {
            positie = pos;
            intensiteit = intens;
        }
    }
}
