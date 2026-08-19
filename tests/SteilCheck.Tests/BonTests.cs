using SteilCheck.Logik;

namespace SteilCheck.Tests;

public class BonTests
{
    private CheckIn EinePerson(bool schuhe)
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "Max Muster", Alter = 30, Schuhe = schuhe });
        return checkIn;
    }

    [Fact]
    public void Bon_hat_eine_Position_pro_Gast()
    {
        var checkIn = EinePerson(false);
        checkIn.Gaeste.Add(new Gast { Name = "Erika Muster", Alter = 30 });
        var bon = new BonErsteller().Erstelle(checkIn);
        Assert.Equal(2, bon.Positionen.Count);
    }

    [Fact]
    public void Bon_Gesamt_eine_Person()
    {
        var bon = new BonErsteller().Erstelle(EinePerson(false));
        Assert.Equal(15.50m, bon.Gesamt);
    }

    [Fact]
    public void Bon_mit_Leihschuhen()
    {
        var bon = new BonErsteller().Erstelle(EinePerson(true));
        Assert.Equal(19.00m, bon.Gesamt);
    }

    [Fact]
    public void Bon_wird_erstellt()
    {
        var ersteller = new BonErsteller();
        var bon = ersteller.Erstelle(EinePerson(true));
        Console.WriteLine(ersteller.AlsText(bon));
    }
}
