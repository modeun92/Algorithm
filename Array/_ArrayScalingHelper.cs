using System.Runtime.InteropServices;

namespace ModuenKang.Algorithm
{
    /// <summary> MANUAL
    /// ========================================================================================================================================
    /// Introduction
    /// ========================================================================================================================================
    /// Hello This is Moduen Kang.
    /// 
    /// This class in designed to scale the unorganized 2-Layered Jagged Array into the 2D Array or the 2D Jagged Array having the same-sized Arrays.
    /// 
    /// For example, Let's say a 2-Layerd Jagged Array is like below:
    ///int[][] lints = { // 9 Arrays as Element
    ///    new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, // 10 Elements
    ///    new int[] { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 }, // 15 Elements
    ///    new int[] { 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36 }, // 12 Elements
    ///    new int[] { }, // 0 Elements
    ///    null, // null
    ///    new int[] { 37, 38 }, // 2 Elements
    ///    new int[] { 39, 40, 41, 42, 43 }, // 5 Elements
    ///    new int[] { 44, 45, 46, 47, 48, 49, 50 }, // 7 Elements
    ///    new int[] { 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70 }, // 20 Elements
    ///};
    /// It is unorganized and even has a null element.
    /// _ArrayScalingHelper will help you scale the 2-Layered Jagged Array into a well-organized Array as 2D Arrray or other Jagged Array.
    /// ========================================================================================================================================
    /// Terms
    /// ========================================================================================================================================
    /// 2LJaggedArray : 2-Layered Jagged Array
    /// ========================================================================================================================================
    /// How to use
    /// ========================================================================================================================================
    /// The example Jagged Array like you
    ///int width = 11; // Set the width you want to scale with.
    ///var lResult1 = _ArrayScalingHelper._ScaleTo2DArray(lints, width); // See the result of the scaled 2D Array.
    ///int lCnt = 0;
    ///foreach(var el in lResult1)
    ///{
    ///    Console.Write($"{el}\t");
    ///    lCnt++;
    ///    if (width == lCnt)
    ///    {
    ///        lCnt = 0;
    ///        Console.WriteLine();
    ///    }
    ///}
    ///var lResult2 = _ArrayScalingHelper._ScaleTo2LJaggedArray(lints, width); // See the result of the other 2-Layered Jagged Array.
    ///foreach (var arr in lResult2)
    ///{
    ///    foreach (var el in arr)
    ///    {
    ///        Console.Write($"{el}\t");
    ///    }
    ///    Console.WriteLine();
    ///}
    /// The following table shows the before-and-after:
    /// before----------------------------------------------------------------------------------------------------------------------------------
    /// 0   1   2   3   4   5   6   7   8   9
    /// 10  11  12  13  14  15  16  17  18  19  20  21  22  23  24
    /// 25  26  27  28  29  30  31  32  33  34  35  36     
    /// 37  38
    /// 39  40  41  42  43
    /// 44  45  46  47  48  49  50
    /// 51  52  53  54  55  56  57  58  59  60  61  62  63  64  65  66  67  68  69  70
    /// after-----------------------------------------------------------------------------------------------------------------------------------
    /// 0   1   2   3   4   5   6   7   8   9   10
    /// 11  12  13  14  15  16  17  18  19  20  21
    /// 22  23  24  25  26  27  28  29  30  31  32
    /// 33  34  35  36  37  38  39  40  41  42  43
    /// 44  45  46  47  48  49  50  51  52  53  54
    /// 55  56  57  58  59  60  61  62  63  64  65
    /// 66  67  68  69  70  0   0   0   0   0   0
    /// 
    /// Thank You.
    /// </summary>
    public static partial class _ArrayScalingHelper
    {
        #region PUBLIC
        /// <summary>
        /// This returns the scaled 2D Array from your 2-Layered Jagged Array.
        /// </summary>
        /// <typeparam name="T">the type of a2LJaggedArray</typeparam>
        /// <param name="a2LJaggedArray">the 2-Layered Jagged Array you use with the specific type</param>
        /// <param name="aWidth">the scale for respective row's column set</param>
        /// <returns>Scaled 2D Array</returns>
        public static T[,] _ScaleTo2DArray<T>(T[][] a2LJaggedArray, int aWidth)
        {
            T[,] lResult = new T[0, 0];
            int lTypeSize = Marshal.SizeOf(typeof(T));

            _Scale(a2LJaggedArray, aWidth,
                (aHeight)
                    => { lResult = new T[aHeight, aWidth]; },
                (aIncrement, aTempCount, aSrcCoord, aDstCoord)
                    => {
                        Buffer.BlockCopy(
                            a2LJaggedArray[aSrcCoord.Item1],
                            aSrcCoord.Item2 * lTypeSize,
                            lResult,
                            aTempCount * lTypeSize,
                            aIncrement * lTypeSize);
                    }
                );
            return lResult;
        }
        /// <summary>
        /// This returns the scaled 2-Layered Jagged Array from your 2-Layered Jagged Array.
        /// </summary>
        /// <typeparam name="T">the type of a2LJaggedArray</typeparam>
        /// <param name="a2LJaggedArray">the 2-Layered Jagged Array you use with the specific type</param>
        /// <param name="aWidth">the scale for respective row's column set</param>
        /// <returns>This scaled 2-Layered Jagged Array</returns>
        public static T[][] _ScaleTo2LJaggedArray<T>(T[][] a2LJaggedArray, int aWidth)
        {
            T[][] lResult = new T[0][];
            _Scale(a2LJaggedArray, aWidth,
                (lHeight) => { lResult = _Generate2LJaggedArray<T>(lHeight, aWidth); },
                (aIncrement, aTempCount, aSrcCoord, aDstCoord)
                    => {
                        Array.Copy(a2LJaggedArray[aSrcCoord.Item1], aSrcCoord.Item2, lResult[aDstCoord.Item1], aDstCoord.Item2, aIncrement);
                    }
                );
            return lResult;
        }
        #endregion
    }
    public static partial class _ArrayScalingHelper
    {
        #region PRIVATE
        private delegate void Assigning(int aHeight);
        private delegate void DataCopying(
            int aIncrement, int aTempCount,
            (int, int) aSrcCoord, (int, int) aDstCoord);
        private static void _Scale<T>(T[][] a2LJaggedArray, int aWidth, Assigning aAssigning, DataCopying aDataCopying)
        {
            var lCount = _CountElements(a2LJaggedArray);
            int lHeight = _GetHeight(lCount, aWidth);

            aAssigning(lHeight);

            var lTempCount = 0;

            var lSrcCoord = (0, 0);
            var lDstCoord = (0, 0);

            var lSrcWidth = 0;
            try { lSrcWidth = a2LJaggedArray[lSrcCoord.Item1].Length; }
            catch (NullReferenceException) { }

            var lDstWidth = aWidth;

            while (lTempCount < lCount)
            {
                if (lSrcWidth == 0)
                {
                    lSrcCoord.Item2 = 0;

                    try
                    {
                        lSrcCoord.Item1++;
                        lSrcWidth = a2LJaggedArray[lSrcCoord.Item1].Length;
                    }
                    catch (NullReferenceException)
                    { continue; }
                }
                if (lDstWidth == 0)
                {
                    lDstCoord.Item2 = 0;

                    lDstWidth = aWidth;
                    lDstCoord.Item1++;
                }

                var lIncrement = Math.Min(lDstWidth, lSrcWidth);

                if (lIncrement != 0)
                {
                    aDataCopying(lIncrement, lTempCount, lSrcCoord, lDstCoord);

                    lDstWidth -= lIncrement;
                    lSrcWidth -= lIncrement;
                    lTempCount += lIncrement;

                    lSrcCoord.Item2 += lIncrement;
                    lDstCoord.Item2 += lIncrement;
                }
            }
        }
        private static int _CountElements<T>(T[][] a2LJaggedArray)
        {
            int lCount = 0;
            foreach (var l1DArray in a2LJaggedArray)
            { 
                try { lCount += l1DArray.Length; }
                catch (NullReferenceException) { }
            }
            return lCount;
        }
        private static T[][] _Generate2LJaggedArray<T>(int aHeight, int aWidth)
        {
            var lResult = new T[aHeight][];
            for (int i = 0; i < aHeight; i++)
            { lResult[i] = new T[aWidth]; }
            return lResult;
        }
        private static int _GetHeight(int aCount, int aWidth)
            => (int)Math.Ceiling(aCount / (float)aWidth);
        #endregion
    }
}
