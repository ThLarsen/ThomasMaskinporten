# Thomas Maskinporten

### Introduksjon
Dette er et bibliotek for bruk av JWT tokens mot Maskinporten.
Dette biblioteket er skrevet primært for å vise hvordan JWT tokens er bygget opp og flyten mot maskinporten og ressursene du prøver å nå.
Fokuset er på læring ,derfor er f.eks måten tokenet genererers på veldig forenklet.

Du vil trenge et virksomhetssertifikat for å kunne bruke Maskinporten. Virksomhetsertifikat kan bestilles hos f.eks Buypass.
Du trenger også tilgang til https://selvbetjening-samarbeid-ver2.difi.no/integrations for å opprette nye klienter for maskinporten. 

### Innhold

#### Thomas.Maskinporten.Core
All funkjsonalitet for å generere tokens. 

#### Thomas.Maskinporten.ConsoleApp
Demo applikasjon for å generere et token. Default satt opp for vegvesenents eiersjekk.

#### Maskinporten.Postman.Collection
Postman collection som viser hvordan man kan kan veksle inn tokenet man genererer hos maskinporten og få tilbake et token som brukes mot tjenestene.
Test av eiersjekk hos vegvesenet testmiljø ved bruk av Maskinporten Token.

## Maskinporten
Hva er maskinporten? Maskinporten er en løsning for autentisering av maskin-til-maskin kommunikasjon ,basert på 3-legged-oauth prinsippet. De fleste norske offenlige virksomheter har tatt i bruk maskinporten, eller jobber med det. Altinn, Vegvesenet ,Folkeregisteret ,Skatteetaten krever alle maskinporten. 

Kort forklart så funker maskinporten slik.
 - Du lager et token (JWT token) som du signerer med virksomhetssertifikatet.
 - Du sender dette tokenet til maskinporten som verifiserer innholdet og gir deg tilbake et nytt token (jwt)
 - Du bruker tokenet du får tilbake fra maskinporten til å autentisere mot f.eks vegvesenet eiersjekk (oauth 2.0 bearer token)

### Virksomhetssertifikat
!Kommer

### Samarbeidsportalen (Integrasjoner/klienter)
!Kommer


