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
        public float kw1, kw2, kw3;
        public Light(Vector2 pos, float intens, string richting, float kleur1,float kleur2, float kleur3)
        {
            positie = pos;
            intensiteit = intens;
            beweging = richting;
            kw1 = kleur1;
            kw2 = kleur2;
            kw3 = kleur3;

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
                positie.X -= 15;
                positie.Y += 15;
            }

            else
            {
                positie.X += 15;
                positie.Y -= 15;
            }
        }
        public void rondje(double grad)
        {
                positie.X += (float)( Math.Cos(grad) * 27);
                positie.Y += (float)( Math.Sin(grad) * 27);
        
        }

       

    }
    
}
