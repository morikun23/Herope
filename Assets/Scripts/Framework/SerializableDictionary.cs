using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Serialize {

	/// <summary>
	/// テーブルの管理クラス
	/// </summary>
	[System.Serializable]
	public class DictionaryBase<TKey, TValue, Type> where Type : KeyAndValue<TKey , TValue> {
		[SerializeField]
		private List<Type> list;
		private Dictionary<TKey , TValue> dictionary;

		public Dictionary<TKey , TValue> Dictionary {
			get {
				if (dictionary == null) {
					dictionary = ConvertListToDictionary(list);
				}
				return dictionary;
			}
		}

		/// <summary>
		/// Editor Only
		/// </summary>
		public List<Type> List {
			get { return list; }
		}

		static Dictionary<TKey , TValue> ConvertListToDictionary(List<Type> list) {
			Dictionary<TKey , TValue> dic = new Dictionary<TKey , TValue>();
			foreach (KeyAndValue<TKey , TValue> pair in list) {
				dic.Add(pair.Key , pair.Value);
			}
			return dic;
		}
	}

	/// <summary>
	/// シリアル化できる、KeyValuePair
	/// </summary>
	[System.Serializable]
	public class KeyAndValue<TKey, TValue> {
		public TKey Key;
		public TValue Value;

		public KeyAndValue(TKey key , TValue value) {
			Key = key;
			Value = value;
		}
		public KeyAndValue(KeyValuePair<TKey , TValue> pair) {
			Key = pair.Key;
			Value = pair.Value;
		}


	}
}