using System;
using System.Collections;
using System.Collections.Generic;

namespace Codibre.DictionaryChain
{
    public static class DictionaryChainExtension
    {   
        /// <summary>
        /// Generate a chain of Dictionaries with depth of 1.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<K0, List<V>> ToDictionaryChain<V, K0>(
            this IEnumerable<V> list,
            Func<V, K0> key0
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0);

        /// <summary>
        /// Generate a chain of Dictionaries with depth of 2.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<K0, IDictionary<K1, List<V>>> ToDictionaryChain<V, K0, K1>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1
        ) =>
            list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1);

        /// <summary>
        /// Generate a chain of Dictionaries with depth of 3.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <param name="key2">A function to return the value of the third key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<K0, IDictionary<K1, IDictionary<K2, List<V>>>> ToDictionaryChain<
            V,
            K0,
            K1,
            K2
        >(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2
        ) =>
            list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1, key2);

        /// <summary>
        /// Generate a chain of Dictionaries with depth of 4.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <param name="key2">A function to return the value of the third key</param>
        /// <param name="key3">A function to return the value of the fourth key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<
            K0,
            IDictionary<K1, IDictionary<K2, IDictionary<K3, List<V>>>>
        > ToDictionaryChain<V, K0, K1, K2, K3>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1, key2, key3);

        /// <summary>
        /// Generate a chain of Dictionaries with depth of 5.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <param name="key2">A function to return the value of the third key</param>
        /// <param name="key3">A function to return the value of the fourth key</param>
        /// <param name="key4">A function to return the value of the fifth key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<
            K0,
            IDictionary<K1, IDictionary<K2, IDictionary<K3, IDictionary<K4, List<V>>>>>
        > ToDictionaryChain<V, K0, K1, K2, K3, K4>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1, key2, key3, key4);

        /// <summary>
        /// Generate a chain of Dictionaries with depth of 6.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <param name="key2">A function to return the value of the third key</param>
        /// <param name="key3">A function to return the value of the fourth key</param>
        /// <param name="key4">A function to return the value of the fifth key</param>
        /// <param name="key5">A function to return the value of the sixth key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<
            K0,
            IDictionary<
                K1,
                IDictionary<K2, IDictionary<K3, IDictionary<K4, IDictionary<K5, List<V>>>>>
            >
        > ToDictionaryChain<V, K0, K1, K2, K3, K4, K5>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4,
            Func<V, K5> key5
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1, key2, key3, key4, key5);


        /// <summary>
        /// Generate a chain of Dictionaries with depth of 7.
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key</param>
        /// <param name="key1">A function to return the value of the second key</param>
        /// <param name="key2">A function to return the value of the third key</param>
        /// <param name="key3">A function to return the value of the fourth key</param>
        /// <param name="key4">A function to return the value of the fifth key</param>
        /// <param name="key5">A function to return the value of the sixth key</param>
        /// <param name="key6">A function to return the value of the seventh key</param>
        /// <returns>The Chain of Dictionaries with the inferred key types</returns>
        public static IDictionary<
            K0,
            IDictionary<
                K1,
                IDictionary<
                    K2,
                    IDictionary<K3, IDictionary<K4, IDictionary<K5, IDictionary<K6, List<V>>>>>
                >
            >
        > ToDictionaryChain<V, K0, K1, K2, K3, K4, K5, K6>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4,
            Func<V, K5> key5,
            Func<V, K6> key6
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1, key2, key3, key4, key5, key6);

        /// <summary>
        /// Generate a Generic instance of ChainedDictionary.
        /// To be easily used, is important to call MakeDictionary
        /// to convert it to a Custom Chain of Dictionaries
        /// The leaf will be a List of every item that matches the path
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key4">A function to return the value of the fifth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key5">A function to return the value of the sixth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key6">A function to return the value of the seventh key. It must return a number, a boolean value, or a string</param>
        /// <param name="keys">A list of functions to return the value of the rest of the key. Each one must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static ChainedDictionary<List<V>> ToDictionaryChain<V>(
                this IEnumerable<V> list,
                Func<V, ChainKeyType> key0,
                Func<V, ChainKeyType> key1,
                Func<V, ChainKeyType> key2,
                Func<V, ChainKeyType> key3,
                Func<V, ChainKeyType> key4,
                Func<V, ChainKeyType> key5,
                Func<V, ChainKeyType> key6,
                params Func<V, ChainKeyType>[] keys
            ) => list.ToDictionaryChain(() => new List<V>(), (leaf, item) =>
            {
                leaf.Add(item);
                return leaf;
            }, key0, key1, key2, key3, key4, key5, key6, keys);

        /// <summary>
        /// Converts a ChainedDictionary in the specified Chain Of Dictionaries.
        /// this methods fails if the instance provided is not compatible with
        /// the ChainedDictionary keys and values
        /// </summary>
        /// <typeparam name="TDictionary">The Target type to be obtained</typeparam>
        /// <exception cref="FormatException"></exception>
        public static TDictionary MakeDictionary<TDictionary>(this IEnumerable dict) {
            if (dict is TDictionary tDict) return tDict;
            throw new FormatException("Not convertible");
        }
    }

}
