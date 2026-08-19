using SteilCheck.Logik;

namespace SteilCheck.Tests;

public class AuslastungTests
{
    [Fact]
    public void Ampel_gruen()
    {
        Assert.Equal("gruen", new Auslastung().Ampel(50));
    }

    [Fact]
    public void Ampel_gelb()
    {
        Assert.Equal("gelb", new Auslastung().Ampel(90));
    }

    [Fact]
    public void Ampel_rot()
    {
        Assert.Equal("rot", new Auslastung().Ampel(110));
    }

    [Fact]
    public void Auslastung_wird_berechnet()
    {
        var auslastung = new Auslastung();
        Thread.Sleep(3000); // warten bis Statistik fertig ist
        Assert.Equal("gelb", auslastung.Ampel(100));
    }
}
