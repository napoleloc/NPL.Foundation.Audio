using System;

namespace NPL.Foundation.Audio
{
    public interface IAsMemory<T>
    {
        Memory<T> AsMemory();
    }

    public interface IAsReadOnlyMemory<T>
    {
        ReadOnlyMemory<T> AsReadOnlyMemory();
    }
}
