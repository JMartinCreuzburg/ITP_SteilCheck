using SteilCheck.Logik;

namespace SteilCheck.Tests;

public class CheckInPrueferTests
{
    [Fact]
    public void Gueltiger_CheckIn()
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "Max Muster", Alter = 30 });
        Assert.True(new CheckInPruefer().IstGueltig(checkIn));
    }

    [Fact]
    public void CheckIn_ohne_Namen_ist_ungueltig()
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "", Alter = 30 });
        Assert.False(new CheckInPruefer().IstGueltig(checkIn));
    }

    [Fact]
    public void CheckIn_mit_zwei_Gaesten_ist_gueltig()
    {
        var checkIn = new CheckIn { Einlass = new TimeOnly(15, 0) };
        checkIn.Gaeste.Add(new Gast { Name = "Max Muster", Alter = 30 });
        checkIn.Gaeste.Add(new Gast { Name = "Erika Muster", Alter = 28 });
        Assert.True(new CheckInPruefer().IstGueltig(checkIn));
    }
}
