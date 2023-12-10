using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Codibre.DictionaryChain
{
    public class ChainKeyType {
        public readonly object Value;

        internal ChainKeyType(string value) {
            Value = value;
        }
        internal ChainKeyType(sbyte value) {
            Value = value;
        }
        internal ChainKeyType(byte value) {
            Value = value;
        }
        internal ChainKeyType(short value) {
            Value = value;
        }
        internal ChainKeyType(ushort value) {
            Value = value;
        }
        internal ChainKeyType(int value) {
            Value = value;
        }
        internal ChainKeyType(uint value) {
            Value = value;
        }
        internal ChainKeyType(long value) {
            Value = value;
        }
        internal ChainKeyType(ulong value) {
            Value = value;
        }
        internal ChainKeyType(float value) {
            Value = value;
        }
        internal ChainKeyType(double value) {
            Value = value;
        }
        internal ChainKeyType(decimal value) {
            Value = value;
        }
        internal ChainKeyType(bool value) {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            if (obj is ChainKeyType key) return Equals(key.Value);
            if (obj == null) return Value == null;
            if (Value.GetType() != obj.GetType()) return false;
            return Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        internal T GetValue<T>() {
            if (Value.GetType() == typeof(T)) return (T)Value;
            throw new FormatException();
        }
        
        public static implicit operator string(ChainKeyType value) => value.GetValue<string>();
        public static implicit operator long(ChainKeyType value) => value.GetValue<long>();
        public static implicit operator ulong(ChainKeyType value) => value.GetValue<ulong>();
        public static implicit operator double(ChainKeyType value) => value.GetValue<double>();
        public static implicit operator decimal(ChainKeyType value) => value.GetValue<decimal>();
        public static implicit operator bool(ChainKeyType value) => value.GetValue<bool>();
        public static implicit operator ChainKeyType(string value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(sbyte value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(byte value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(short value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(ushort value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(int value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(uint value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(long value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(ulong value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(float value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(double value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(decimal value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(bool value) => new ChainKeyType(value);
    }

    internal static class TypeRefs {
        internal static readonly Type chainedDictType = typeof(ChainedDictionary<>);
        internal static readonly Type iDictType = typeof(IDictionary<,>);
        internal static readonly Type DictType = typeof(Dictionary<,>);
        internal static readonly Type baseType = typeof(object);
    }

    public class ChainedDictionary<V> : Dictionary<ChainKeyType, ChainKeyValue<V>> {

        public ChainedDictionary() : base() {}
        public ChainedDictionary(Dictionary<ChainKeyType, ChainKeyValue<V>> value) : base(value) {}
        public ChainedDictionary(Dictionary<ChainKeyType, Dictionary<ChainKeyType, object>> value)
            : this(value.Select(x =>
                new KeyValuePair<ChainKeyType, ChainKeyValue<V>>(
                    x.Key,
                    new ChainKeyValue<V>(new ChainedDictionary<V>(x.Value))
                )).ToDictionary(x => x.Key, x => x.Value)
            ) {}
        public ChainedDictionary(Dictionary<ChainKeyType, object> value)
            : this(value.Select(x => {
                ChainKeyValue<V> item;
                if (x.Value is Dictionary<ChainKeyType, object> dict) item = new ChainedDictionary<V>(dict);
                else if (x.Value is V v) item = v;
                else {
                    throw new FormatException("Not convertible");
                }
                return new KeyValuePair<ChainKeyType, ChainKeyValue<V>>(x.Key, item);
            }).ToDictionary(x => x.Key, x => x.Value)
            ) {}

        public TDictionary MakeDictionary<TDictionary>() where TDictionary : IDictionary {
            var type = typeof(TDictionary);
            if (!type.IsClass) throw new FormatException("A concrete type must be used");
            var current = type;
            while ((!current.IsGenericType || current.GetGenericTypeDefinition() != TypeRefs.DictType) && current.BaseType != TypeRefs.baseType) {
                current = current.BaseType;
            }
            if (!current.IsGenericType || current.GetGenericTypeDefinition() != TypeRefs.DictType) {
                throw new FormatException("Informed type must be or inherit Dictionary class");
            }
            var dictArgs = current.GetGenericArguments();
            var arguments = new List<Type>
            {
                type,
                dictArgs[0],
                dictArgs[1]
            };
            var method = GetType().GetMethod(nameof(ToFixedDictionary), BindingFlags.NonPublic | BindingFlags.Instance).MakeGenericMethod(arguments.ToArray());
            return (TDictionary)method.Invoke(this, null);
        }

        private TDictionary ToFixedDictionary<TDictionary, K, T>()
            where TDictionary : Dictionary<K, T>
        {
            var dictType = typeof(T);
            var result = (TDictionary)Activator.CreateInstance(typeof(TDictionary));
            var enumerable = this.Select(x => {
                if (!(x.Key.Value is K key)) throw new FormatException("Not convertible");
                if (x.Value.Value is T value) return new KeyValuePair<K, T>(key, value);
                var valueType = x.Value.Value.GetType();
                if (!valueType.IsGenericType || valueType.GetGenericTypeDefinition() != TypeRefs.chainedDictType) throw new FormatException("Not convertible");
                var expectedValueType = TypeRefs.chainedDictType.MakeGenericType(valueType.GetGenericArguments());
                var arguments = dictType.GetGenericArguments();
                var expectedDictType = TypeRefs.iDictType.MakeGenericType(arguments);
                if (expectedValueType.IsAssignableFrom(valueType) && expectedDictType.IsAssignableFrom(dictType)) {
                    var method = valueType.GetMethod(nameof(ToFixedDictionary), BindingFlags.NonPublic | BindingFlags.Instance);
                    var args = new List<Type>
                    {
                        TypeRefs.DictType.MakeGenericType(arguments),
                        arguments[0],
                        arguments[1]
                    };
                    var generic = method.MakeGenericMethod(args.ToArray());
                    return new KeyValuePair<K, T>(key, (T)generic.Invoke(x.Value.Value, null));
                }
                throw new FormatException("Not convertible");
            });
            foreach (var kv in enumerable) {
                result.Add(kv.Key, kv.Value);
            }
            return result;
        }
    }

    public class ChainKeyValue<V> {
        public object Value { get; internal set; }

        internal ChainKeyValue(ChainedDictionary<V> value) {
            Value = value;
        }
        internal ChainKeyValue(V value) {
            Value = value;
        }
        public override bool Equals(object obj)
        {            
            if (obj == null) return Value == null;
            if (Value.GetType() != obj.GetType()) return false;
            return this.Value.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator ChainedDictionary<V>(ChainKeyValue<V> value)
        {
            if (value.Value is ChainedDictionary<V> chainedDict) return chainedDict;
            if (value.Value is Dictionary<ChainKeyType, ChainKeyValue<V>> kindOfChainedDict) return new ChainedDictionary<V>(kindOfChainedDict);
            if (value.Value is Dictionary<ChainKeyType, object> kindOfChainedDict2) return new ChainedDictionary<V>(kindOfChainedDict2);
            throw new FormatException("Not Convertible");
        }
        public static implicit operator V(ChainKeyValue<V> value) => (V)value.Value;
        public static implicit operator ChainKeyValue<V>(ChainedDictionary<V> value) => new ChainKeyValue<V>(value);
        public static implicit operator ChainKeyValue<V>(V value) => new ChainKeyValue<V>(value);
    }
}