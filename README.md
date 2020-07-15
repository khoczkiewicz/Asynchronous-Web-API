# Asynchronous-Web-API

## Description

An application provides two asynchronous endpoints that shows and saves result of record-addition to database and file parallelly.

File is temporarly stored in `%TEMP%`-path as `items.local` file, eg. `C:\Users\USER\AppData\Local\Temp`.

Simplest _URL_ to insert/provide new record to `Items`-controller are accordingly `firstEndPoint/text` or `secondEndPoint/text`.  

## Used/tested on
* Visual Studio Community 2017
* .NET Core 2.1 (2.1.1)
* StyleCop Analyzers (1.1.118)
* Entity Framework
* Tested only on SSL-certification-coerced-only

## Usage
### Simplest way
* _CTRL+Q_
* _Tools -> NuGet Package Manager -> Package Manager Console_
* `Add-Migration Initial`
* `Update-Database`
* In my case was restart of application needed
### First use
* Run _IIS Express_ application (in some cases _Visual Studio_ runned _As Administrator_ is needed). There should be default browser opened.
* Try to provide `https://localhost:PORT/api/items` to list your empty collection.
* If your result differs from `[]` back to suspicious step.
* Try to provide `https://localhost:PORT/api/items/firstEndPoint/testText`. The result should be displayed in _.json_ valid form.
* If you want to proof an asynchronous addition try to use `https://localhost:PORT/api/items/firstEndPoint/test` and `https://localhost:PORT/api/items/secondEndPoint/test` at the same time in _Visual's_ debbuging mode, with proper step (eg. _async_ `PostItem`-method).