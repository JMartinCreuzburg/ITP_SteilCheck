# Lastenheft SteilCheck (Auszug)

| | |
|---|---|
| **Auftraggeber** | Steilwand Kletter- und Boulderzentren GmbH |
| **Gegenstand** | Check-in- und Kassen-App für die Theke der Hallen |
| **Fachlicher Ansprechpartner** | Jonas Brandl, Hallenleitung Fürth |
| **Stand** | Version 1.2 vom 12.05.2026 |

## Ziel

Die Mitarbeitenden an der Theke checken Gäste ein, berechnen den Eintrittspreis und kassieren. SteilCheck ersetzt
die bisherige Strichliste mit Preistabelle und Taschenrechner.

## Funktionale Anforderungen

| Nr. | Anforderung |
|---|---|
| F1 | Tageseintritt: Kinder (6 bis 14 Jahre) 9,00 € · Jugendliche (14 bis 17 Jahre) 12,00 € · Erwachsene (18–64) 15,50 € · Senioren (ab 65) 12,00 € |
| F2 | Kleinkinder unter 6 Jahren kostenlos, nur in Begleitung mindestens einer zahlenden erwachsenen Person |
| F3 | Ermäßigung 15 % auf den Einzelpreis für Schüler:innen, Studierende und Azubis mit gültigem Ausweis (nur Jugendliche und Erwachsene) |
| F4 | Abendtarif: Einlass ab 20:00 Uhr 25 % auf den Einzelpreis, kombinierbar mit Ermäßigung |
| F5 | Leihschuhe 3,50 € pro Paar, nicht rabattfähig |
| F6 | Gruppenrabatt: ab 5 zahlenden Personen 10 % auf die Summe der Eintrittspreise (nicht auf Leihschuhe) |
| F7 | Ein Check-in umfasst 1–10 Personen, Alter 0–99, Einlass 10:00–22:00 Uhr |
| F8 | Bon mit Einzelpositionen und Gesamtpreis. Der Bon muss mit dem Kassenbetrag übereinstimmen. |
| F9 | Auslastungsanzeige für die Theke: Ampel grün unter 70 %, gelb ab 70 %, rot ab 85 % Belegung (Kapazität 120 Personen) |
| F10 | Rundung kaufmännisch auf volle Cent, je Einzelpreis |

## Nichtfunktionale Anforderungen

| Nr. | Anforderung |
|---|---|
| N1 | Bedienung auf dem Theken-Tablet (10 Zoll, Touch) |
| N2 | Personenbezogene Daten (Name für den Haftungsausschluss) werden DSGVO-konform verarbeitet und sind nur für Mitarbeitende sichtbar |
| N3 | Lauffähig in aktuellen Versionen von Chrome, Edge und Safari |
