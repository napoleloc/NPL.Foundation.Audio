namespace NPL.Foundation.Audio
{
    public delegate void ActionIn<T>(in T arg);

    public delegate void ActionRef<T>(ref T arg);

    public delegate void ActionRef<T1, T2>(ref T1 arg1, ref T2 arg2);

    public delegate TResult FuncIn<T, TResult>(in T arg);

    public delegate TResult FuncRef<T, TResult>(ref T arg);

    public delegate bool PredicateIn<T>(in T arg);

    public delegate bool PredicateRef<T>(ref T arg);
}
