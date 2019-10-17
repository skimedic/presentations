#language:de

Funktionalität: Punkteberechnung    
    Als Spieler
    Will ich, dass das System meine Punktezahl berechnet
    Damit ich weiss wie gut ich bin

Szenario: Keine Punkte
	Gegeben sei eine neue Bowling-Partie
	Wenn alle meine Kugeln in der Seitenrinne landen
    Dann soll meine Punktzahl 0 sein

Szenario: Anfänger-Spiel
    Gegeben sei eine neue Bowling-Partie
    Wenn ich 2 und 7 werfe
    Und ich 3 und 4 werfe
    Und ich 8 mal 1 und 1 werfe
	Dann soll meine Punktzahl 32 sein 
		
Szenario: Weiteres Anfänger-Spiel
    Gegeben sei eine neue Bowling-Partie
    Wenn ich folgende Serie werfe: 2,7,3,4,1,1,5,1,1,1,1,1,1,1,1,1,1,1,5,1
	Dann soll meine Punktzahl 40 sein 	
	
Szenario: Nur Strikes
	Gegeben sei eine neue Bowling-Partie
	Wenn ich nur Strikes werfe
	Dann soll meine Punktzahl 300 sein	
	
Szenario: Ein einziger Spare
    Gegeben sei eine neue Bowling-Partie
    Wenn ich folgende Serie werfe: 3,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
    Dann soll meine Punktzahl 29 sein 
	
Szenario: Nur Spares
    Gegeben sei eine neue Bowling-Partie
    Wenn ich 10 mal 1 und 9 werfe
    Und ich 1 werfe	
    Dann soll meine Punktzahl 110 sein
