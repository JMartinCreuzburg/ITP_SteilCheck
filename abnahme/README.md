# Abnahme SteilCheck

Dieser Ordner gehört **Steilwand**, nicht AppWerk. Hier liegt alles, was wir für die Abnahme brauchen.

**Was gerade zu tun ist, steht im angepinnten Auftrag** (Reiter **Issues**, oben). Dort findet ihr auch die Links zu
den Formularen und Dateien, die ihr in der jeweiligen Phase braucht.

| Datei / Ordner | Wofür |
|---|---|
| [`Lastenheft.md`](Lastenheft.md) | Was Steilwand bei AppWerk bestellt hat |
| [`testfaelle/`](testfaelle/) | Eure Abnahmetestfälle, eine Datei pro Person (A–D) |
| [`SteilCheck.Abnahmetests/`](SteilCheck.Abnahmetests/) | Dieselben Testfälle als automatisierte Tests (Block 2) |
| [`Abnahmeprotokoll.md`](Abnahmeprotokoll.md) | Eure Entscheidung mit Begründung |
| [`Arbeitsplatz.md`](Arbeitsplatz.md) | So richtet ihr euch für Block 2 ein: github.dev oder lokal |

## Tests ausführen

**Im Browser (github.dev):** Nach jedem Commit laufen die Tests auf GitHub: Reiter **Actions** → neuester Lauf
„Tests“ → Zusammenfassung. Das dauert etwa zwei Minuten. Ein abgebrochener Lauf ist normal, der neueste Lauf prüft
alles.

**Lokal:**

```bash
dotnet test tests/SteilCheck.Tests            # die Tests von AppWerk
dotnet test abnahme/SteilCheck.Abnahmetests   # unsere Abnahmetests
```
