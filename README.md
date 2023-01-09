<div align="center">
    <img src="./res/icon-512.png" alt="Logo" width="128" height="128"></img>
</div>
<h1 align="center">&lt;summary&gt;</h1>

<p align="center">
    <i>Flexible and effortless API reference generator for .NET.</i>
</p>

## Usage

Currently, the generator is pretty young. In order to use it, you should download `Summary` (Core), `Summary.Roslyn` (Parser) and `Summary.Markdown` (Renderer) packages.

Here is a simple code-snippet that parses files in the specified directory:
```cs
// The folder you want to parse the `*.cs` files from.
const string input = "./src";

// The folder you want to put the generator output into.
const string output = "./docs";

await
    // Scan all `*.cs` files in the specified `input` path.
    new ScanDirectoryPipe(input, pattern: "*.cs")

    // Parse each file into Roslyn `SyntaxTree`.
    .ThenForEach(new ParseSyntaxTreePipe())

    // Parse each `SyntaxTree` into `Doc`.
    .ThenForEach(new ParseDocumentPipe())

    // Merge multiple docs into single doc.
    .Then(new FlattenPipe<Doc>(Doc.Merge))

    // Remove non-public types and members.
    .Then(new FilterPublicMembersPipe())

    // Render the `Doc` into series of Markdown files (one file for each type).
    .Then(new RenderMarkdownPipe())

    // Save each Markdown file into separate file.
    .ThenForEach(new SavePipe<Markdown>(output, x => (x.Name, x.Content)))

    // Execute the pipeline.
    .Run();
```
