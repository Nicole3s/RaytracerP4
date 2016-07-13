using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    abstract class Lichten
    {
        public Vector2 positie;
        public int intensiteit;
        public string beweging;
        public float kw1, kw2, kw3;
        public int aantalpunten;

        // methoden voor bewegen
        public abstract void heenenweerX(bool up);
        public abstract void heenenweerY(bool up);
        public abstract void heenenweerschuin(bool up);
        public abstract void rondje(double grad);
        public abstract Vector2 bepaalpunten(int ding);
    }
}
