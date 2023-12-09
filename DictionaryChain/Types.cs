using System;
using System.Collections.Generic;

namespace Codibre.DictionaryChain
{
    public class ChainKeyType {
        public readonly object Value;

        internal ChainKeyType(string value) {
            Value = value;
        }
        internal ChainKeyType(long value) {
            Value = value;
        }
        internal ChainKeyType(ulong value) {
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
        public static implicit operator decimal(ChainKeyType value) => value.GetValue<decimal>();
        public static implicit operator bool(ChainKeyType value) => value.GetValue<bool>();
        public static implicit operator ChainKeyType(string value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(long value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(ulong value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(decimal value) => new ChainKeyType(value);
        public static implicit operator ChainKeyType(bool value) => new ChainKeyType(value);
    }

    public class ChainedDictionary<V> : Dictionary<ChainKeyType, ChainKeyValue<V>> {
    }

    public class ChainKeyValue<V> {
        public readonly object Value;

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

        public static implicit operator ChainedDictionary<V>(ChainKeyValue<V> value) => (ChainedDictionary<V>)value.Value;
        public static implicit operator V(ChainKeyValue<V> value) => (V)value.Value;
        public static implicit operator ChainKeyValue<V>(ChainedDictionary<V> value) => new ChainKeyValue<V>(value);
        public static implicit operator ChainKeyValue<V>(V value) => new ChainKeyValue<V>(value);
    }
}