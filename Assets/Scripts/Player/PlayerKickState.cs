//担当：森田　勝
//概要：プレイヤーのキック中の処理
//　　　ジャンプからの下降中をキックしています。
//　　　基本的にはキック中に攻撃の処理を行います
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerKickState : IPlayerState {

		public void OnEnter(Player arg_player) {
			//思わぬ動作を防ぐためにリセットしておく
			arg_player.m_rigidbody.velocity = Vector2.zero;
		}

		public void OnUpdate(Player arg_player) {
			//この状態のときに攻撃処理を行う
		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			
			BoxCollider2D foot = arg_player.m_foot;

			if (IsGrounded(foot)) {
				return new PlayerIdleState();
			}

			return null;
		}

		/// <summary>
		/// 接地判定
		/// </summary>
		/// <param name="arg_foot"></param>
		/// <returns></returns>
		private bool IsGrounded(BoxCollider2D arg_foot) {
			return Physics2D.BoxCast(arg_foot.transform.position ,
				arg_foot.bounds.size , 0 , Physics2D.gravity.normalized ,
				0.5f , 1 << LayerMask.NameToLayer("Ground"));
		}
	}
}