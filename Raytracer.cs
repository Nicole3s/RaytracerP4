using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Raytracer
    {
        Scene scene;
        Camera camera; // deze heb je alleen nodig als je in en uit wilt gaan zoomen e.d.
        public Surface screen;

        public Raytracer() { }

        public void Init()
        {

        }
        public void Tick()
        {
            screen.Clear(0);
            Render();

        }
        public void Render()
        {
            screen.circle(screen.width / 2, screen.height / 2, 100, CreateColor(0, 255, 0));
        }

        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
