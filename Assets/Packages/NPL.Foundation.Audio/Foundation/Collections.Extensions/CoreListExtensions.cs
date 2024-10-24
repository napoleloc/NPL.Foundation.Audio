// https://github.com/laicasaane/tower_of_encosy/blob/main/Assets/Module.Core/Collections.Extensions/CoreListExtensions.cs

//MIT License
//
//Copyright (c) 2024 Laicasaane
//
//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:
//
//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.
//
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.

namespace NPL.Foundation.Audio.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;

    public static partial class CoreListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNullOrEmpty<T>(this IList<T> list)
            => list == null || list.Count < 1;

        public static void AddRange<T>(
              [NotNull] this List<T> list
            , ReadOnlyMemory<T> collection
        )
        {
            var span = collection.Span;
            var length = span.Length;

            if (length < 1)
            {
                return;
            }

            list.Capacity = list.Count + length;

            for (var i = 0; i < length; i++)
            {
                list.Add(span[i]);
            }
        }

        public static void AddRangeTo<T>(
              this IEnumerable<T> src
            , ref List<T> dest
        )
        {
            if (src == null)
            {
                return;
            }

            if (dest == null)
            {
                dest = new(src);
            }
            else
            {
                dest.AddRange(src);
            }
        }
    }
}

namespace NPL.Foundation.Audio.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.CompilerServices;
    using Unity.Collections.LowLevel.Unsafe;

    public static partial class CoreListExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Span<T> AsSpanUnsafe<T>([NotNull] this List<T> list)
            => UnsafeUtility.As<List<T>, FasterList<T>>(ref list)._buffer.AsSpan(0, list.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlySpan<T> AsReadOnlySpanUnsafe<T>([NotNull] this List<T> list)
            => UnsafeUtility.As<List<T>, FasterList<T>>(ref list)._buffer.AsSpan(0, list.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Memory<T> AsMemoryUnsafe<T>([NotNull] this List<T> list)
            => UnsafeUtility.As<List<T>, FasterList<T>>(ref list)._buffer.AsMemory(0, list.Count);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ReadOnlyMemory<T> AsReadOnlyMemoryUnsafe<T>([NotNull] this List<T> list)
            => UnsafeUtility.As<List<T>, FasterList<T>>(ref list)._buffer.AsMemory(0, list.Count);
    }
}
