# DocComment
An documentation comment parsed from the source code.

```cs
public DocComment 
```

## Fields
### Empty
An empty documentation comment.

```cs
public static readonly DocComment Empty = new(Array.Empty<DocCommentNode>())
```

## Methods
### Element
A nested documentation element that with the specified name (e.g. `summary`, `remarks`, etc.).

```cs
public DocCommentElement? Element(string name)
```

