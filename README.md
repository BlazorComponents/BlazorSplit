## BlazorSplit

```
Note: Just as Blazor, this repo is also experimental.
```

If you like the idea of this repo leave your feedback as an issue or star the repo or let me know on [@samprof](https://twitter.com/samprof)

Currently, starting with a simple [Split.Js](https://split.js.org/) implementation. 

## Demo and Documentation
https://blazorcomponents.github.io/BlazorSplit/


## Prerequisites

Don't know what Blazor is? Read [here](https://github.com/aspnet/Blazor)

Complete all Blazor dependencies.

1. Visual Studio 2017 (15.8 or later)
2. DotNetCore 2.1 (2.1.402 or later).


## Installation 

![NuGet](https://img.shields.io/nuget/v/BlazorSplit.svg)


To Install 

```
Install-Package BlazorSplit
```
or 
```
dotnet add package BlazorSplit
```

## Usage

1. In cshtml file add this:

```<Split>
        <SplitArea>
            Test1
        </SplitArea>
        <SplitArea>
            Test2
        </SplitArea>
    </Split>
```