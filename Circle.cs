using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Template
{
    class circle : Primitive
    {
        int radius;
        public circle(Vector2 positie, int rad)
        {
            locatie = positie;
            radius = rad;
        }
        public override bool intersect(Ray ray)
        {
            // bepaal de richting van de ray
            Vector2 direction = ray.goal - ray.origin;

            // bereken de waarden voor de abc-formule
            double a = Vector2.Dot(direction, direction);
            double b = 2 * Vector2.Dot(ray.origin - locatie, direction);
            double c = Vector2.Dot(ray.origin - locatie, ray.origin - locatie) - radius * radius;

            // bepaal de discriminant
            double D = Math.Pow(b, 2) - 4 * a * c;

            // als de discriminant < 0 is er geen intersectie
            if (D < 0)
                return false;
            // als D == 0, raakt de ray de cirkel, maar hij snijdt niet, 
            // dus er is geen intersectie en de invloed van het licht wordt meegenomen
            else if (D == 0)
                return false;
            // als D > 0 moet je bepalen of de te tekenen pixel voor of achter het object ligt
            else
            {
                // voer de overige berekeningen voor de abc formule uit
                double wortelD = Math.Sqrt((D));
                double intersectie1 = -b + wortelD / (2 * a);
                double intersectie2 = -b - wortelD / (2 * a);

                // als de intersectiepunten tussen nul en een liggen, bevindt de pixel zich binnen of achter het object
                if ((intersectie2 <= 1 && intersectie2 >= 0) || (intersectie1 >= 0 && intersectie1 <= 1)    )
                {
                    return true;
                }

                return false;
            }
        }
    }
}
