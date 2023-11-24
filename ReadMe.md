# YASLMAT

## Sketch

### Aufbau Dateisystem

```
┌root directory
├─index.json
├─{id}_shopping list name 1.json
├─{id}_shopping list name 2.json
├─{id}_shopping list name 3.json
└─{id}_shopping list name 4.json
```

### Aufbau Dateien

#### index.json

```json
{
    "content" : [
        {   // this is the first shopping list
            "id" : ,                    // automatic (random, but unique)
            "name" : ,                  // mandatory (after file creation)
            "shop" : ,                  // optional
            "full-item-count" : ,       // automatic
        },
        {   // this is the second shopping list
            "id" : ,                    // automatic (random, but unique)
            "name" : ,                  // mandatory (after file creation)
            "shop" : ,                  // optional
            "full-item-count" : ,       // automatic
        },
    ],
}
```

#### {id}_shopping list name.json

```json
{
    "metadata" : {
        "id" : ,                        // automatic (random, but unique)
        "name" : ,                      // mandatory (after file creation)
        "shop" : ,                      // optional
        "full-item-count" : ,           // automatic
    },
    "content" : [
        {   // this is the first item
            "item-count" : ,            // mandatory
            "item-name" : ,             // mandatory
            "item-price-for-one" : ,    // optional
            "item-price-for-count" : ,  // automatic
        },
        {   // this is the second item
            "item-count" : ,            // mandatory
            "item-name" : ,             // mandatory
            "item-price-for-one" : ,    // optional
            "item-price-for-count" : ,  // automatic
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
        - Abbrechen
          - (automatisch) alles verwerfen
          - (automatisch) datei nicht erstellen
          - (automatisch) zurück zum main Menü
      - (dauerhaft unten anzeigen) Optionen 
        - Abbrechen (alles Verwerfen, Datei nicht erstellen, zurück zum Main menü)
    - Anzeigen aller vorhandenen Listen
      - Optionen
        - Bearbeiten der Liste
        - Löschen der Liste
        - zurück zur Anzeige aller Listen
    - Auswählen und Anzeigen einer Liste
    - Auswählen und Bearbeiten einer Liste
    - Auswählen und Löschen einer Liste