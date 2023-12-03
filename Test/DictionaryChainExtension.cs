namespace Test
{
    [TestClass]
    public class DictionaryChainExtension
    {
        struct Entity
        {
            public int FieldInt;
            public bool FieldBool;
            public string FieldString;
        }

        List<Entity>? target;

        [TestInitialize]
        public void Initialize()
        {
            target = new()
            {
                new()
                {
                    FieldInt = 1,
                    FieldBool = false,
                    FieldString = "a"
                },
                new()
                {
                    FieldInt = 1,
                    FieldBool = true,
                    FieldString = "b"
                },
                new()
                {
                    FieldInt = 2,
                    FieldBool = false,
                    FieldString = "b"
                },
                new()
                {
                    FieldInt = 3,
                    FieldBool = false,
                    FieldString = "c"
                },
            };
        }

        [TestMethod]
        public void Create_Level1_Dictionary()
        {
            var result = target.ToDictionaryChain((x) => x.FieldString);

            var list = GetDictList(result, DefaultTransform);
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        ("a", Lst(target![0])),
                        ("b", Lst(target[1], target[2])),
                        ("c", Lst(target[3]))
                    )
                );
        }

        [TestMethod]
        public void Create_Level2_Dictionary()
        {
            var result = target.ToDictionaryChain((x) => x.FieldString, (x) => x.FieldInt);

            var list = GetDictList(result, (k1Dict) => GetDictList(k1Dict, DefaultTransform));
            list.Sort((a, b) => a.Key.CompareTo(b.Key));
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        ("a", KVList((1, Lst(target![0])))),
                        ("b", KVList((1, Lst(target[1])), (2, Lst(target[2])))),
                        ("c", KVList((3, Lst(target[3]))))
                    )
                );
        }

        [TestMethod]
        public void Create_Level3_Dictionary()
        {
            var result = target.ToDictionaryChain(
                (x) => x.FieldString,
                (x) => x.FieldInt,
                (x) => x.FieldBool
            );

            var list = GetDictList(
                result,
                (k0Dict) => GetDictList(k0Dict, (k1Dict) => GetDictList(k1Dict, DefaultTransform))
            );
            list.Sort((a, b) => a.Key.CompareTo(b.Key));
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        ("a", KVList((1, KVList((false, Lst(target![0])))))),
                        (
                            "b",
                            KVList(
                                (1, KVList((true, Lst(target[1])))),
                                (2, KVList((false, Lst(target[2]))))
                            )
                        ),
                        ("c", KVList((3, KVList((false, Lst(target[3]))))))
                    )
                );
        }

        [TestMethod]
        public void Create_Level4_Dictionary()
        {
            var result = target.ToDictionaryChain(
                (x) => x.FieldString,
                (x) => x.FieldInt,
                (x) => x.FieldBool,
                (x) => x.FieldBool
            );

            var list = GetDictList(
                result,
                (k0Dict) =>
                    GetDictList(
                        k0Dict,
                        (k1Dict) =>
                            GetDictList(k1Dict, (k2Dict) => GetDictList(k2Dict, DefaultTransform))
                    )
            );
            list.Sort((a, b) => a.Key.CompareTo(b.Key));
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        ("a", KVList((1, KVList((false, KVList((false, Lst(target![0])))))))),
                        (
                            "b",
                            KVList(
                                (1, KVList((true, KVList((true, Lst(target[1])))))),
                                (2, KVList((false, KVList((false, Lst(target[2]))))))
                            )
                        ),
                        ("c", KVList((3, KVList((false, KVList((false, Lst(target[3]))))))))
                    )
                );
        }

        [TestMethod]
        public void Create_Level5_Dictionary()
        {
            var result = target.ToDictionaryChain(
                (x) => x.FieldString,
                (x) => x.FieldInt,
                (x) => x.FieldBool,
                (x) => x.FieldBool,
                (x) => x.FieldBool
            );

            var list = GetDictList(
                result,
                (k0Dict) =>
                    GetDictList(
                        k0Dict,
                        (k1Dict) =>
                            GetDictList(
                                k1Dict,
                                (k2Dict) =>
                                    GetDictList(
                                        k2Dict,
                                        (k3Dict) => GetDictList(k3Dict, DefaultTransform)
                                    )
                            )
                    )
            );
            list.Sort((a, b) => a.Key.CompareTo(b.Key));
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        (
                            "a",
                            KVList(
                                (
                                    1,
                                    KVList(
                                        (false, KVList((false, KVList((false, Lst(target![0]))))))
                                    )
                                )
                            )
                        ),
                        (
                            "b",
                            KVList(
                                (1, KVList((true, KVList((true, KVList((true, Lst(target[1])))))))),
                                (
                                    2,
                                    KVList(
                                        (false, KVList((false, KVList((false, Lst(target[2]))))))
                                    )
                                )
                            )
                        ),
                        (
                            "c",
                            KVList(
                                (
                                    3,
                                    KVList(
                                        (false, KVList((false, KVList((false, Lst(target[3]))))))
                                    )
                                )
                            )
                        )
                    )
                );
        }

        [TestMethod]
        public void Create_Level6_Dictionary()
        {
            var result = target.ToDictionaryChain(
                (x) => x.FieldString,
                (x) => x.FieldInt,
                (x) => x.FieldBool,
                (x) => x.FieldBool,
                (x) => x.FieldBool,
                (x) => x.FieldBool
            );

            var list = GetDictList(
                result,
                (k0Dict) =>
                    GetDictList(
                        k0Dict,
                        (k1Dict) =>
                            GetDictList(
                                k1Dict,
                                (k2Dict) =>
                                    GetDictList(
                                        k2Dict,
                                        (k3Dict) =>
                                            GetDictList(
                                                k3Dict,
                                                (k3Dict) => GetDictList(k3Dict, DefaultTransform)
                                            )
                                    )
                            )
                    )
            );
            list.Sort((a, b) => a.Key.CompareTo(b.Key));
            list.Should()
                .BeEquivalentTo(
                    KVList(
                        (
                            "a",
                            KVList(
                                (
                                    1,
                                    KVList(
                                        (
                                            false,
                                            KVList(
                                                (
                                                    false,
                                                    KVList(
                                                        (false, KVList((false, Lst(target![0]))))
                                                    )
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        ),
                        (
                            "b",
                            KVList(
                                (
                                    1,
                                    KVList(
                                        (
                                            true,
                                            KVList(
                                                (
                                                    true,
                                                    KVList((true, KVList((true, Lst(target[1])))))
                                                )
                                            )
                                        )
                                    )
                                ),
                                (
                                    2,
                                    KVList(
                                        (
                                            false,
                                            KVList(
                                                (
                                                    false,
                                                    KVList((false, KVList((false, Lst(target[2])))))
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        ),
                        (
                            "c",
                            KVList(
                                (
                                    3,
                                    KVList(
                                        (
                                            false,
                                            KVList(
                                                (
                                                    false,
                                                    KVList((false, KVList((false, Lst(target[3])))))
                                                )
                                            )
                                        )
                                    )
                                )
                            )
                        )
                    )
                );
        }

        private static List<V> Lst<V>(params V[] list) => list.ToList();

        private static List<KeyValuePair<K, V>> KVList<K, V>(params (K, V)[] list)
        {
            var result = new List<KeyValuePair<K, V>>();
            foreach (var (k, v) in list)
            {
                result.Add(new KeyValuePair<K, V>(k, v));
            }
            return result;
        }

        private static object DefaultTransform<V>(V v) => v!;

        private static KeyValuePair<K, R> GetPairList<K, V, R>(
            KeyValuePair<K, V> x,
            Func<V, R> transformValue
        )
        {
            return new(x.Key, transformValue(x.Value));
        }

        private static List<KeyValuePair<K, R>> GetDictList<K, V, R>(
            IDictionary<K, V> dict,
            Func<V, R> transformValue
        )
        {
            return dict.Select((x) => GetPairList(x, transformValue)).ToList();
        }
    }
}
