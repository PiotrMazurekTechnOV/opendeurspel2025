# Backend

## Documentatie Backend opendeurspel 2025
Alexi - Merlin – Michee – Rubén – Soulayman


Overzicht:
Deze backend van het opendeurspel verwerkt gebruikersgegevens en beheert de verbinding met de database.
Alles word overlopen en uitgelegd


Al de bestanden op visual studio:
.gitignore / package-json / .env / server.js 


.gitignore
zorgt dat node_modules niet in de git bestand komt
dit voorzorgt dat er duizende bestanden terecht komen wat
je Git-repository onnodig groot maakt.


package.json
bevat belangrijke informatie zoals de projectnaam, versie, benodigde pakketten, en commando’s die met npm run uitgevoerd kunnen worden.


.env 
.env slaat database- en serverinstellingen op.
HOST = "localhost"  -> de database draait lokaal op de laptop
USER = "root"  -> de gebruikersnaam om in te loggen
PASSWORD = "root" -> de wachtwoord van de gebruiker
DATABASE = "opendeurspel2025"  -> de naam van de database
PORT = "8081"  -> de poort waarop het luistert, 8081 is voor webserver.


server stappenplan
server.js maakt een server die verbinding met de SQL
1)	Zorg dat node.js geinstaleerd is, controleer dit met  “node -v” in de terminal ( gebruik cmd ) 
2)	Installeer de nodige pakketten: “ npm install express cors mysql2 dotenv ” ( in de projectmap).
3)	Start de server: “node server.js”
4)	Controleer of de server draait:  http://localhost:8081





API endpoints
Test endpoint
1)	URL: GET/test 
 controleert of server werkt
 Respons : “Welcome”
USERS
Gebruiker toevoegen
1)	URL: POST /user/create
Voegt een user toe aan database met mogelijke responsen:
201: Gebruiker succesvol toegevoegd
400: Verplichte velden ontbreken
500: Fout bij toevoegen van gebruiker
Gebruiker updaten
1)	URL: POST /user/update
Werkt de gegevens van een gebruiker bij op basis van ID.	
Gebruiker verwijderen
1)	DELETE / user/delete/:id
Verwijdert de gebruiker op basis van het ID.
	

QUESTIONS
Vraag aanmaken
1)	URL: POST /question/create
Aanmaken van de vragen.
Vraag updaten
1)	URL: POST /question/update
Wijzigt de tekst van een vraag op basis van een locatie-id.
Vraag verwijderen
1)	DELETE / question/:id
Verwijdert een vraag op basis van het id.
ANSWERS
 beantwoorden vragen ophalen
1)	URL: GET/ question/read
Haalt alle beantwoorde vragen op uit de database..
Vragen verwijderen
URL: DELETE /answers/:id
Verwijderd de vragen op basis van id
Vragen updaten
1)	 URL: POST /answers/update
Updaten van de vragen		


LOCATION
Locatie updaten
1)	URL: POST/location/update
  Wijzigt de naam van een locatie op basis van het id.
Locatie verwijderen 
1)	 URL: DELETE /location/:id
Het verwijderen van de locatie op basis van id






SCORE
Score toevoegen
1)	 URL: POST /scores/create
Voegt een nieuwe score toe aan de database
 URL: POST /scores/update
Werkt een bestaande score bij op basis van id.
Scoren verwijderen
1)	 URL: DELETE /scores/:id
Verwijdert een score op basis van het id.





200 OK: Als er antwoorden zijn voor de opgegeven vraag-id.
201: Gebruiker succesvol toegevoegd
400 Bad Request: Wanneer geen id is verstrekt in de querystring.
404 Not Found: Als er geen antwoorden zijn voor de opgegeven vraag-id.
500 Internal Server Error: Als er een server fout plaatsvindt.







