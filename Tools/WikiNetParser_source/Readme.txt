powered by catarsa.com

Wiki .NET Parser

The project 'ProjectBase.Tools' with its reference to the Antlr.Runtime.dll
is the only needed library for the parser to run

Call the:

var result = new ProjectBase.Tools.Wiki.WikiConverter().ConvertToHtml(sourceText);

and your text will be converted to the HTML

That's it