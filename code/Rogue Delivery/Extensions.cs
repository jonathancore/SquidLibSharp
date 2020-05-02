﻿using System.Collections.Generic;

namespace RogueDelivery {
    public static class KeyValuePairExtansions {
        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> kvp, out TKey key, out TValue value) {
            key = kvp.Key;
            value = kvp.Value;
        }
    }
}
