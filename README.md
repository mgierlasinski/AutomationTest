# Automation Test mobile application in Xamarin.Android

Mobile application for entering and displaying list of packages. Application was written for Android platform in Xamarin.Android. Project follows MVVM architecture pattern guidelines, MvvmCross has been use as a core framework. Business login has been decoupled from Android specific code so it can be easily extended to support iOS as well.

## Application screens

| Splash screen | Menu screen |
|:---:|:---:|
|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/main-1.png)|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/main-2.png)|

| Empty form | Validation error | Save confirmation |
|:---:|:---:|:---:
|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/dimms-1.png)|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/dimms-2.png)|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/dimms-3.png)|

| List with data | Date picker | Empty list |
|:---:|:---:|:---:
|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/list-1.png)|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/list-2.png)|![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/list-3.png)|

## Tools and Frameworks

- **Visual Studio 2019**
- **MvvmCross** - core framework
    - Plugins used: MvvmCross support for RecyclerView, Visibility plugin
- **Realm** - database engine
- **xUnit** - unit tests framework
- **NSubstitute** - mocking framework
- **AutoFixture + xUnit** - automatically fill test data
- **Fluent Assertions** - unit tests assertions

## Project structure

### AutomationTest.Core

Core business logic, decoupled from Android code, designed to be easily unit tested. Contains domain models, services and view models bound to the views. It also contains simple validation utlity, `ValidatedProperty` with basic validation rules. Implementation was inspired by `FluentValidation` library. Core project is not responsible for deciding haw data is stored, it has reference to `AutomationTest.Data` which does that.

### AutomationTest.Data

Implements logic for reading and saving the data. It contains code regarding database operations, this project has reference to `Realm` nuget package. Project contains database entities and repositories responsible for providing the data. There is also `IDatabaseProvider` interface, every implementation should provide `Realm` instance. There are two implementation, one for default database, and second for In-memory version that can be used in unit tests.

### AutomationTest.Droid

Android application code with activities, fragments and views. It contains platform-specific implementaion of `IPopupService` and has reference to `AutomationTest.Core` project.

### AutomationTest.UnitTests

Unit Tests project for `AutomationTest.Core` and `AutomationTest.Data`. Tests are written in xUnit framework, assertions are powered by `FluentAssertions`. There are some extensions written for `FluentAssertions` to make unit test more readable. Mocking of dependencies is done with `NSubstitute`, `AutoFixture` was used to provide test data. For testing repositories, in-memory version of `Realm` was utilized.  Because code base was designed to be easily unit tested, code coverage is over 90%.

Code coverage measured by Visual Studio: 

![Screenshot](https://raw.githubusercontent.com/mgierlasinski/AutomationTest/master/Assets/code-coverage.png)

---
<div>Icons made by <a href="https://www.flaticon.com/authors/freepik" title="Freepik">Freepik</a> from <a href="https://www.flaticon.com/"             title="Flaticon">www.flaticon.com</a></div>