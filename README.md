# ASP.NET Core PDFSharp

So I really needed PDFSharp for netcoreapp2.0 (or netstandard2.0), but the current release version 1.32.3057 and the prerelease version 1.50.4845-RC2a 
did not support ASP.NET Core, nor would they magically work.

I looked for alternatives (around April 20, 2018), but there was nothing out there. Rolling my own could have been an option, 
but I really wasn't looking forward to that. Why reinvent the wheel. But I needed netcoreapp2.0 support.

Fortunately, it took a mere 20 minutes to fix this. Here are the steps to add PDFSharp to a netcoreapp2.0 project.

It may not be pretty, but it works. If you're just using PDFSharp to render a PDF, this should work for you too.
This is obviously a stop-gap solution, until the fine folks at Empira Software GmbH (the makers of PDFSharp) catch up.

## Step By Step

- Clone this repo
- Open the solution file BuildAll-PdfSharp.sln (you'll need the SDK, etc, but if you need PDFSharp for netcoreapp2.0, you have it already)
- Rebuild all, you probably want a Release build
- In the project where you need PDFSharp (an netcoreapp2.0 project), add the following to you csproj. Make sure to adjust the path and Debug/Release as needed:

```
  <ItemGroup>
    <Reference Include="PdfSharp.netcoreapp">
      <HintPath>..\..\..\..\PDFSharp.netcoreapp\src\PdfSharp\bin\Debug\netcoreapp2.0\PdfSharp.netcoreapp.dll</HintPath>
    </Reference>
  </ItemGroup>
```

- Build your project
- Run it and rejoice 
- Send beer money to me

If it doesn't work, sorry.

** Original Readme Text Below **

# PDFsharp
A .NET library for processing PDF

# Resources

The official project web site:  
http://pdfsharp.net/

The official peer-to-peer support forum:  
http://forum.pdfsharp.net/

# Release Notes for PDFsharp/MigraDoc 1.50 (stable)

The stable version of PDFsharp 1.32 was published in 2013.  
So a new stable version is long overdue.

I really hope the stable version does not have any regressions versus 1.50 beta 3b or later.

And I hope there are no regressions versus version 1.32 stable. But several bugs have been fixed.  
There are a few breaking changes that require code updates.

To use PDFsharp with Medium Trust you have to get the source code and make some changes. The NuGet packages do not support Medium Trust.  
Azure servers do not require Medium Trust.

I'm afraid that many users who never tried any beta version of PDFsharp 1.50 will now switch from version 1.32 stable to version 1.50 stable.  
Nothing wrong about that. I hope we don't get an avalanche of bug reports now.


# Which Version to Get?

The naming convention for the packages has changed.

If you are using "PdfSharp -Version 1.32.3057" then the version you need now is "PDFsharp-gdi -Version 1.50".  
Or get the corresponding package " PDFsharp-MigraDoc-GDI -Version 1.50".

