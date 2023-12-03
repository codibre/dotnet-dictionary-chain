using System;
using System.Collections.Generic;

internal static class DictionaryChainHelpers
{
    public static IDictionary<K1, V> GetNextLevel<K0, K1, V>(
        K0 k,
        IDictionary<K0, IDictionary<K1, V>> dict
    )
    {
        return dict[k] = GetNodeValue(() => new Dictionary<K1, V>(), k, dict);
    }

    public static TValue GetNodeValue<TValue, TKey>(
        Func<TValue> startValue,
        TKey key,
        IDictionary<TKey, TValue> dict
    )
    {
        dict.TryGetValue(key, out TValue keyValue);
        if (keyValue == null)
        {
            keyValue = startValue();
        }

        return keyValue;
    }

    public static IDictionary<TDictK, TDictV> MountDictionary<V, TLeaf, TDictK, TDictV, TLeafKey>(
        IEnumerable<V> list,
        Func<
            IDictionary<TDictK, TDictV>,
            V,
            (TLeafKey, IDictionary<TLeafKey, TLeaf>)
        > getLeafDictionary,
        Func<TLeaf> startValue,
        Func<TLeaf, V, TLeaf> incValue
    )
    {
        var result = new Dictionary<TDictK, TDictV>();
        foreach (var item in list)
        {
            var (key, leafDict) = getLeafDictionary(result, item);
            var keyValue = GetNodeValue(startValue, key, leafDict);
            leafDict[key] = incValue(keyValue, item);
        }
        return result;
    }

    public static List<V> ListStart<V>() => new List<V>();

    public static List<V> ListInc<V>(List<V> list, V item)
    {
        list.Add(item);
        return list;
    }
}
