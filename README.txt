Nicole van den Dries 5639050
Laura Tigchelaar 3970035

De opdracht:
Implementeer een 2D ray tracer. Dat ziet er zo uit: maak een 2D veld waar je van bovenaf op kijkt, 
met daarop 4 vaste 'pilaren' (circels dus), en laat in die scene minstens 2 lampen bewegen in een patroon. 
Bereken voor elke pixel van het veld de lichtopbrengst voor de lampen, met attenuation en schaduwen.

Wij hebben acht vaste pilaren, drie bewegende lichten (een witte, een rode en een groene) en twee vaste lichten (een roze arealight en een blauw puntlicht).
Er is sprake van distance attenuation en schaduwen. We maken gebruik van puntlichtbronnen en een arealight. Alles is volledig aanpasbaar aan de eigen gewenste situatie.
Wij willen er bij voorbaat op wijzen dat het programma vrij langzaam is. Er zit wel degelijk beweging in (een schuine, een op-/neerwaartse en een cirkelvormige beweging),
dus wij hopen dat hier genoeg geduld voor is. Om het programma te versnellen kan de arealight worden uitgecomment (regel 36 in Raytracer class).

Voor het bepalen van de distance attenuation hebben wij ons laten inspireren door:
	http://www.tomdalling.com/blog/modern-opengl/07-more-lighting-ambient-specular-attenuation-gamma/

Voor het toepassen van de ABC formule bij het bepalen van intersecties hebben wij ons laten inspireren door:
	http://stackoverflow.com/questions/1073336/circle-line-segment-collision-detection-algorithm

Extra toevoegingen:
Verschillende kleuren licht.
Verschillende patronen waarin het licht zich verplaatst.
Acht Pilaren.
Vier puntlichtbronnen.
Area light (met de mogelijkheid meer arealights toe te voegen en een variabel aantal rays dat wordt verzonden op de arealight).

Variabelen in programma:
Pilaren:
	locatie en radius
Puntlichtbronnen:
	locatie, type beweging, intensiteit, kleur
Area lights:
	locaties twee uitersten, intensiteit, kleur, aantal 'checkpoints' (voor rays), beweegrichting

