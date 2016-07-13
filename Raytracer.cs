using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class Raytracer
    {
        Scene scene;
        //Camera camera; // deze heb je alleen nodig als je in en uit wilt gaan zoomen e.d.
        public Surface screen;

        public Raytracer() { }

        public void Init()
        {
            scene = new Scene();
            // pilaren
            scene.AddObject(new circle(new Vector2(screen.width / 2, screen.height / 2), 75)); // grote pilaar in het midden
            scene.AddObject(new circle(new Vector2(screen.width / 6, 50), 30)); // kleinere pilaar linksbovenin
            scene.AddObject(new circle(new Vector2(screen.width / 4 * 3, screen.height / 6), 45)); // middelgrote pilaar rechts bovenin
            scene.AddObject(new circle(new Vector2(screen.width / 5 * 4, screen.height / 3), 10)); //kleine pilaar rechtsboven de grote
            scene.AddObject(new circle(new Vector2(screen.width / 2, screen.height / 4), 10));
            scene.AddObject(new circle(new Vector2(screen.width / 2 + 10, screen.height / 4 + 5), 10));
            scene.AddObject(new circle(new Vector2(screen.width / 2 + 35, screen.height / 4 - 5), 10));


            //lichten, kies voor intensiteit een waarde tussen 0 en 99
            scene.AddLightsource(new Light(new Vector2(50, screen.height / 2), 99, null, 1.0f, 1.0f, 1.0f));
            scene.AddLightsource(new Light(new Vector2(screen.width / 3, 15), 15, "rondje", 0.8f, 0.8f, 0.8f));
            scene.AddLightsource(new Light(new Vector2(screen.width / 5 * 2, screen.height / 6 * 5), 5, "schuin", 0.0f, 1.0f, 0.0f));
            scene.AddLightsource(new Light(new Vector2(screen.width * 0.75f, screen.height * 0.5f), 80, "op", 1.0f, 0.0f, 0.0f));
            scene.AddLightsource(new Light(new Vector2(screen.width / 2 + 25, screen.height / 4), 50, null, 0.0f, 0.0f, 1.0f));
        }
        public void Tick()
        {
            screen.Clear(0);
            scene.Render(screen);
        }
        
        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
