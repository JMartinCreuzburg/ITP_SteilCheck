using SteilCheck.Logik;

namespace SteilCheck.Tests;

public class PreisRechnerTests
{
    private readonly PreisRechner rechner = new PreisRechner();
    private readonly TimeOnly nachmittag = new TimeOnly(15, 0);

    [Fact]
    public void Kind_kostet_9_Euro()
    {
        Assert.Equal(9.00m, rechner.Grundpreis(10));
    }

    [Fact]
    public void Jugendlicher_kostet_12_Euro()
    {
        Assert.Equal(12.00m, rechner.Grundpreis(16));
    }

    [Fact]
    public void Erwachsener_kostet_15_50_Euro()
    {
        Assert.Equal(15.50m, rechner.Grundpreis(30));
    }

    [Fact]
    public void Senior_kostet_12_Euro()
    {
        Assert.Equal(12.00m, rechner.Grundpreis(70));
    }

    [Fact]
    public void Kleinkind_ist_kostenlos()
    {
        Assert.Equal(0m, rechner.Grundpreis(3));
    }

    [Theory]
    [InlineData(10, 9.00)]
    [InlineData(16, 12.00)]
    [InlineData(30, 15.50)]
    [InlineData(70, 12.00)]
    public void Grundpreise(int alter, decimal preis)
    {
        Assert.Equal(preis, rechner.Grundpreis(alter));
    }

    [Fact]
    public void Einzelpreis_Kind_nachmittags()
    {
        Assert.Equal(9.00m, rechner.Einzelpreis(10, false, nachmittag));
    }

    [Fact]
    public void Einzelpreis_Erwachsener_nachmittags()
    {
        Assert.Equal(15.50m, rechner.Einzelpreis(30, false, nachmittag));
    }

    [Fact]
    public void Einzelpreis_Jugendlicher_mit_Ausweis()
    {
        Assert.Equal(10.20m, rechner.Einzelpreis(16, true, nachmittag));
    }

    [Fact]
    public void Einzelpreis_Erwachsener_mit_Ausweis()
    {
        Assert.Equal(13.18m, rechner.Einzelpreis(30, true, nachmittag));
    }

    [Fact]
    public void Ermaessigung_wird_abgezogen()
    {
        Assert.True(rechner.Einzelpreis(30, true, nachmittag) < rechner.Einzelpreis(30, false, nachmittag));
    }

    [Fact]
    public void Einzelpreis_Senior_nachmittags()
    {
        Assert.Equal(12.00m, rechner.Einzelpreis(70, false, nachmittag));
    }

    [Fact]
    public void Einzelpreis_Kleinkind()
    {
        Assert.Equal(0m, rechner.Einzelpreis(3, false, nachmittag));
    }

    [Fact]
    public void Abendtarif_wird_angewendet()
    {
        var preis = rechner.Einzelpreis(10, false, TimeOnly.FromDateTime(DateTime.Now));
        Assert.Equal(6.75m, preis);
    }

    [Theory]
    [InlineData(10, 9.00)]
    [InlineData(16, 12.00)]
    [InlineData(30, 15.50)]
    [InlineData(70, 12.00)]
    [InlineData(3, 0.00)]
    public void Einzelpreise_tagsueber(int alter, decimal preis)
    {
        Assert.Equal(preis, rechner.Einzelpreis(alter, false, new TimeOnly(11, 0)));
    }

    [Fact]
    public void Gesamtpreis_eine_Person()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        checkIn.Gaeste.Add(new Gast { Name = "Test", Alter = 30 });
        Assert.Equal(15.50m, rechner.Gesamtpreis(checkIn));
    }

    [Fact]
    public void Gesamtpreis_zwei_Personen()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        checkIn.Gaeste.Add(new Gast { Name = "Test1", Alter = 30 });
        checkIn.Gaeste.Add(new Gast { Name = "Test2", Alter = 30 });
        Assert.Equal(31.00m, rechner.Gesamtpreis(checkIn));
    }

    [Fact]
    public void Gesamtpreis_mit_Leihschuhen()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        checkIn.Gaeste.Add(new Gast { Name = "Test", Alter = 30, Schuhe = true });
        Assert.Equal(19.00m, rechner.Gesamtpreis(checkIn));
    }

    [Fact]
    public void Gesamtpreis_Familie()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        checkIn.Gaeste.Add(new Gast { Name = "Mama", Alter = 40 });
        checkIn.Gaeste.Add(new Gast { Name = "Papa", Alter = 38 });
        checkIn.Gaeste.Add(new Gast { Name = "Kind1", Alter = 8 });
        checkIn.Gaeste.Add(new Gast { Name = "Kind2", Alter = 10 });
        Assert.Equal(49.00m, rechner.Gesamtpreis(checkIn));
    }

    [Fact]
    public void Gruppenrabatt_bei_8_Personen()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        for (int i = 0; i < 8; i++)
            checkIn.Gaeste.Add(new Gast { Name = "Gast" + i, Alter = 30 });
        Assert.Equal(111.60m, rechner.Gesamtpreis(checkIn));
    }

    [Fact]
    public void Kein_Gruppenrabatt_bei_2_Personen()
    {
        var checkIn = new CheckIn { Einlass = nachmittag };
        checkIn.Gaeste.Add(new Gast { Name = "Test1", Alter = 30 });
        checkIn.Gaeste.Add(new Gast { Name = "Test2", Alter = 30 });
        Assert.Equal(31.00m, rechner.Gesamtpreis(checkIn));
    }
}
