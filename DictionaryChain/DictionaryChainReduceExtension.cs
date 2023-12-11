using System;
using System.Collections.Generic;

namespace Codibre.DictionaryChain
{
    public static class DictionaryChainReduceExtension
    {
        /// <summary>
        /// Generate a chain of Dictionaries of depth 1.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<K0, TLeaf> ToDictionaryChain<V, TLeaf, K0>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, TLeaf> dict, V v) => (key0(v), dict),
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 2.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<K0, IDictionary<K1, TLeaf>> ToDictionaryChain<V, TLeaf, K0, K1>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, IDictionary<K1, TLeaf>> dict, V v) =>
                {
                    var (k0, k1) = (key0(v), key1(v));
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    return (k1, leaftDict);
                },
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 3.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<K0, IDictionary<K1, IDictionary<K2, TLeaf>>> ToDictionaryChain<
            V,
            TLeaf,
            K0,
            K1,
            K2
        >(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, IDictionary<K1, IDictionary<K2, TLeaf>>> dict, V v) =>
                {
                    var (k0, k1, k2) = (key0(v), key1(v), key2(v));
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    return (k2, leaftDict);
                },
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 4.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<
            K0,
            IDictionary<K1, IDictionary<K2, IDictionary<K3, TLeaf>>>
        > ToDictionaryChain<V, TLeaf, K0, K1, K2, K3>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    IDictionary<K0, IDictionary<K1, IDictionary<K2, IDictionary<K3, TLeaf>>>> dict,
                    V v
                ) =>
                {
                    var (k0, k1, k2, k3) = (key0(v), key1(v), key2(v), key3(v));
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var k1Dict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k2, k1Dict);
                    return (k3, leaftDict);
                },
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 5.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key4">A function to return the value of the fifth key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<
            K0,
            IDictionary<K1, IDictionary<K2, IDictionary<K3, IDictionary<K4, TLeaf>>>>
        > ToDictionaryChain<V, TLeaf, K0, K1, K2, K3, K4>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    IDictionary<
                        K0,
                        IDictionary<K1, IDictionary<K2, IDictionary<K3, IDictionary<K4, TLeaf>>>>
                    > dict,
                    V v
                ) =>
                {
                    var (k0, k1, k2, k3, k4) = (key0(v), key1(v), key2(v), key3(v), key4(v));
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var k1Dict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    var k2Dict = DictionaryChainHelpers.GetNextLevel(k2, k1Dict);
                    var k3Dict = DictionaryChainHelpers.GetNextLevel(k3, k2Dict);
                    return (k4, k3Dict);
                },
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 6.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key4">A function to return the value of the fifth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key5">A function to return the value of the sixth key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<
            K0,
            IDictionary<
                K1,
                IDictionary<K2, IDictionary<K3, IDictionary<K4, IDictionary<K5, TLeaf>>>>
            >
        > ToDictionaryChain<V, TLeaf, K0, K1, K2, K3, K4, K5>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4,
            Func<V, K5> key5
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    IDictionary<
                        K0,
                        IDictionary<
                            K1,
                            IDictionary<
                                K2,
                                IDictionary<K3, IDictionary<K4, IDictionary<K5, TLeaf>>>
                            >
                        >
                    > dict,
                    V v
                ) =>
                {
                    var (k0, k1, k2, k3, k4, k5) = (
                        key0(v),
                        key1(v),
                        key2(v),
                        key3(v),
                        key4(v),
                        key5(v)
                    );
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var k1Dict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    var k2Dict = DictionaryChainHelpers.GetNextLevel(k2, k1Dict);
                    var k3Dict = DictionaryChainHelpers.GetNextLevel(k3, k2Dict);
                    var k4Dict = DictionaryChainHelpers.GetNextLevel(k4, k3Dict);
                    return (k5, k4Dict);
                },
                startValue,
                incValue
            );

        /// <summary>
        /// Generate a chain of Dictionaries of depth 7.
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key4">A function to return the value of the fifth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key5">A function to return the value of the sixth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key6">A function to return the value of the seventh key. It must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static IDictionary<
            K0,
            IDictionary<
                K1,
                IDictionary<
                    K2,
                    IDictionary<K3, IDictionary<K4, IDictionary<K5, IDictionary<K6, TLeaf>>>>
                >
            >
        > ToDictionaryChain<V, TLeaf, K0, K1, K2, K3, K4, K5, K6>(
            this IEnumerable<V> list,
            Func<TLeaf> startValue,
            Func<TLeaf, V, TLeaf> incValue,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3,
            Func<V, K4> key4,
            Func<V, K5> key5,
            Func<V, K6> key6
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    // TODO: Refactor this and all chained Dictionary types after the release of generic type parameter alias https://github.com/dotnet/csharplang/issues/1239
                    IDictionary<
                        K0,
                        IDictionary<
                            K1,
                            IDictionary<
                                K2,
                                IDictionary<
                                    K3,
                                    IDictionary<K4, IDictionary<K5, IDictionary<K6, TLeaf>>>
                                >
                            >
                        >
                    > dict,
                    V v
                ) =>
                {
                    var (k0, k1, k2, k3, k4, k5, k6) = (
                        key0(v),
                        key1(v),
                        key2(v),
                        key3(v),
                        key4(v),
                        key5(v),
                        key6(v)
                    );
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var k1Dict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    var k2Dict = DictionaryChainHelpers.GetNextLevel(k2, k1Dict);
                    var k3Dict = DictionaryChainHelpers.GetNextLevel(k3, k2Dict);
                    var k4Dict = DictionaryChainHelpers.GetNextLevel(k4, k3Dict);
                    var k5Dict = DictionaryChainHelpers.GetNextLevel(k5, k4Dict);
                    return (k6, k5Dict);
                },
                startValue,
                incValue
            );
        
        /// <summary>
        /// Generate a Generic instance of ChainedDictionary.
        /// To be easily used, is important to call MakeDictionary
        /// to convert it to a Custom Chain of Dictionaries
        /// The leaf will have the type defined by the startValue function
        /// </summary>
        /// <typeparam name="V">The item type of the enumerable to be traversed</typeparam>
        /// <param name="list">The enumerable to be traversed</param>
        /// <param name="startValue">A function to initialize the leaf value</param>
        /// <param name="incValue">A function to increment each leaf value</param>
        /// <param name="key0">A function to return the value of the first key. It must return a number, a boolean value, or a string</param>
        /// <param name="key1">A function to return the value of the second key. It must return a number, a boolean value, or a string</param>
        /// <param name="key2">A function to return the value of the third key. It must return a number, a boolean value, or a string</param>
        /// <param name="key3">A function to return the value of the fourth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key4">A function to return the value of the fifth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key5">A function to return the value of the sixth key. It must return a number, a boolean value, or a string</param>
        /// <param name="key6">A function to return the value of the seventh key. It must return a number, a boolean value, or a string</param>
        /// <param name="keys">A list of functions to return the value of the rest of the key. Each one must return a number, a boolean value, or a string</param>
        /// <returns>The Chained Dictionary instance</returns>
        public static ChainedDictionary<TLeaf> ToDictionaryChain<V, TLeaf>(
                this IEnumerable<V> list,
                Func<TLeaf> startValue,
                Func<TLeaf, V, TLeaf> incValue,
                Func<V, ChainKeyType> key0,
                Func<V, ChainKeyType> key1,
                Func<V, ChainKeyType> key2,
                Func<V, ChainKeyType> key3,
                Func<V, ChainKeyType> key4,
                Func<V, ChainKeyType> key5,
                Func<V, ChainKeyType> key6,
                params Func<V, ChainKeyType>[] keys
            )
        {
            var allKeys = new List<Func<V, ChainKeyType>> {
                key0, key1, key2, key3, key4, key5, key6,
            };
            foreach (var key in keys) {
                allKeys.Add(key);
            }
            var result = new ChainedDictionary<TLeaf>();
            foreach (var item in list)
            {
                var nextDict = result;
                var last = allKeys.Count - 1;
                for (var i = 0; i < last; i++)
                {
                    var k = allKeys[i](item);
                    nextDict.TryGetValue(k, out var nextValue);
                    if (nextValue == null)
                    {
                        nextValue = new ChainKeyValue<TLeaf>(new ChainedDictionary<TLeaf>());
                        nextDict[k] = nextValue;
                    }

                    nextDict = nextValue;
                }
                if (!nextDict.TryGetValue(allKeys[last](item), out var itemList)) {
                    nextDict[allKeys[last](item)] = itemList = startValue();
                } 
                
                itemList.Value = incValue((TLeaf)itemList.Value, item);
            }
            return result;
        }
    }
}
