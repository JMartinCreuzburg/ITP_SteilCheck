namespace SteilCheck.Logik;

public class CheckInPruefer
{
    public bool IstGueltig(CheckIn checkIn)
    {
        // TODO: weitere Prüfungen
        foreach (var g in checkIn.Gaeste)
        {
            if (string.IsNullOrEmpty(g.Name))
                return false;
        }
        return true;
    }
}
