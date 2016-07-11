using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class Scene
    {
        List<Primitive> elementen;
        List<Light> lightsources;
        int countX = 0;
        double graden = 0;
        bool up = true;

        public Scene()
        {
            elementen = new List<Primitive>();
            lightsources = new List<Light>();
        }

        public void AddObject(Primitive obj)
        {
            elementen.Add(obj);
        }
        public void AddLightsource(Light licht)
        {
            lightsources.Add(licht);
        }

        public void Render(Surface scr)
        {

            foreach (Light licht in lightsources)
            {
                if (countX == 10)
                {
                    if (up == true)
                        up = false;
                    else
                        up = true;
                    countX = 0;
                }
                if(licht.beweging == "rechts")
                    licht.heenenweerX(up);
                if (licht.beweging == "op")
                    licht.heenenweerY(up);
                if (licht.beweging == "schuin")
                    licht.heenenweerschuin(up);
                if (licht.beweging == "rondje")
                    licht.rondje(up, graden );
            }
            countX += 1;
            graden += 1;

            for (int y = 0; y < scr.height; y++)
            {
                for(int x = 0; x < scr.width; x++)
                {
                    float intensiteit = bepaalintensiteit(x, y, scr);

                    int kleurwaarde;
                    if (intensiteit > 1)
                        kleurwaarde = 255; // grote intensiteit wordt 'gewoon' wit
                    else
                        kleurwaarde = (int)(intensiteit * 255);
                    scr.pixels[y * scr.width + x] = CreateColor(kleurwaarde, kleurwaarde, kleurwaarde);
                }
            }

        }

        float bepaalintensiteit(int x, int y, Surface scr)
        {
            float intensiteit = 0.0f;
            double afstand;

            foreach (Primitive obj in elementen)
            {
                foreach (Light licht in lightsources)
                {
                    Ray ray = new Ray(new Vector2(x, y), licht.positie);
                    if (obj.incirkel(ray))
                        return 0.02f;
                    if (licht.positie.X == x && licht.positie.Y == y)
                        return 1.0f;
                    if (!obj.intersect(ray))
                    {
                        afstand = Vector2.Dot(new Vector2(x, y) - licht.positie, new Vector2(x, y) - licht.positie) / Math.Max(scr.height, scr.width); // de afstand is zo afhankelijk van je scherm
                        intensiteit += (float)(licht.intensiteit * 0.035/ (1 + 0.5 * afstand)); // verander de attenuation
                    }

                }
            }
            return intensiteit;
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
