//担当：森田　勝
//概要：プレイヤーのチャージ状態
//　　　チャージ力がMAXのときにウェイトさせてる
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerChargeState : IPlayerState {
		
		//増加中か?
		private bool m_onIncrease;

		//チャージ量（現在は一定）
		private const float POWER = 0.03f;

		public void OnEnter(Player arg_player) {
			m_onIncrease = true;
			m_waitCount = 0;
		}

		public void OnUpdate(Player arg_player) {

			if (m_onIncrease) {
				OnIncrease(arg_player);
			}
			else {
				OnDecrease(arg_player);
			}
		}

		public void OnExit(Player arg_player) {

		}

		public IPlayerState GetNextState(Player arg_player) {
			if (!Input.GetMouseButton(0)) { return new PlayerJumpState(); }
			return null;
		}

		/// <summary>
		/// チャージ力増加
		/// </summary>
		/// <param name="arg_player"></param>
		private void OnIncrease(Player arg_player) {
			if (arg_player.m_chargePower + POWER >= Player.MAX_JUMP_POWER) {
				//チャージ力が最大
				arg_player.m_chargePower = Player.MAX_JUMP_POWER;

				//指定フレーム数待機する
				if (WaitFrame(6)) { Turn(); }
			}
			else {
				arg_player.m_chargePower += POWER;
			}
		}

		/// <summary>
		/// チャージ力減少
		/// </summary>
		/// <param name="arg_player"></param>
		private void OnDecrease(Player arg_player) {
			if (arg_player.m_chargePower - POWER <= 0) {
				arg_player.m_chargePower = 0;
				Turn();
			}
			else {
				arg_player.m_chargePower -= POWER;
			}
		}

		/// <summary>
		/// チャージ状態の反転
		/// </summary>
		private void Turn() {
			m_onIncrease = !m_onIncrease;
		
		}
		
		//ウェイト時のカウント
		private int m_waitCount;

		/// <summary>
		/// 指定フレーム待機する
		/// </summary>
		/// <param name="arg_frame"></param>
		/// <returns></returns>
		private bool WaitFrame(int arg_frame) {
			m_waitCount++;
			if(m_waitCount > arg_frame) {
				m_waitCount = 0;
				return true;
			}
			return false;
		}
	}
}