# TeePipe
A [`IPipe{I,O}`](./IPipe{I,O}.md)that invokes an action on the output of the pipe each time it's executed.

```cs
public TeePipe<I, O> : IPipe<I, O>
```

## Methods
### Run
```cs
public async Task<O> Run(I input)
```

