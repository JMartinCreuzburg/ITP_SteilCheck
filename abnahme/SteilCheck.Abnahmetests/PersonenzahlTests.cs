namespace SteilCheck.Abnahmetests;

// Person A: Personenzahl und Gruppenrabatt (Lastenheft F6, F7)
// Übertragt eure Testfälle aus abnahme/testfaelle/personenzahl.md.
// Eine Zeile [InlineData(...)] ist ein Testfall. Muster: die Tests von AppWerk in tests/SteilCheck.Tests.
// Erwartet wird, was im Lastenheft steht, nicht das, was SteilCheck tut.
public class PersonenzahlTests
{
    private static CheckIn Erwachsene(int anzahl)
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        for (int i = 1; i <= anzahl; i++)
            checkIn.Gaeste.Add(new Gast { Name = "Gast " + i, Alter = 30 });
        return checkIn;
    }

    [Theory]
    [InlineData(1, 15.50)]   // A-00: Happy Path
    public void Gesamtpreis_fuer_Erwachsene(int anzahl, decimal erwartet)
    {
        Assert.Equal(erwartet, new PreisRechner().Gesamtpreis(Erwachsene(anzahl)));
    }

    [Theory]
    [InlineData(1, true)]    // A-00: Happy Path
    public void Personenzahl_ist_erlaubt(int anzahl, bool erlaubt)
    {
        Assert.Equal(erlaubt, new CheckInPruefer().IstGueltig(Erwachsene(anzahl)));
    }
}
