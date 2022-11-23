# Thomas Maskinporten

### Introduksjon
Dette er et bibliotek for bruk av JWT tokens mot Maskinporten.
Dette biblioteket er skrevet primært for å vise hvordan JWT tokens er bygget opp og flyten mot maskinporten og ressursene du prøver å nå.
Fokuset er på læring ,derfor er f.eks måten tokenet genererers på veldig forenklet.

Du vil trenge et virksomhetssertifikat for å kunne bruke Maskinporten. Virksomhetsertifikat kan bestilles hos f.eks Buypass.
Du trenger også tilgang til https://selvbetjening-samarbeid-ver2.difi.no/integrations for å opprette nye klienter for maskinporten. 

Koden funker og kan brukes ,men anbefaler og bruke et annet bilbiotek i produksjon som f.eks System.IdentityModel.Tokens.Jwt 

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

### Hvordan koden fungerer. 
JWT Token er bygget opp av 3 deler adskilt med punktum "xxx.yyy.zzzz". De 3 delene er Header, Payload og Signatur.
De 2 første delene er bare Base64 enkodet Json og kan dekodes av hvilken som helst Base64 dekoder ,men anbefalter å bruker https://jwt.io/ for å decode tokens. 


!Kommer

####  Sertifikater

#### Generer Token & Token Header

#### Signer Token. 

#### Veksle inn Token hos Maskinporten

### Testing med Postman
!Kommer

### JWT Token Eksempel

Token som sendes til maskinporten (Obs! Noen tjenster krever at resource er satt ,dette vil gjenspeiles i audience på tokenet du får tilbake fra maskinporten.)


<img width="250" alt="JWT Token Til maskinporten" src="https://user-images.githubusercontent.com/8003056/203565938-97fb1888-3005-4925-813c-a98af7efe00d.PNG">
Token som du får tilbake fra maskinporten. 

<img width="250" alt="JWT Token Fra maskinporten" src="https://user-images.githubusercontent.com/8003056/203565869-9ec73905-1c14-40cc-bbc1-6295d867db22.PNG">


