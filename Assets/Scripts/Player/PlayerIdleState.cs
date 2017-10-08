//担当：森田　勝
//概要：プレイヤーの静止状態中の処理
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerIdleState : IPlayerState {

		public void OnEnter(Player arg_player) {
			arg_player.m_chargePower = 0;
		}

		public void OnUpdate(Player arg_player) {

		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			if (Input.GetMouseButtonDown(0)) { return new PlayerChargeState(); }
			return null;
		}
	}
}