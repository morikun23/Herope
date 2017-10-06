//担当：森田　勝
//概要：ゲーム内のプレイアブルキャラクターの基底クラス
//参考：特になし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public abstract class ActorBase : ObjectBase {
		
		//移動速度
		public float m_speed;

		//向き
		public enum Direction {
			RIGHT = 1,
			LEFT = -1
		}

		//現在の向き
		public Direction m_direction;

	}
}