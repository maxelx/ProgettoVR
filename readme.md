# dAnkle
## _Un exer game per la riabilitazione della caviglia_


dAnkle è un serious game nato per trasformare gli esercizi di riabilitazione fisioterapica (nello specifico per la caviglia) in un esperienza ludica e allo stesso tempo utile.
Nel particolare l'esercizio che si è cercato di implementare è [questo][eser], come è possibile vedere dal video si tratta di un esercizio che prevede una fase avanzata della riabilitazione in quanto è richiesto al paziente di muovere molto l'arto inferiore.


## Classi

- Contatore
- IP
- Movement
- Spawner
- VR button

Contatore

> Questa classe si occupa di definire il testo che va mostrato al giocatore sul braccio
> Si occupa di gestire la macchina a stati che governa il gioco attraverso una variabile statica "counter"
> Si occupa inoltre di calcolare il punteggio : colpiti/totali

IP

> La classe che gestisce gli eventi provenienti dalla rete
> All'avvio apre una porta udp in ricezione e lancia un thread che si mette in ascolto
> Si occupa inoltre di modificare la posizione e la rotazione degli arti inferiori all'interno del mondo virtuale

Movement

> La classeimplementa il movimento dei singoli proiettili
> Si occupa anche di controllare se i proiettili hanno toccato i "piedi" del giocatore, in quel caso aumenta il contatore dei punti

Spawner

> La classe che genera i proiettili
> Genera sia i 4 proiettili demo in modo hardcoded
> Sia analizza la traccia audio implementando un semplice pick analyzer
> La classe risponde all'evento di picco generando un proiettile in posizione random

VR button

> La classe che gestisce gli eventi di click del bottone
> Implementa l'animazione di movimento del bottone al tocco
> Fa progredire la macchina a stati aumentando il valore della classe Contatore

   [eser]: <https://youtu.be/Ux9JwhOcW3A?t=311>
