# SyntaxTreeParserPipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that parses the specified string into a [`SyntaxTree`](./SyntaxTree.md).

```cs
public SyntaxTreeParserPipe : IPipe<string, SyntaxTree>
```

## Methods
### Run
```cs
public Task<SyntaxTree> Run(string input)
```

