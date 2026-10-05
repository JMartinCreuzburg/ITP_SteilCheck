# Arbeitsplatz einrichten

Ab Block 2 schreibt und startet ihr Tests. Dafür gibt es zwei Wege. Beide funktionieren ohne Adminrechte und kosten
nichts.

| | Weg A: github.dev | Weg B: lokal |
|---|---|---|
| Installation | keine, nur ein Browser | VS Code, GitHub Desktop, .NET-SDK (ohne Adminrechte) |
| Tests starten | automatisch auf GitHub nach jedem Commit, etwa 2 Minuten | selbst im Terminal, wenige Sekunden |
| Gut für | eigene Testdatei | alles, besonders TDD im Paar |

Probiert **Weg B**. Wenn er auf eurem Gerät nicht klappt (zum Beispiel wegen Vorgaben eures Betriebs), nehmt **Weg A**.
Meldet danach in Mebis bei der Abstimmung „Welcher Weg hat geklappt?“, wie es gelaufen ist.

## Weg A: github.dev im Browser

1. Öffnet dieses Repo auf GitHub und drückt die Taste **`.`** (Punkt). Es öffnet sich VS Code im Browser.
2. Öffnet eine Datei, zum Beispiel `abnahme/SteilCheck.Abnahmetests/PersonenzahlTests.cs`.
3. Zum Speichern: links **Quellcodeverwaltung** (Symbol mit Verzweigung), Nachricht eintragen, **Commit & Push**.
4. Die Tests laufen danach automatisch: auf GitHub Reiter **Actions** → neuester Lauf „Tests“ → Zusammenfassung.
5. Den Branch wechselt ihr unten links in der Statusleiste.

## Weg B: lokal ohne Adminrechte

### 1. Programme installieren

- **VS Code:** [code.visualstudio.com/download](https://code.visualstudio.com/download). Unter Windows den **User
  Installer** wählen.
- **GitHub Desktop** (bringt Git mit): [desktop.github.com](https://desktop.github.com). Es installiert sich ohne
  Adminrechte.

### 2. .NET-SDK 10 ins eigene Benutzerverzeichnis installieren

**Windows:** PowerShell öffnen und die drei Zeilen nacheinander ausführen.

```powershell
Invoke-WebRequest https://dot.net/v1/dotnet-install.ps1 -OutFile "$env:TEMP\dotnet-install.ps1"
powershell -NoProfile -ExecutionPolicy Bypass -File "$env:TEMP\dotnet-install.ps1" -Channel 10.0 -InstallDir "$env:LOCALAPPDATA\Microsoft\dotnet"
[Environment]::SetEnvironmentVariable("Path", "$env:LOCALAPPDATA\Microsoft\dotnet;" + [Environment]::GetEnvironmentVariable("Path", "User"), "User")
```

**macOS / Linux:** Terminal öffnen. Unter Linux steht statt `~/.zshrc` meist `~/.bashrc`.

```bash
curl -sSL https://dot.net/v1/dotnet-install.sh -o dotnet-install.sh
bash dotnet-install.sh --channel 10.0
echo 'export DOTNET_ROOT="$HOME/.dotnet"; export PATH="$HOME/.dotnet:$PATH"' >> ~/.zshrc
```

Terminal schließen und neu öffnen. Prüfen:

```bash
dotnet --list-sdks
```

In der Liste muss eine Version `10.0.…` stehen.

### 3. Team-Repo holen und prüfen

1. In GitHub Desktop anmelden, **Clone a repository** wählen und dieses Repo klonen.
2. **Open in Visual Studio Code** wählen. Die vorgeschlagene Erweiterung **C# Dev Kit** installieren.
3. In VS Code ein Terminal öffnen (Menü **Terminal** → **Neues Terminal**) und eingeben: `dotnet build`. Steht am
   Ende, dass der Build erfolgreich war, ist alles bereit.

## Wenn etwas nicht klappt

- **PowerShell meldet, dass Skripte deaktiviert sind:** Das Gerät erlaubt keine Skripte. Nehmt Weg A.
- **`dotnet --list-sdks` zeigt keine Version 10.0:** Auf dem Gerät ist eine ältere .NET-Version fest installiert.
  Nehmt Weg A und meldet das in der Abstimmung.
- **Codespaces** nutzen wir nicht. Bitte startet auch keinen.
