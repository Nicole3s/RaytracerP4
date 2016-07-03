using System;
using System.IO;

namespace Template {

class Game
{
	// member variables
	public Surface screen;
    public Surface debug;
    public Surface raytracer;
	// initialize
	public void Init()
	{
	}
	// tick: renders one frame
	public void Tick()
	{
		screen.Clear( 0 );
		raytracer.Print( "raytracer", 2, 2, 0xff55ff );
        debug.Print("debug", 2, 2, 0xff55ff);

        raytracer.CopyTo(screen, 0, 0);
        debug.CopyTo(screen,512, 0);
	}
}

} // namespace Template