//担当：森田　勝
//概要：プレイヤーの死亡状態中の処理
//　　　再プレイするためのステート遷移はおこなわない
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerDeadState : IPlayerState {

		public void OnEnter(Player arg_player) {
			
		}

		public void OnUpdate(Player arg_player) {

		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			return null;
		}
	}
}