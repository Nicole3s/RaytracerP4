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
        List<Lichten> lightsources;
        int countX = 0;
        double graden = 0;
        bool up = false;

        public Scene()
        {
            elementen = new List<Primitive>();
            lightsources = new List<Lichten>();
        }

        public void AddObject(Primitive obj)
        {
            elementen.Add(obj);
        }
        public void AddLightsource(Lichten licht)
        {
            lightsources.Add(licht);
        }

        public void Render(Surface scr)
        {

            foreach (Lichten licht in lightsources) // bepaal per licht de beweging in het veld
            {
                if (countX == 20)
                {
                    if (up == true)
                        up = false;
                    else
                        up = true;
                    countX = 0;

                }

                switch (licht.beweging)
                {
                    case "rechts":
                        licht.heenenweerX(up);
                        break;
                    case "op":
                        licht.heenenweerY(up);
                        break;
                    case "schuin":
                        licht.heenenweerschuin(up);
                        break;
                    case "rondje":
                        licht.rondje(graden);
                        break;
                }
            }
            countX += 1;
            graden += 0.5;


            for (int y = 0; y < scr.height; y++)
            {
                for (int x = 0; x < scr.width; x++) // ga iedere pixel af en bepaal de kleur van de pixel
                {
                    scr.pixels[y * scr.width + x] = bepaalintensiteit(x, y, scr);
                }
            }
        }

        int bepaalintensiteit(int x, int y, Surface scr)
        {
            float pixelintensiteit = 0.0f; // intens is in de lamp, intensiteit is op de pixel
            float rood, groen, blauw;
            float kleurwaarde1 = 0, kleurwaarde2 = 0, kleurwaarde3 = 0; // begin altijd zonder licht

            foreach (Lichten licht in lightsources)
            {
                rood = licht.kw1;   // bepalen de kleur van je lamp
                groen = licht.kw2;
                blauw = licht.kw3;
                float Lampintensiteit = 0;
                if (licht.GetType() == new Light().GetType())
                {
                    Lampintensiteit = lampintensiteit(licht.positie, x, y, licht.intensiteit, scr);
                }
                if (licht is AreaLight)
                {
                    for(int i = 0; i < licht.aantalpunten; i++)
                    {
                        Lampintensiteit += lampintensiteit(licht.bepaalpunten(i), x, y, licht.intensiteit, scr);
                    }
                    Lampintensiteit /= licht.aantalpunten;
                }
                    pixelintensiteit += Lampintensiteit;
                    kleurwaarde1 += rood * Lampintensiteit;
                    kleurwaarde2 += groen * Lampintensiteit;
                    kleurwaarde3 += blauw * Lampintensiteit;
                
            }

            if (pixelintensiteit > 1)
            {
                // grote intensiteit wordt 'gewoon' fel, afhankelijk van de intensiteit van het licht
                kleurwaarde1 = (int)(kleurwaarde1 * 255);
                kleurwaarde2 = (int)(kleurwaarde2 * 255);
                kleurwaarde3 = (int)(kleurwaarde3 * 255);
            }
            else
            {               
                kleurwaarde1 = (int)(pixelintensiteit * (kleurwaarde1) * 255);
                kleurwaarde2 = (int)(pixelintensiteit * (kleurwaarde2) * 255);
                kleurwaarde3 = (int)(pixelintensiteit * (kleurwaarde3) * 255);
            }

            if (kleurwaarde1 > 255)
                kleurwaarde1 = 255;
            if (kleurwaarde2 > 255)
                kleurwaarde2 = 255;
            if (kleurwaarde3 > 255)
                kleurwaarde3 = 255;

            return CreateColor((int)kleurwaarde1, (int)kleurwaarde2, (int)kleurwaarde3);
        }

        float lampintensiteit(Vector2 positie, int x, int y, int intens, Surface scr)
        {
            bool rayintersect = false;
            Ray ray = new Ray(new Vector2(x, y), positie); // positie is de positie van de lamp
            float afstand;

            foreach (Primitive obj in elementen)
            {
                if (obj.incirkel(ray)) // bovenop de pilaren valt geen licht, dus deze zijn zwart
                    return 0;
                if (!rayintersect) // als de ray is geintersect, hoef je de andere objecten niet meer af te gaan en wil je met deze lamp niet meer tekenen
                {
                    if (obj.intersect(ray))
                        rayintersect = true;
                }
            }
            if (!rayintersect)
            {
                afstand = Vector2.Dot(new Vector2(x, y) - positie, new Vector2(x, y) - positie) / Math.Max(scr.height, scr.width); // de afstand is zo afhankelijk van je scherm
                return (float)(intens / (1 + 0.2 * afstand * afstand)); // verander de attenuation
            }
            else return 0;
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }

    }
}