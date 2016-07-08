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
                    int intensiteit = 0;
                    foreach (Primitive obj in elementen)
                    {
                        foreach(Light licht in lightsources)
                        {
                            if(!obj.intersect(new Ray(new Vector2(x, y), licht.positie)) )
                            {
                                afstand = Math.Sqrt(Math.Pow((x - licht.positie.X), 2) + Math.Pow((y - licht.positie.Y),2));
                                intensiteit += (int)((licht.intensiteit) / (afstand * afstand));
                            }
                           
                        }
                    }
                    scr.pixels[y * scr.width + x] = ( CreateColor(intensiteit, intensiteit, intensiteit));
                }
            }
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
