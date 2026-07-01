namespace SteilCheck.Logik;

public class BonErsteller
{
    public Bon Erstelle(CheckIn checkIn)
    {
        var bon = new Bon();
        var rechner = new PreisRechner();

        foreach (var g in checkIn.Gaeste)
        {
            var preis = rechner.Einzelpreis(g.Alter, g.Ausweis, checkIn.Einlass);
            bon.Positionen.Add(new BonPosition { Text = "Eintritt " + g.Name, Betrag = preis });
            if (g.Schuhe)
            {
                bon.Positionen.Add(new BonPosition { Text = "Leihschuhe", Betrag = 3.50m });
            }
        }

        decimal summe = bon.Positionen.Sum(p => p.Betrag);

        if (checkIn.Gaeste.Count(g => g.Alter >= 6) > 5)
        {
            var rabatt = Math.Round(summe * 0.1m, 2);
            bon.Positionen.Add(new BonPosition { Text = "Gruppenrabatt", Betrag = -rabatt });
            summe = summe - rabatt;
        }

        bon.Gesamt = summe;
        return bon;
    }

    public string AlsText(Bon bon)
    {
        var text = "STEILWAND BOULDERHALLE\n";
        foreach (var p in bon.Positionen)
        {
            text += p.Text.PadRight(30) + p.Betrag.ToString("0.00") + "\n";
        }
        text += "GESAMT".PadRight(30) + bon.Gesamt.ToString("0.00") + "\n";
        return text;
    }
}
