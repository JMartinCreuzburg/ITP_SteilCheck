# SteilCheck – Check-in & Kasse

**Version 1.0** · AppWerk GmbH · Lieferung an die Steilwand Kletter- und Boulderzentren GmbH

SteilCheck ist die Check-in- und Kassenlösung für die Theke der Steilwand-Hallen.
Alle Anforderungen aus dem Lastenheft wurden umgesetzt.

## Funktionen

- Check-in von Gästen in vier Schritten (Stammdaten, Personen, Kontrolle, Abschluss)
- Preisberechnung nach Tarif inkl. Ermäßigung, Abendtarif, Leihschuhe und Gruppenrabatt
- Bon mit Einzelpositionen
- Auslastungsampel für die Theke

## Projektstruktur

| Ordner | Inhalt |
|---|---|
| `src/SteilCheck.Logik` | Preisberechnung, Bon, Prüfung, Auslastung |
| `src/SteilCheck.App` | Oberfläche (Blazor WebAssembly) |
| `tests/SteilCheck.Tests` | Unit-Tests |

## Starten

```bash
dotnet run --project src/SteilCheck.App
```

## Tests

```bash
dotnet test tests/SteilCheck.Tests
```

Ergebnis bei Abnahme: **42 von 42 Tests bestanden** (siehe [Testbericht](Testbericht.md)).

## Ansprechpartner

Marco Lenz, Projektleitung · AppWerk GmbH
