using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class AreaLight : Lichten
    {
        public Vector2 hoekpuntB;
        float stapgrootte;
        Vector2 unitvector;

        public AreaLight(Vector2 pos, Vector2 hB, int intens, float kleur1, float kleur2, float kleur3, int punten, string beweeg)
        {
            positie = pos;
            hoekpuntB = hB;
            intensiteit = intens;
            kw1 = kleur1;
            kw2 = kleur2;
            kw3 = kleur3;
            aantalpunten = punten;
            beweging = beweeg;

            // bepaal vast je gegevens voor het bepalen van de punten op je arealight
            berekengegevens();
        }

        private void berekengegevens()
        {
            Vector2 richting = hoekpuntB - positie;
            float lengte = Vector2.Dot(hoekpuntB - positie, hoekpuntB - positie);
            stapgrootte = lengte / (aantalpunten - 1);
            unitvector = richting / lengte;
        }

        public override Vector2 bepaalpunten(int nummerray)
        {
            return nummerray * stapgrootte * unitvector + positie;
        }
        public override void heenenweerX(bool up)
        {
            if (up)
                positie.X += 5;
            else
                positie.X -= 5;

            berekengegevens();
        }

        public override void heenenweerY(bool up)
        {
            if (up)
                positie.Y += 5;
            else
                positie.Y -= 5;
            berekengegevens();
        }
        public override void heenenweerschuin(bool up)
        {
            if (up)
            {
                positie.X -= 15;
                hoekpuntB.X -= 15;
                positie.Y += 15;
                hoekpuntB.Y += 15;
            }

            else
            {
                positie.X += 15;
                hoekpuntB.X += 15;
                positie.Y -= 15;
                hoekpuntB.Y -= 15;
            }
            berekengegevens();
        }
        public override void rondje(double grad) // draait een rondje om de eigen hoek
        {
            positie.X += (float)(Math.Cos(grad) * 27);
            positie.Y += (float)(Math.Sin(grad) * 27);
            berekengegevens();
        }
    }
}
