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
            scene.AddObject(new circle(new Vector2(screen.width / 2, screen.height / 2), 100));
            scene.AddLightsource(new Light(new Vector2(50, screen.height / 2), 10000000));
        }
        public void Tick()
        {
            screen.Clear(0);
            scene.Render(screen);
            screen.circle(screen.width / 2, screen.height / 2, 100, CreateColor(0, 255, 0)); // referentiecirkel
        }
        
        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
