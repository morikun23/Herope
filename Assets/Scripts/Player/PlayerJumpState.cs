//担当：森田　勝
//概要：プレイヤーのジャンプ中の処理
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerJumpState : IPlayerState {

		//基本的なジャンプ力
		private const float BASE_JUMP_POWER = 120;

		//補正値
		private const float ADD_JUMP_POWER = 300;

		public void OnEnter(Player arg_player) {
			//加速度を一度リセットさせて気持ちよくジャンプさせる
			arg_player.m_rigidbody.velocity = Vector2.zero;

			float jumpPower = BASE_JUMP_POWER + (arg_player.m_chargePower * ADD_JUMP_POWER);
			arg_player.m_rigidbody.AddForce(Vector2.right * jumpPower * 2);

			//arg_player.m_viewer.m_spriteRenderer.sprite = Resources.Load ("Sprites/SRH_Player/SRH_Player_0",typeof(Sprite)) as Sprite;
		}

		public void OnUpdate(Player arg_player) {

		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			if(arg_player.m_rigidbody.velocity.x < 0f) {
				return new PlayerKickState();
			}
			return null;
		}
	}
}