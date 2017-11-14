//担当：森田　勝
//概要：プレイヤーの静止状態中の処理
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;

namespace Herope {
	public class PlayerIdleState : IPlayerState {

		public void OnEnter(Player arg_player) {
			arg_player.m_chargePower = 0;
			AudioSource source = AppManager.Instance.m_audioManager.CreateSe ("Randing");
			source.Play ();
		}

		public void OnUpdate(Player arg_player) {
			arg_player.m_viewer.m_spriteRenderer.sprite = Resources.Load ("Sprites/SRH_PlayerNeutoral",typeof(Sprite)) as Sprite;
		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			if (Input.GetMouseButtonDown(0)) { return new PlayerChargeState(); }
			return null;
		}
	}
}