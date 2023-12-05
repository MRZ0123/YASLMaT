# YASLMAT

## Sketch

### Aufbau Dateisystem

```
┌root directory
├─program(.exe)
├─config.json
├─path
│ └─to
│   └─shlindex.json
└─path
  └─to
    └─data directory
      ├─{id}_shopping list name 1.json
      ├─{id}_shopping list name 2.json
      ├─{id}_shopping list name 3.json
      └─{id}_shopping list name 4.json
```

### Aufbau Dateien

#### shlindex.json

```json
{
    "MetadataIndex" : [
        {   // this is the first shopping list
            "Id" : ,                    // automatic (random, but unique)
            "Name" : ,                  // mandatory (after file creation)
            "Shop" : ,                  // optional
            "FullItemCount" : ,         // automatic
        },
        {   // this is the second shopping list
            "Id" : ,                    // automatic (random, but unique)
            "Name" : ,                  // mandatory (after file creation)
            "Shop" : ,                  // optional
            "FullItemCount" : ,         // automatic
        },
    ],
}
```

#### {id}_shopping list name.json

```json
{
    "Metadata" : {
        "Id" : ,                        // automatic (random, but unique)
        "Name" : ,                      // mandatory (after file creation)
        "Shop" : ,                      // optional
        "FullItemCount" : ,             // automatic
    },
    "Content" : [
        {   // this is the first item
            "ItemCount" : ,             // mandatory
            "ItemName" : ,              // mandatory
            "ItemPriceForOne" : ,       // optional
            "ItemPriceForCount" : ,     // automatic
        },
        {   // this is the second item
            "ItemCount" : ,             // mandatory
            "ItemName" : ,              // mandatory
            "ItemPriceForOne" : ,       // optional
            "ItemPriceForCount" : ,     // automatic
        },
    ],
}
```

## Funktionen

- Main menü
  - Auswahl
    - Erstellen einer Liste (erstellen Datei, dann ins Bearbeiten Menü)
      - (automatisch) Generation ID der Liste (Check, dass nicht doppelt)
      - (manuell) Eingabe Name der Liste
      - (optional) Eingabe Laden der Liste
      - (manuell) Abfrage
        - Liste Erstellen
          - (automatisch) Erstellung der Datei
          - (automatisch) schreiben Informationen in index.json
          - (automatisch) Verschiebe den Nutzer ins Bearbeiten Menü
        - Abbrechen
          - (automatisch) alles verwerfen
          - (automatisch) datei nicht erstellen
          - (automatisch) zurück zum main Menü
      - (dauerhaft unten anzeigen) Optionen 
        - Abbrechen (alles Verwerfen, Datei nicht erstellen, zurück zum Main menü)
    - Anzeigen aller vorhandenen Listen
      - (automatisch) index.json auslesen
      - (automatisch) für jede Liste Zeile, Namen und Laden anzeigen
      - (automatisch) id im Hinterkopf halten
      - Optionen
        - Liste Auswählen (Zeilennummer eingeben)
          - Bearbeiten der Liste (B/Bearbeiten eingeben)
            - -> Bearbeiten Menü
          - Löschen der Liste (L/Löschen eingeben)
            - (automatisch) Datei löschen
            - (automatisch) aus der index.json austragen
          - zurück zur Anzeige aller Listen (Z/Zurück eingeben)
    - Auswählen und Anzeigen einer Liste
    - Auswählen und Bearbeiten einer Liste
    - Auswählen und Löschen einer Liste