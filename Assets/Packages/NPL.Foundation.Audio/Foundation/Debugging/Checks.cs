// https://github.com/laicasaane/tower_of_encosy/blob/main/Assets/Module.Core/Debugging/Checks.cs

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

#if !DEBUG && !ENABLE_UNITY_COLLECTIONS_CHECKS && !UNITY_DOTS_DEBUG
#define DISABLE_CHECKS
#endif

namespace NPL.Foundation.Audio
{
    using System;

    using Debug = UnityEngine.Debug;

    [System.Diagnostics.DebuggerStepThrough]
    public static partial class Checks
    {
#if DISABLE_CHECKS
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void IsTrue(bool condition)
        {
            Debug.Assert(condition);
        }

#if DISABLE_CHECKS
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void IsTrue(bool condition, string message)
        {
            Debug.Assert(condition, message);
        }

#if DISABLE_CHECKS
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void IndexInRange(int index, int length)
        {
            if ((uint)index >= (uint)length)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range in container of '{length}' Length.");
            }
        }

#if DISABLE_CHECKS
        [System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void OneIndexInRange(int index, int length)
        {
            if (index < 1 || (uint)index >= (uint)length)
            {
                throw new IndexOutOfRangeException($"Index {index} is out of range in container of '{length}' Length.");
            }
        }
    }
}
