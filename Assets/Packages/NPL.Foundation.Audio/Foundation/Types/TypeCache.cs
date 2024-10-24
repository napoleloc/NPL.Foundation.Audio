// https://github.com/laicasaane/tower_of_encosy/blob/main/Assets/Module.Core/Types/TypeCache.cs

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

using System;
using System.Runtime.CompilerServices;

namespace NPL.Foundation.Audio
{
    public static class TypeCache
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type Get<T>()
            => TypeCache<T>.Type;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Is<T>(this Type type)
            => type == TypeCache<T>.Type;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TypeHash GetHash<T>()
            => TypeCache<T>.Hash;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetName<T>()
            => TypeCache<T>.Type.Name;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsUnmanaged<T>()
            => RuntimeHelpers.IsReferenceOrContainsReferences<T>() == false;
    }

    public static class TypeCache<T>
    {
        private readonly static Type s_type;
        private readonly static bool s_isUnmanaged;

        static TypeCache()
        {
            s_type = typeof(T);
            s_isUnmanaged = RuntimeHelpers.IsReferenceOrContainsReferences<T>() == false;
        }

        public static Type Type
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_type;
        }

        public static bool IsUnmanaged
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_isUnmanaged;
        }

        public static bool IsValueType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_type.IsValueType;
        }

        public static TypeHash Hash
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => s_type;
        }
    }
}
