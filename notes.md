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

# End-to-end testtools

* Selenium
* TestCafe (DevExpress)
* WebdriverIO
* Cypress
* Playwright <== Microsoft (2020)


