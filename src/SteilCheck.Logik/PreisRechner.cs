namespace SteilCheck.Logik;

public class PreisRechner
{
    // Preise laut Lastenheft F1
    public decimal Grundpreis(int alter)
    {
        return alter < 6 ? 0m : alter <= 14 ? 9.00m : alter <= 17 ? 12.00m : alter < 65 ? 15.50m : 12.00m;
    }

    public decimal Einzelpreis(int alter, bool ermaessigt, TimeOnly einlass)
    {
        if (alter < 6)
            return 0m;
        decimal preis = Grundpreis(alter);
        if (ermaessigt)
            preis *= 0.85m;
        if (einlass.Hour > 20)
            preis *= 0.75m;
        return Math.Round(preis, 2);
    }

    public decimal Gesamtpreis(CheckIn checkIn)
    {
        decimal summe = 0;
        foreach (var g in checkIn.Gaeste)
        {
            summe += Einzelpreis(g.Alter, g.Ausweis, checkIn.Einlass);
        }

        // Gruppenrabatt
        if (checkIn.Gaeste.Count(g => g.Alter >= 6) > 5)
        {
            summe = Math.Round(summe * 0.9m, 2);
        }

        foreach (var g in checkIn.Gaeste)
        {
            if (g.Schuhe)
                summe += 3.50m;
        }
        return summe;
    }
}
