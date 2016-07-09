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
            
            double afstand;

            for (int y = 0; y < scr.height; y++)
            {
                for(int x = 0; x < scr.width; x++)
                {
                    float intensiteit = 0.0f;
                    foreach (Primitive obj in elementen)
                    {
                        foreach(Light licht in lightsources)
                        {
                            if(!obj.intersect(new Ray(new Vector2(x, y), licht.positie)) )
                            {
                                afstand = Vector2.Dot(new Vector2(x, y) - licht.positie, new Vector2(x,y) - licht.positie) / Math.Max(scr.height, scr.width); // de afstand is zo afhankelijk van je scherm
                                intensiteit += (float)(licht.intensiteit / (1 + afstand * afstand)); // zorg dat je niet deelt door 0 en verander de attenuation
                            }
                           
                        }
                    }
                    int kleurwaarde;
                    if (intensiteit > 1)
                        kleurwaarde = 255; // grote intensiteit wordt 'gewoon' wit
                    else
                        kleurwaarde = (int)(intensiteit * 255);
                    scr.pixels[y * scr.width + x] = CreateColor(kleurwaarde, kleurwaarde, kleurwaarde);
                }
            }
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
