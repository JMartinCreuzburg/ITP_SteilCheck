namespace SteilCheck.Logik;

public class Gast
{
    public string Name { get; set; } = "";
    public int Alter { get; set; }
    public string Telefon { get; set; } = "";
    public bool Ausweis { get; set; }
    public bool Schuhe { get; set; }
}

public class CheckIn
{
    public List<Gast> Gaeste { get; set; } = new List<Gast>();
    public TimeOnly Einlass { get; set; }
    public string WieErfahren { get; set; } = "";
}

public class Bon
{
    public List<BonPosition> Positionen { get; set; } = new List<BonPosition>();
    public decimal Gesamt { get; set; }
}

public class BonPosition
{
    public string Text { get; set; } = "";
    public decimal Betrag { get; set; }
}
