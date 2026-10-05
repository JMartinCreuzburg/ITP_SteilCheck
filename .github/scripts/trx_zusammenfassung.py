"""Schreibt eine kurze Markdown-Zusammenfassung eines Testlaufs (TRX-Datei) für GitHub Actions."""
import sys
import xml.etree.ElementTree as ET

titel, datei = sys.argv[1], sys.argv[2]
ns = {"t": "http://microsoft.com/schemas/VisualStudio/TeamTest/2010"}
try:
    wurzel = ET.parse(datei).getroot()
except (OSError, ET.ParseError):
    print(f"## {titel}\n\nKein Testergebnis gefunden. Ist der Build fehlgeschlagen?")
    sys.exit(0)

ergebnisse = wurzel.findall(".//t:UnitTestResult", ns)
rot = [e for e in ergebnisse if e.get("outcome") == "Failed"]
print(f"## {titel}: {len(ergebnisse) - len(rot)} von {len(ergebnisse)} bestanden\n")
if rot:
    print("| Test | Meldung |\n|---|---|")
    for e in sorted(rot, key=lambda e: e.get("testName")):
        meldung = e.findtext(".//t:Message", default="", namespaces=ns).strip().splitlines()
        meldung = " ".join(z.strip() for z in meldung[:3]).replace("|", "\\|")
        print(f"| `{e.get('testName')}` | {meldung} |")
