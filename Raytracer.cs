﻿using System;
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
            scene.AddObject(new circle(new Vector2(screen.width / 4 * 3, screen.height / 6), 45));
            scene.AddObject(new circle(new Vector2(screen.width / 2 * 1.03f, screen.height / 3), 10)); //kleine pilaar rechtsboven de grote

            //lichten
            scene.AddLightsource(new Light(new Vector2(50, screen.height / 2), 75));
            scene.AddLightsource(new Light(new Vector2(screen.width / 3, 15), 1));
            scene.AddLightsource(new Light(new Vector2(screen.width / 3 * 2, screen.height/2 - 20), 15));
        }
        public void Tick()
        {
            screen.Clear(0);
            scene.Render(screen);
            //screen.circle(screen.width / 2, screen.height / 2, 100, CreateColor(0, 255, 0)); // referentiecirkel
        }
        
        int CreateColor(int red, int green, int blue)
        { return (red << 16) + (green << 8) + blue; }
    }
}
