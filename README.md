# libpolyglot [![Build Status](https://travis-ci.org/nbarbettini/libpolyglot.svg)](https://travis-ci.org/nbarbettini/libpolyglot)

This small library will attempt to determine the original source language of a compiled CLI (.NET) assembly.

## Current Status

Work in progress. Currently includes heuristics for compiled C#, VB.NET, and F# code.

## Usage

``` csharp
// Analyze the current assembly.
var assembly = Assembly.GetExecutingAssembly();

// Analyze the calling assembly. Cool!
var assembly = Assembly.GetCallingAssembly();

// Analyze an assembly from disk.
var assembly = Assembly.LoadFrom(path);

// Analyze!
var analyzer = new AssemblyAnalyzer(assembly);

// analyzer.DetectedLanguage is the best guess;
// analyzer.AllResults shows all matching heuristics.
```

## Background

TODO

## Caveat

libpolyglot is bound to have plenty of incorrect results, so don't rely on this for anything mission-critical.
Incorrect results could occur if:

* There isn't enough data to make an educated guess
* Language-specific libraries are reused (`Microsoft.VisualBasic` in a C# project, for instance)
* Internal compiler semantics change
* Someone deliberately wants to fool the analyzer
* You think [merging assemblies](http://www.hanselman.com/blog/MixingLanguagesInASingleAssemblyInVisualStudioSeamlesslyWithILMergeAndMSBuild.aspx) is a fun thing to do
