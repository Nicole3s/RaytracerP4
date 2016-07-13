Nicole van den Dries 5639050
Laura Tigchelaar 3970035

De opdracht:
Implementeer een 2D ray tracer. Dat ziet er zo uit: maak een 2D veld waar je van bovenaf op kijkt, 
met daarop 4 vaste 'pilaren' (circels dus), en laat in die scene minstens 2 lampen bewegen in een patroon. 
Bereken voor elke pixel van het veld de lichtopbrengst voor de lampen, met attenuation en schaduwen.

Wij hebben zeven vaste pilaren en drie bewegende lichten (een rode en een groene) en twee vaste lichten (een witte en een blauwe).
Er is sprake van distance attenuation en schaduwen. We maken uitsluitend gebruik van puntlichtbronnen.

Voor het bepalen van de distance attenuation hebben wij ons laten inspireren door:
	http://www.tomdalling.com/blog/modern-opengl/07-more-lighting-ambient-specular-attenuation-gamma/

Voor het toepassen van de ABC formule bij het bepalen van intersecties hebben wij ons laten inspireren door:
	http://stackoverflow.com/questions/1073336/circle-line-segment-collision-detection-algorithm

Extra toevoegingen:
Verschillende kleuren licht.
Zeven Pilaren.
Vijf lichtbronnen.

