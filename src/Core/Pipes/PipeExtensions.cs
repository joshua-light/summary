namespace Summary.Pipes;

/// <summary>
///     Extension methods for <see cref="IPipe{I,O}"/>.
/// </summary>
public static class PipeExtensions
{
    /// <summary>
    ///     Asynchronously runs the pipe.
    /// </summary>
    public static Task<O> Run<O>(this IPipe<Unit, O> pipe) =>
        pipe.Run(Unit.Value);

    /// <summary>
    ///     Composes the pipe with another pipe so that the output of the first pipe is passed as an input to the second pipe.
    /// </summary>
    public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, IPipe<O1, O2> b) =>
        new ThenPipe<I, O1, O2>(a, b);

    /// <summary>
    ///     Constructs a new pipe that will apply the specified `select` function to the output of the current pipe.
    /// </summary>
    public static IPipe<I, O2> Then<I, O1, O2>(this IPipe<I, O1> a, Func<O1, O2> map) =>
        a.Then(new FuncPipe<O1, O2>(map));

    /// <summary>
    ///     Constructs a new pipe that will apply the specified map pipe to the each element of the output of the current pipe.
    /// </summary>
    public static IPipe<I, O2[]> ThenForAll<I, O1, O2>(this IPipe<I, O1[]> a, IPipe<O1, O2> b) =>
        new ThenAllPipe<I,O1,O2>(a, b);

    /// <summary>
    ///     Constructs a new pipe that will execute the specified action on the output.
    /// </summary>
    public static IPipe<I, O> Tee<I, O>(this IPipe<I, O> a, Action<O> action) =>
        new TeePipe<I, O>(a, action);
}