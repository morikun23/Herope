﻿//担当：森田　勝
//概要：ゲーム内のプレイヤー
//　　　FSMの構造になっているので実際にはステート部分を構築していく
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class Player : MonoBehaviour {

		//最大体力
		[SerializeField]
		private int m_maxHp;
		
		public int MaxHp { get { return m_maxHp; } }

		//体力
		private int m_hp;
	
		public int Hp { get { return m_hp; } }

		//Rigibody2Dのバッファ
		private Rigidbody2D m_rigidbodyBuf;

		/// <summary>
		/// アタッチされているRigidbodyを取得する
		/// </summary>
		public Rigidbody2D m_rigidbody {
			get { return m_rigidbodyBuf ?? GetComponent<Rigidbody2D>(); }
		}

		//接地判定をおこなうコライダー
		private BoxCollider2D m_footBuf;

		/// <summary>
		/// 接地判定を行っているコライダーを取得する
		/// </summary>
		public BoxCollider2D m_foot {
			get { return m_footBuf ?? transform.FindChild("Foot").GetComponent<BoxCollider2D>(); }
		}

		//現在の状態(FSM)
		private IPlayerState m_currentState;

		//チャージ力(0 - 1)
		public float m_chargePower;

		public const float MAX_JUMP_POWER = 1;

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			m_currentState = new PlayerIdleState();
			m_currentState.OnEnter(this);
			m_chargePower = 0;
			m_hp = m_maxHp;
		}

		/// <summary>
		/// 更新
		/// </summary>
		public void UpdateByFrame() {

			//必要があればステートの遷移をおこなう
			IPlayerState nextState = m_currentState.GetNextState(this);
			if(nextState != null) {
				StateTransition(nextState);
			}

			//アップデート処理を実行
			m_currentState.OnUpdate(this);
			
		}

		/// <summary>
		/// ステートを遷移させる
		/// </summary>
		/// <param name="arg_nextState"></param>
		private void StateTransition(IPlayerState arg_nextState) {
			m_currentState.OnExit(this);
			m_currentState = arg_nextState;
			m_currentState.OnEnter(this);
		}

		/// <summary>
		/// 現在の状態を取得する
		/// </summary>
		/// <returns></returns>
		public System.Type GetCurrentState() {
			return m_currentState.GetType();
		}

#if APP_DEBUG
		/// <summary>
		/// プレイヤーの状態を取得する
		///	本来は非公開メンバなので注意
		/// </summary>
		/// <param name="arg_nextState"></param>
		public void _StateTransition(IPlayerState arg_nextState) {
			m_currentState.OnExit(this);
			m_currentState = arg_nextState;
			m_currentState.OnEnter(this);
		}
#endif
		/// <summary>
		/// プレイヤーのHPを減らす
		/// </summary>
		/// <param name="arg_value"></param>
		public void Damage(int arg_value) {
			m_hp -= arg_value;
		}
	}
}