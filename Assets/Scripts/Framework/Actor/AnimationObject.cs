//担当：森田　勝
//概要：ゲーム内のアニメーションを扱うクラスの基底クラス
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public abstract class AnimationObject : ViewObject {

		//Animatorバッファ
		private Animator m_animatorBuf;

		public Animator m_animator {
			get {
				if(m_animatorBuf == null) {
					m_animatorBuf = GetComponent<Animator>();
				}
				return m_animatorBuf;
			}
		}

	}
}  