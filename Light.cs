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
    class Light : Lichten
    {

        public Light() { }
        public Light(Vector2 pos, int intens, string richting, float kleur1,float kleur2, float kleur3)
        {
            positie = pos;
            intensiteit = intens;
            beweging = richting;
            kw1 = kleur1;
            kw2 = kleur2;
            kw3 = kleur3;

        }

        public override void heenenweerX(bool up)
        {
            if (up)
                positie.X += 5;
            else
                positie.X -= 5;
        }

        public override void heenenweerY(bool up)
        {
            if (up)
                positie.Y += 5;
            else
                positie.Y -= 5;
        }
        public override void heenenweerschuin(bool up)
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
        public override void rondje(double grad)
        {
                positie.X += (float)( Math.Cos(grad) * 27);
                positie.Y += (float)( Math.Sin(grad) * 27);
        
        }
        public override Vector2 bepaalpunten(int ding)
        {
            throw new NotImplementedException();
        }


    }
    
}
