# Thomas Maskinporten

### Introduksjon
Dette er et bibliotek for bruk av JWT tokens mot Maskinporten.
Dette biblioteket er skrevet primært for å vise hvordan JWT tokens er bygget opp og flyten mot maskinporten og ressursene du prøver å nå.
Fokuset er på læring ,derfor er f.eks måten tokenet genererers på veldig forenklet.

Du vil trenge et virksomhetssertifikat enten for eget firma eller for et fiktivt firma fra Tenor Testdata for å kunne bruke maskinporten i Test.

### Innhold

#### Thomas.Maskinporten.Core
All funkjsonalitet for å generere tokens. 

#### Thomas.Maskinporten.ConsoleApp
Demo applikasjon for å generere et token. Default satt opp for vegvesenents eiersjekk.

#### Maskinporten.Postman.Collection
Postman collection som viser hvordan man kan kan veksle inn tokenet man genererer hos maskinporten og få tilbake et token som brukes mot tjenestene.
Test av eiersjekk hos vegvesenet testmiljø ved bruk av Maskinporten Token.
