# polygot-dotnet [![Build status](https://ci.appveyor.com/api/projects/status/e308mu0mxv009d7h/branch/master?svg=true)](https://ci.appveyor.com/project/nbarbettini/polyglot-dotnet/branch/master)

Polyglot is a small library that will attempt to determine the original source language of a compiled CLI (.NET) assembly.

## Current Status

Polyglot supports these platforms:

* .NET Framework 4.5.1 and higher
* CoreCLR/DNX (or any `dotnet5.1`/`netstandard1.0` platform)

Polyglot includes heuristics for code written in these languages:
* C#
* VB.NET *(only on desktop .NET, currently!)*
* F#

## Caveats caveats caveats

Polyglot **will not** always work, so don't rely on this for anything mission-critical.
Incorrect results could occur if:

* There isn't enough data to make an educated guess!
* Language-specific libraries are reused (`Microsoft.VisualBasic` in a C# project, for instance)
* Internal compiler semantics change (hello, Roslyn)
* Someone deliberately wants to fool the analyzer
* You think [merging assemblies](http://www.hanselman.com/blog/MixingLanguagesInASingleAssemblyInVisualStudioSeamlesslyWithILMergeAndMSBuild.aspx) is a fun thing to do

## Usage

``` csharp
// Analyze the current assembly.
var assembly = this.GetType().GetTypeInfo().Assembly;

// Analyze the calling assembly. Cool!
// (Only works on desktop .NET)
var assembly = Assembly.GetCallingAssembly();

// Analyze an assembly from disk.
var assembly = Assembly.LoadFrom(path);

// Analyze!
var analyzer = new AssemblyAnalyzer(assembly);

// analyzer.DetectedLanguage is the best guess,
// analyzer.AllResults shows all matching heuristics.
```

## Background

This library is based on [a StackOverflow answer](http://stackoverflow.com/questions/33161188/how-to-detect-which-net-language-is-calling-my-code) I wrote that attempted to do the same thing. I was surprised that nothing else existed, so I took some hints from [other](http://stackoverflow.com/questions/15184802/decompiled-dll-clues-to-help-tell-whether-it-was-c-sharp-or-vb-net) [questions](http://stackoverflow.com/q/7310331/3191599) and built a proof-of-concept.

It's solidly in the realm of "trickery that doesn't always work" (see caveats, above). But, works well enough for me to use for some rudimentary diagnostic reporting in the [Stormpath.SDK](https://github.com/stormpath/stormpath-sdk-dotnet) library, which I maintain.
