using System.Runtime.CompilerServices;

namespace NPL.Foundation.Audio.Collections
{
    public static class FasterListExtensionsUnsafe
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetBufferUnsafe<T>(this FasterList<T> list, out T[] buffer, out int count)
        {
            buffer = list._buffer;
            count = list.Count;
        }
    }
}
