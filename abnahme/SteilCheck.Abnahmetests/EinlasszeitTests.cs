namespace SteilCheck.Abnahmetests;

// Person B: Einlasszeit und Abendtarif (Lastenheft F4, F7)
// Übertragt eure Testfälle aus abnahme/testfaelle/einlasszeit.md.
// Eine Zeile [InlineData(...)] ist ein Testfall. Muster: die Tests von AppWerk in tests/SteilCheck.Tests.
// Erwartet wird, was im Lastenheft steht, nicht das, was SteilCheck tut.
public class EinlasszeitTests
{
    [Theory]
    [InlineData(15, 0, 15.50)]   // B-00: Happy Path, Erwachsene:r ohne Ausweis
    public void Eintritt_fuer_Erwachsene_nach_Uhrzeit(int stunde, int minute, decimal erwartet)
    {
        Assert.Equal(erwartet, new PreisRechner().Einzelpreis(30, false, new TimeOnly(stunde, minute)));
    }

    [Theory]
    [InlineData(15, 0, true)]    // B-00: Happy Path
    public void Einlass_ist_erlaubt(int stunde, int minute, bool erlaubt)
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(stunde, minute) };
        checkIn.Gaeste.Add(new Gast { Name = "Gast", Alter = 30 });
        Assert.Equal(erlaubt, new CheckInPruefer().IstGueltig(checkIn));
    }
}
