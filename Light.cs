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
        public Vector2 positie;
        public float intensiteit;
        public string beweging;
        public Light(Vector2 pos, float intens, string richting)
        {
            positie = pos;
            intensiteit = intens;
            beweging = richting;

        }

        public void heenenweerX(bool up)
        {
            if (up)
                positie.X += 5;
            else
                positie.X -= 5;
        }

        public void heenenweerY(bool up)
        {
            if (up)
                positie.Y += 5;
            else
                positie.Y -= 5;
        }
        public void heenenweerschuin(bool up)
        {
            if (up)
            {
                positie.X += 5;
                positie.Y -= 5;
            }

            else
            {
                positie.X -= 5;
                positie.Y += 5;
            }
        }
    }
}
