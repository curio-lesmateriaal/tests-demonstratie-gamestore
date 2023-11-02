# Demonstratie Geautomatiseerd Testen (C#)

Deze repository is bedoeld om te demonstreren hoe je geautomatiseerde tests kunt schrijven in C#.

> **Note**
> We gebruiken voor deze demonstratie:
> - Een WinUI 3 applicatie
> - MSTest als test framework

## Opstarten

1. Installeer eerst de juiste SDK die nodig is om WinUI 3 projecten te testen:
![image](./Docs/1%20Installeer%20de%20juiste%20SDK.png)
2. Clone deze repository
3. Open de solution in Visual Studio
4. Start you MySQL database
5. Controleer of de connection string in `AppDbContext.cs` klopt met jouw database
6. Build de solution
7. Maak de Test Explorer zichtbaar: `Test` > `Test Explorer`
8. Run alle tests: `Test Explorer` > `Run All Tests In View` (twee groene driehoekjes links bovenin de Test Explorer)

Als het goed is slagen de meeste tests, op 4 na:
![Een overzicht van test resultaten waarbij er 4 niet slagen](./Docs/Eerste%20Test%20Resultaten.png)

## Hoe het Test Project is aangemaakt

1. Installeer eerst de juiste SDK die nodig is om WinUI 3 projecten te testen:
![image](./Docs/1%20Installeer%20de%20juiste%20SDK.png)

2. Maak in de solution van je WinUI 3 project een nieuw project aan van het type `MSTest Project` en kies dezelfde .NET versie als je WinUI 3 project:
![image](./Docs/2%20Maak%20een%20Test%20Project%20met%20de%20NET%206%20versie,%20want%20dat%20is%20compatible%20met%20WinUI3%20(ook%20net%206).png)

3. Pas de eigenschappen van het Test Project aan, zodat deze dezelfde OS Target heeft als je WinUI 3 project:
![image](./Docs/3%20Kies%20voor%20het%20Test%20Project%20dezelfde%20OS%20target%20als%20main%20project.png)

4. Om de tests toegang te geven tot code in je WinUI 3 project, moet je een referentie toevoegen naar het WinUI 3 project:
![image](./Docs/4%20Voeg%20een%20Reference%20aan%20het%20main%20project%20toe%20vanuit%20het%20test%20project.png)

5. Nu kun je tests schrijven:

  - Iedere test klasse moet de `[TestClass]` attribuut hebben. Iedere test methode moet de `[TestMethod]` attribuut hebben. *Zie de `FormatHelperTests` klasse voor voorbeelden.*

  - Tests kunnen opstart en opruimings methodes hebben. Die worden dan vóór en na iedere test uitgevoerd. Voeg aan die methodes dit attribuut toe:
    - `[TestInitialize]` wordt uitgevoerd vóór iedere test
    - `[TestCleanup]` wordt uitgevoerd na iedere test

## Hoe de *Unit test* is geschreven voor de methode `FormatMoney` in de `FormatHelper` klasse

Je kunt de tests nu vinden in `GameStoreTests/FormatHelperTests.cs`. Dit is hoe ze tot stand zijn gekomen:

1. We maken de test-klasse. Geef iedere klasse een eigen test bestand. Een mooie conventie om af te spreken is dat je de test noemt: {NaamVanDeKlasse}Tests.cs. *Bijvoorbeeld: `FormatHelperTests.cs`.*

2. Maak de klasse `public`, zodat de MSTest Test Runner de klasse kan vinden en de tests erin kan uitvoeren.

3. Bedenk en schrijf een eerste simpele test, bijvoorbeeld:
```csharp
[TestClass]
public class FormatHelperTests
{
    [TestMethod]
    public void FormatMoney_Zero()
    {
        decimal price = 0;
        string formatted = FormatHelper.FormatMoney(price);
        Assert.AreEqual("0.00", formatted);
    }
}
```

4. Voer de test uit via de Test Explorer.

De test slaagt. Maar we willen ook testen of de methode werkt voor andere situaties. Dus voegen we meer tests toe.

### Welke soorten waardes willen we testen?

We geven de `FormatHelper.FormatMoney` verschillende waardes als invoer en testen daarbij of het verwachte resultaat uit de methode komt. Probeer altijd de grenzen van de waardes op te zoeken om te testen. Dat zijn bijvoorbeeld waardes die:

- Aan de ondergrens zitten
- Aan de bovengrens zitten
- In het midden zitten
- Net onder de ondergrens zitten
- Net boven de bovengrens zitten
- Naast deze soorten waardes kunnen er meer soorten zijn die je wilt testen. Bekijk de situatie altijd zorgvuldig en bedenk welke waardes je wilt testen.

Bij het testen van geld formaten kun je onder andere de volgende waardes bedenken:

- Waardes die geen decimalen hebben (we verwachten dat er twee decimalen worden toegevoegd, bijvoorbeeld: 1 wordt 1.00)
- Waardes die één decimaal hebben (we verwachten dat er één decimaal wordt toegevoegd, bijvoorbeeld: 1.1 wordt 1.10)
- Waardes die twee decimalen hebben (we verwachten dat er geen decimalen worden toegevoegd, bijvoorbeeld: 1.11 wordt 1.11)
- Waardes die meer dan twee decimalen hebben (we verwachten dat er twee decimalen worden afgerond, bijvoorbeeld: 1.111 wordt 1.11)
- Waardes die negatief zijn (moet ook werken)
- Waardes die nul zijn (moet ook werken)
- Hele kleine waardes zoals de `decimal.MinValue` (het kleinste wat geldig is voor een decimal)
- Hele grote waardes zoals de `decimal.MaxValue`