namespace SteilCheck.Abnahmetests;

// Person C: Ausweis und Begleitung von Kleinkindern (Lastenheft F2, F3)
// Übertragt eure Testfälle aus abnahme/testfaelle/ausweis-begleitung.md.
// Eine Zeile [InlineData(...)] ist ein Testfall. Muster: die Tests von AppWerk in tests/SteilCheck.Tests.
// Erwartet wird, was im Lastenheft steht, nicht das, was SteilCheck tut.
public class AusweisBegleitungTests
{
    [Theory]
    [InlineData(30, 13.18)]   // C-00: Happy Path, Erwachsene:r mit Ausweis
    public void Eintritt_mit_Ausweis_nachmittags(int alter, decimal erwartet)
    {
        Assert.Equal(erwartet, new PreisRechner().Einzelpreis(alter, true, new TimeOnly(15, 0)));
    }

    [Theory]
    [InlineData(30, true)]    // C-00: Happy Path, Kleinkind (4 J.) mit erwachsener Begleitung
    public void Kleinkind_mit_Begleitung_ist_erlaubt(int alterBegleitung, bool erlaubt)
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "Kind", Alter = 4 });
        checkIn.Gaeste.Add(new Gast { Name = "Begleitung", Alter = alterBegleitung });
        Assert.Equal(erlaubt, new CheckInPruefer().IstGueltig(checkIn));
    }
}
