using SteilCheck.Logik;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace SteilCheck.Tests;

// Reihenfolge festgelegt, sonst schlagen die Tests manchmal fehl
[TestCaseOrderer("SteilCheck.Tests.AlphabetischeReihenfolge", "SteilCheck.Tests")]
public class WarenkorbTests
{
    private static CheckIn warenkorb = new CheckIn { Einlass = new TimeOnly(15, 0) };

    [Fact]
    public void Test1_Gast_hinzufuegen()
    {
        warenkorb.Gaeste.Add(new Gast { Name = "Max Muster", Alter = 30 });
        Assert.Single(warenkorb.Gaeste);
    }

    [Fact]
    public void Test2_Zweiten_Gast_hinzufuegen()
    {
        warenkorb.Gaeste.Add(new Gast { Name = "Erika Muster", Alter = 30 });
        Assert.Equal(2, warenkorb.Gaeste.Count);
    }

    [Fact]
    public void Test3_Warenkorb_Gesamtpreis()
    {
        Assert.Equal(31.00m, new PreisRechner().Gesamtpreis(warenkorb));
    }
}

public class AlphabetischeReihenfolge : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases)
        where TTestCase : ITestCase
    {
        return testCases.OrderBy(t => t.TestMethod.Method.Name);
    }
}
