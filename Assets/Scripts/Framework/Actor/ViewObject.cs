//担当：森田　勝
//概要：ゲーム内のオブジェクトの描画用の基底クラス
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public abstract class ViewObject : ObjectBase {
		
		//１スプライトのデフォルトサイズ
		public const int DEFAULT_SIZE = 60;

		//SpriteRendererのバッファ
		private SpriteRenderer m_spriteRendererBuf;

		//SpriteRendererコンポーネント（スプライト描画用）
		public SpriteRenderer m_spriteRenderer {
			get {
				if(m_spriteRendererBuf == null) {
					m_spriteRendererBuf = GetComponent<SpriteRenderer>();
				}
				return m_spriteRendererBuf;
			}
		}

		//重なり優先度
		public int m_depth;
		
	}
}