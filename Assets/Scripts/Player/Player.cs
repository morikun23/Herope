using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {

	/// <summary>
	/// プレイヤー
	/// </summary>
	public class Player : MonoBehaviour {

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
		
		// Use this for initialization
		void Start() {
			m_currentState = new PlayerIdleState();
			m_currentState.OnEnter(this);
			m_chargePower = 0;
		}

		// Update is called once per frame
		void Update() {

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

#if DEBUG
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
	}
}