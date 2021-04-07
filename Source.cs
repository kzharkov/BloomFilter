using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public int filter;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            filter = 0;
        }

        // хэш-функции
        public int Hash1(string str1)
        {
            // 17
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = str1[i];
                result = result * 17 + code;
            }
            return result % filter_len;
        }
        public int Hash2(string str1)
        {
            // 223
            int result = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                int code = str1[i];
                result = result * 223 + code;
            }
            return result % filter_len;
        }

        public void Add(string str1)
        {
            int hash1 = Hash1(str1);
            int hash2 = Hash2(str1);
            filter |= (1 << hash1);
            filter |= (1 << hash2);
        }

        public bool IsValue(string str1)
        {
            int hash1 = Hash1(str1);
            int hash2 = Hash2(str1);
            if ((filter & (1 << hash1)) != 0 && (filter & (1 << hash2)) != 0)
            {
                return true;
            }
            return false;
        }

        public void Clear()
        {
            filter = 0;
        }
    }
}