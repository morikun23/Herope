//担当：森田　勝
//概要：ゲーム内で使用するオブジェクトの基底クラス
//　　　まずはTransformのキャッシュをおこなっている。
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public abstract class ObjectBase : MonoBehaviour {
		
		/// <summary>
		/// コンストラクタ
		/// GameObjectの呼び出しではコンストラクタは処理されないので注意！
		/// </summary>
		public ObjectBase() { }

		/// <summary>
		/// コンストラクタ
		/// Transformを所持していないオブジェクトは
		/// 代わりのTransformを設定してください
		/// </summary>
		/// <param name="arg_transform"></param>
		public ObjectBase(Transform arg_transform) { m_transformBuf = arg_transform; }

		//自身のTransform
		private Transform m_transformBuf;

		/// <summary>
		/// 自身のTransformを取得する
		/// 純粋なtransformでの取得をすると毎度GetComponentしているので
		/// こちらを使用してください
		/// </summary>
		public Transform m_transform {
			get {
				if (m_transformBuf == null) {
					m_transformBuf = this.transform;
				}
				return m_transformBuf;
			}
		}

		/// <summary>
		/// 手動でTransformを設定できます
		/// </summary>
		/// <param name="arg_transform"></param>
		public void SetTransform(Transform arg_transform) {
			m_transformBuf = arg_transform;
		}
	}
}