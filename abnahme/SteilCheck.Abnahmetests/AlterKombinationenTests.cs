namespace SteilCheck.Abnahmetests;

// Person D: Alter und Kombinationen (Lastenheft F1, F5, F6, F8, F10)
// Übertragt eure Testfälle aus abnahme/testfaelle/alter-kombinationen.md.
// Eine Zeile [InlineData(...)] ist ein Testfall. Muster: die Tests von AppWerk in tests/SteilCheck.Tests.
// Erwartet wird, was im Lastenheft steht, nicht das, was SteilCheck tut.
public class AlterKombinationenTests
{
    [Theory]
    [InlineData(30, 15.50)]   // D-00: Happy Path, ÄK Erwachsene
    public void Eintritt_nach_Alter_nachmittags(int alter, decimal erwartet)
    {
        Assert.Equal(erwartet, new PreisRechner().Einzelpreis(alter, false, new TimeOnly(15, 0)));
    }

    [Fact]
    public void Kasse_und_Bon_stimmen_ueberein()   // D-00: Happy Path, 2 Erwachsene mit Leihschuhen
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "Gast 1", Alter = 30, Schuhe = true });
        checkIn.Gaeste.Add(new Gast { Name = "Gast 2", Alter = 30, Schuhe = true });
        Assert.Equal(new PreisRechner().Gesamtpreis(checkIn), new BonErsteller().Erstelle(checkIn).Gesamt);
    }
}
