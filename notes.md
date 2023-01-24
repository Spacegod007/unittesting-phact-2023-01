# Notes

## Frameworks

MSTest - `[TestMethod]`
NUnit  - `[Test]`
xUnit  - `[Fact]` `[Theory]`

Grootste verschil: syntax
Verschillen:

* vroegah:
  - data-driven tests `[InlineData(...)]`
  - .NET Core 1.0 - MSTest werkte hier niet
  - MSTest: `[ExpectedException(...)]`
    - AAA
    - `Assert.Throws<...>(() => controller.Do());`
* nu:
  - testisolatie
  - parallel uitvoeren
  - detail: stringrapportage wanneer strings niet matche `Assert.Equals("hoi", "doei")`
    ```sh
    Expected string "hoi" to equal "doei" // MSTest
    ```
    vs
    ```sh
    Expected strings to match

    Expected: "hoi"
    Actual:   "houdoe"
                 ^
    ```

## End-to-end testtools

* Selenium
* TestCafe (DevExpress)
* WebdriverIO
* Cypress
* Playwright <== Microsoft (2020)

## Test-driven development (TDD)

1. Schrijf een test
2. Run de test en zie dat hij faalt (rood)
3. Schrijf code (implementeer)
4. Run de test en zie dat hij slaagt (groen)
5. Refactor

Repeat.

RED-GREEN-REFACTOR



Blazor-component


## Testdata en patterns

builder

```cs
var customer = CreateCustomer().WithName("Frank").With...(...).Build();
```

object mother
factories

## Naamgevingsconventies

```sh
Method_State_Expectations
Method_Expectations_State
Feature_being_tested_should_do_something_cool
Func_Input_ReturnsError
Given_..._When_..._Then
```

## Mocken van EF Core's `ToListAsync()`

`DbSet<>` en `DbContext<>` mock ik liever niet.

maar:

```cs
var mock = new Mock<DbSet>();
mock.Setup(x => x.ToListAsync()).ReturnsAsync(); // werkt niet

// want:
mock.Object.ToListAsync(); // dit is een extension method
```

Om dat wel te testen:

* Microsoft Fakes (bij Enterprise - Rider)
* TypeMock - $$$

SlaGebruikerOp()

prod: service - repository - database
test: service - mock<repository>












