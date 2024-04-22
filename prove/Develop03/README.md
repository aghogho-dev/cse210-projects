# Title: Bible Memorizer

## Description
Memorize Bible verses with this application. All you have to do is input a verse. 

    * BibleAPI.cs: Fetches this scripture from https://bible-api.com/. 
    *  References.cs: Keeps track of both the reference and the text of the scripture. Can hide words and get the rendered display of the text.
    * Reference.cs: Keeps track of the book, chapter, and verse information.
    * Word.cs: Keeps track of a single word and whether it is shown or hidden.

## Packages
Run `dotnet add package Newtonsoft.Json` to use this package in the BibleAPI.cs.

# Demonstration
A video demonstration of how this project works: https://www.loom.com/share/1bba5796adf94f5b9affdba929aa1c6f?sid=f589a759-3409-4d32-a790-949502c7832f


## Project Structure
Develop03
|   
|   
|
+---Assets
|       BibleAPI.cs
|       Reference.cs
|       Scripture.cs
|       Word.cs
|
+---Program.cs

