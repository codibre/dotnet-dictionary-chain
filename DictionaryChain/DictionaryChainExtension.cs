using System;
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
        )
        {
            return DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, List<V>> dict, V v) => (key0(v), dict),
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );
        }

        public static IDictionary<K0, IDictionary<K1, List<V>>> ToDictionaryChain<V, K0, K1>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, IDictionary<K1, List<V>>> dict, V v) =>
                {
                    var (k0, k1) = (key0(v), key1(v));
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    return (k1, leaftDict);
                },
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );

        public static IDictionary<K0, IDictionary<K1, IDictionary<K2, List<V>>>> ToDictionaryChain<
            V,
            K0,
            K1,
            K2
        >(this IEnumerable<V> list, Func<V, K0> key0, Func<V, K1> key1, Func<V, K2> key2) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (IDictionary<K0, IDictionary<K1, IDictionary<K2, List<V>>>> dict, V v) =>
                {
                    var (k0, k1, k2) = (key0(v), key1(v), key2(v));
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    return (k2, leaftDict);
                },
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );

        public static IDictionary<
            K0,
            IDictionary<K1, IDictionary<K2, IDictionary<K3, List<V>>>>
        > ToDictionaryChain<V, K0, K1, K2, K3>(
            this IEnumerable<V> list,
            Func<V, K0> key0,
            Func<V, K1> key1,
            Func<V, K2> key2,
            Func<V, K3> key3
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    IDictionary<
                        K0,
                        IDictionary<K1, IDictionary<K2, IDictionary<K3, List<V>>>>
                    > dict,
                    V v
                ) =>
                {
                    var (k0, k1, k2, k3) = (key0(v), key1(v), key2(v), key3(v));
                    var k0Dict = DictionaryChainHelpers.GetNextLevel(k0, dict);
                    var k1Dict = DictionaryChainHelpers.GetNextLevel(k1, k0Dict);
                    var leaftDict = DictionaryChainHelpers.GetNextLevel(k2, k1Dict);
                    return (k3, leaftDict);
                },
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );

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
        ) =>
            DictionaryChainHelpers.MountDictionary(
                list,
                (
                    IDictionary<
                        K0,
                        IDictionary<K1, IDictionary<K2, IDictionary<K3, IDictionary<K4, List<V>>>>>
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
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );

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
                                IDictionary<K3, IDictionary<K4, IDictionary<K5, List<V>>>>
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
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );

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
                                    IDictionary<K4, IDictionary<K5, IDictionary<K6, List<V>>>>
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
                DictionaryChainHelpers.ListStart<V>,
                DictionaryChainHelpers.ListInc
            );
        
        public static IDictionary<ChainKeyType, ChainKeyValue<V>> ToDictionaryChain<V>(
                this IEnumerable<V> list,
                params Func<V, ChainKeyType>[] keys
            )
        {
            
            var result = new ChainedDictionary<V>();
            foreach (var item in list)
            {
                var nextDict = result;
                var last = keys.Length - 1;
                for (var i = 0; i < last; i++)
                {
                    var k = keys[i](item);
                    nextDict.TryGetValue(k, out ChainKeyValue<V> nextValue);
                    if (nextValue == null)
                    {
                        nextValue = new ChainKeyValue<V>(new ChainedDictionary<V>());
                    }

                    nextDict = nextValue;
                }
                nextDict[keys[last](item)] = item;
            }
            return result;
        }
    }

}
