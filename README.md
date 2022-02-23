# BASTA! Spring 2022 in Frankfurt

## Keynote - C# 10

[Keynote samples](Keynote)

Samples:

* BooksAPIv5 - ASP.NET Core Web API with EF Core using .NET 5
* BooksAPIv6MinimalAPI - Minimal API with EF Core using .NET 6
* BooksAPIv6MinimalAPIwithInstantAPI - using InstantAPIs

[More information about InstantAPIs](http://github.com/csharpfritz/InstantAPIs/)

## C# 10 - What's new and what's next?

C# 10 bietet viele Erleichterungen – dazu gehören Global Usings und Implicit Usings als auch File-scoped Namespaces. Erweiterungen gibt es auch beim Pattern Matching und dem Record Type. In dieser Session sehen Sie Features von C# 10 und erhalten Informationen, was in der nächsten Version von C# geplant ist und mit C# 11 kommen kann.

[Slides C# 10](slides/CSharp10andnext.pdf)

[C# 10 and 11 Samples](csharp10andnext)

Samples:

* Migrating an ASP.NET Core Web API from .NET 5 to .NET 6 with:
    * BooksAPIv5 (ASP.NET Core 5 version)
    * BooksAPIv6
        * file-scoped namespace declarations
        * global using directives
        * implicit using
    * BooksAPIMinimalAPI
        * natural types with lambda expressions
    * Natural Delegates
* Records and Structs (StructSample)
    * with expressions
    * parameterless constructors and field initializers
    * record struct
    * readonly record struct
* Pattern matching (PatternMatching)
    * Declaration pattern (7.0)
    * Const pattern (7.0)
    * Var pattern (7.0)
    * Property pattern (8.0)
    * Positional pattern (8.0)
    * Discard pattern (8.0)
    * Logical pattern (8.0)
    * Relational (8.0)
    * Declaration and type pattern (9.0)
    * Extended property pattern (10.0)
    * List and slice pattern (11.0)
* Static abstract members (StaticAbstractMembers) - preview with C# 10 and .NET 6
    * IGetNext generic interface with custom ++ operator
    * IAdditionOperators - implementing and using with .NET 6 preview features and `System.Runtime.Experimental`
* Null checks (CheckForNull)
    * Traditional
    * .NET 6
    * C# 11
* Raw string literals (RawStringLiterals) - C# 11

## Async Streaming

Mit den C#-async-Erweiterungen zu den yield- und foreach-Statements ist es einfacher geworden, asynchron Daten zu streamen. In dieser Session sehen Sie die Grundlagen zu async-Streaming, und auch, wie async-Streams mit EF Core, SignalR, ASP.NET Core 6, gRPC und mit Azure Services genutzt werden können.

[Slides Async Streaming](slides/AsyncStreams2022.pdf)

[Async Streams Samples](asyncstreams)

Samples:

* Enumerable
    * Retrieving all files vs enumerable
    * `yield` statement
    * what's behind `foreach`
* AsyncEnumerable
    * IAsyncEnumerable
    * IAsyncEnumerator
    * IAsyncDispose
    * await foreach
    * Cancellation token
* Asynchronous Streaming with SignalR (SignalR)
    * System.Threading.Channels
    * Asynchronous streaming
* Asynchronous Streaming with gRPC
    * Sensor data 
* EF Core
    * AsAsyncEnumerable    
* Web API
* Azure Storage
