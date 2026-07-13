namespace SteilCheck.App.Services;

public class CheckInEintrag
{
    public string Datum { get; set; } = "";
    public string Einlass { get; set; } = "";
    public string Name { get; set; } = "";
    public string Telefon { get; set; } = "";
    public int Alter { get; set; }
    public int Personen { get; set; }
}

public class Statistik
{
    public List<CheckInEintrag> Eintraege { get; set; } = new List<CheckInEintrag>();
    public Dictionary<string, int> BelegungProStunde { get; } = new Dictionary<string, int>();
    public int BelegtJetzt { get; private set; }

    // Belegung der letzten 14 Tage neu berechnen, damit die Ampel immer aktuell ist
    public void Neuberechnen()
    {
        if (Eintraege.Count == 0)
            return;

        BelegungProStunde.Clear();
        var letzterTag = DateTime.Parse(Eintraege.Max(e => e.Datum));
        for (int tag = 0; tag < 14; tag++)
        {
            var datum = letzterTag.AddDays(-tag);
            for (int stunde = 10; stunde <= 22; stunde++)
            {
                int belegt = 0;
                foreach (var e in Eintraege)
                {
                    var einlass = DateTime.Parse(e.Datum + " " + e.Einlass);
                    if (einlass.Date == datum && einlass.Hour <= stunde && einlass.Hour + 2 > stunde)
                        belegt += e.Personen;
                }
                BelegungProStunde[datum.ToString("yyyy-MM-dd") + " " + stunde] = belegt;
            }
        }

        var jetzt = Math.Clamp(DateTime.Now.Hour, 10, 22);
        BelegtJetzt = BelegungProStunde[letzterTag.ToString("yyyy-MM-dd") + " " + jetzt];
    }
}
