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
        double graden = 0;//, gradBoog = 0;
        bool up = false;

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

            foreach (Light licht in lightsources) // bepaal per licht de beweging in het veld
            {
                if (countX == 20)
                {
                    if (up == true)
                        up = false;
                    else
                        up = true;
                    countX = 0;

                }

                switch (licht.beweging) // dit is sneller dan een if-else statement!
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
            float pixelintensiteit = 0.0f, intens; // intens is in de lamp, intensiteit is op de pixel
            float rood, groen, blauw;
            double afstand;
            int lichtenoppixel = 0; // begin altijd met nul lichten
            float kleurwaarde1 = 0, kleurwaarde2 = 0, kleurwaarde3 = 0; // begin altijd zonder licht
            bool lichtgebruikt;

            foreach (Light licht in lightsources)
            {
                lichtgebruikt = false;
                rood = licht.kw1;   // bepalen de kleur van je lamp
                groen = licht.kw2;
                blauw = licht.kw3;

                intens = licht.intensiteit;
                Ray ray = new Ray(new Vector2(x, y), licht.positie);

                foreach (Primitive obj in elementen)
                {
                    
                    if (obj.incirkel(ray)) // bovenop de pilaren valt geen licht, dus deze zijn zwart
                        return 0;
                    if (licht.positie.X == x && licht.positie.Y == y) // de positie van de lamp zelf
                        return CreateColor((int)(intens * rood / 10 * 255), (int)(intens * groen / 10 * 255), (int)(intens * blauw / 10 * 255));

                    if (!obj.intersect(ray) && !lichtgebruikt)
                    {
                        afstand = Vector2.Dot(new Vector2(x, y) - licht.positie, new Vector2(x, y) - licht.positie) / Math.Max(scr.height, scr.width); // de afstand is zo afhankelijk van je scherm
                        float lampintensiteit = (float)(intens * 0.035 / (1 + afstand * afstand)); // verander de attenuation
                        pixelintensiteit += lampintensiteit;
                        kleurwaarde1 += rood * lampintensiteit;
                        kleurwaarde2 += groen * lampintensiteit;
                        kleurwaarde3 += blauw * lampintensiteit;

                        lichtenoppixel++;
                        //lichtgebruikt = true;
                    }
                }
            }

            if (pixelintensiteit > 1)
            {
                // grote intensiteit wordt 'gewoon' fel, afhankelijk van de intensiteit van het licht
                kleurwaarde1 = (int)(kleurwaarde1 / lichtenoppixel * (255));
                kleurwaarde2 = (int)(kleurwaarde2 / lichtenoppixel * (255));
                kleurwaarde3 = (int)(kleurwaarde3 / lichtenoppixel * (255));
            }
            else
            {
                //kleurwaarde = (int)(intensiteit * (255 / 100));
                kleurwaarde1 = (int)(pixelintensiteit * (kleurwaarde1 / lichtenoppixel) * 255);
                kleurwaarde2 = (int)(pixelintensiteit * (kleurwaarde2 / lichtenoppixel) * 255);
                kleurwaarde3 = (int)(pixelintensiteit * (kleurwaarde3 / lichtenoppixel) * 255);
            }

            return CreateColor((int)kleurwaarde1, (int)kleurwaarde2, (int)kleurwaarde3);
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
