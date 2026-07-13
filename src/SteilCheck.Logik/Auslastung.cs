namespace SteilCheck.Logik;

public class Auslastung
{
    public string Ampel(int belegt)
    {
        double quote = belegt / 120.0;
        if (quote >= 0.85)
            return "rot";
        if (quote >= 0.7)
            return "gelb";
        return "gruen";
    }
}
