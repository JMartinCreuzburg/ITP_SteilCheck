# Testfälle D: Alter und Kombinationen

**Bearbeitet von:** _Name_ · **Lastenheft:** F1, F5, F6, F8, F10

Übernehmt die Äquivalenzklassen für das Alter aus dem Auftrag B1-6 („Von der Tafel“). Ergänzt Kombinationen,
z. B. Gruppe mit Leihschuhen (stimmen Kasse und Bon überein?) oder Abend mit Ermäßigung.

## So füllt ihr die Tabelle aus

- **Happy Path:** der normale, gültige Fall, wie er an der Theke am häufigsten vorkommt.
- **Alternative Path:** ein anderer gültiger Fall, der einen anderen Weg durch die Regeln nimmt.
- **Exceptional Path:** ein ungültiger Fall. SteilCheck muss ihn ablehnen.
- **ÄK / Grenzwert:** Welche Äquivalenzklasse prüft der Fall, und liegt der Wert auf einer Grenze?
- **Erwartet:** laut Lastenheft oder Auskunft von Jonas (steht im Auftrag), **nicht** laut SteilCheck.

Mindestens 1 Happy Path, 2 Alternative Paths und 3 Exceptional Paths.
Die erste Zeile ist ein Beispiel.

| ID | Pfad | ÄK / Grenzwert | Eingaben | Erwartet | Tatsächlich | OK? |
|---|---|---|---|---|---|---|
| D-00 | Happy | ÄK Erwachsene (18–64), Repräsentant | 1 Person, 30 J., ohne Ausweis, ohne Leihschuhe, Einlass 15:00 | 15,50 € | 15,50 € | ✓ |
| D-01 | | | | | | |
| D-02 | | | | | | |
| D-03 | | | | | | |
| D-04 | | | | | | |
| D-05 | | | | | | |
| D-06 | | | | | | |
