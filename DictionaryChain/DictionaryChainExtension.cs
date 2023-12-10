using System;
using System.Collections;
using System.Collections.Generic;

namespace Codibre.DictionaryChain
{
    public static class DictionaryChainExtension
    {
        public static dynamic Chain<V>(Func<V, ulong> field, V v)  {
            var dict = new Dictionary<ChainKeyType, V>();
            return dict[field(v)];
        }
        public static IDictionary<K0, List<V>> ToDictionaryChain<V, K0>(
            this IEnumerable<V> list,
            Func<V, K0> key0
        ) => list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0);

        public static IDictionary<K0, IDictionary<K1, List<V>>> ToDictionaryChain<V, K0, K1>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1
        ) =>
            list.ToDictionaryChain(
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc, key0, key1);

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

        public static TDictionary MakeDictionary<TDictionary>(this IEnumerable dict) {
            if (dict is TDictionary tDict) return tDict;
            throw new FormatException("Not convertible");
        }
    }

}
