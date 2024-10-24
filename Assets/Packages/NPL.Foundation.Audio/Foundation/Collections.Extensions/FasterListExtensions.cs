// https://github.com/laicasaane/tower_of_encosy/blob/main/Assets/Module.Core/Collections.Extensions/FasterListExtensions.cs

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

using System.Collections.Generic;

namespace NPL.Foundation.Audio.Collections
{
    public static class FasterListExtensions
    {
        public static void AddRangeTo<T>(this IEnumerable<T> src, ref FasterList<T> list)
        {
            if (src == null)
            {
                return;
            }

            list ??= new();
            list._version++;

            if (src is ICollection<T> c)
            {
                var count = c.Count;

                if (count == 0)
                {
                    return;
                }

                if (list._count + count > list._buffer.Length)
                {
                    list.AllocateMore(list._count + count);
                }

                c.CopyTo(list._buffer, list._count);
                list._count += count;
            }
            else
            {
                foreach (var item in src)
                {
                    list.Add(item);
                }
            }
        }

    }
}
