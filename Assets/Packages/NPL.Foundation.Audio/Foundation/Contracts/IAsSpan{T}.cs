using System;

namespace NPL.Foundation.Audio
{
    public interface IAsSpan<T>
    {
        Span<T> AsSpan();
    }

    public interface IAsReadOnlySpan<T>
    {
        ReadOnlySpan<T> AsReadOnlySpan();
    }
}
