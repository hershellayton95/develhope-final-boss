
## Test finale

### Completa l'applicazione
Quest'applicazione gestisce dei progetti (Project), ognuno di loro avrà delle attività (Job) assegnate.

Le informazioni sono salvate su file in formato json, _"./Data/projects.json"_ conterrà i progetti, mentre _"./Data/jobs.json"_ conterrà le attività.

L'applicazione dovrà contenere i seguenti flussi, **in ordine di priorità**:
- Get che ritorna la lista di progetti
- Get che ritorna un progetto a partire da Id (comprese le sue attività)
- Get che ritorna i progetti non ancora consegnati (DeliveryDate non ancora passata)
- Creazione progetto
- Creazione attività
- Modifica progetto
- Modifica attività
- Cancella progetto (comprese le sue attività)
- Cancella attività

I flussi possono essere implementati utilizzando delle _view_, delle _api_ o entrambi.

