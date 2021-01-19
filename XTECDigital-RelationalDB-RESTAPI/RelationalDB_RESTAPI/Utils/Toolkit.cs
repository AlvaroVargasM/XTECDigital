using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RelationalDB_RESTAPI.Utils
{
    public static class Toolkit
    {
        private static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }

        public static string[] separateByDelimiter(string input, char delimiter)
        {
            string[] tempList = input.Split(delimiter);

            return tempList.SubArray(0, tempList.Length - 1);
        }
    }
}