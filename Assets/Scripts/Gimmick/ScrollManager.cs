using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class ScrollManager : MonoBehaviour {

		Player m_scr_player;

		[SerializeField]
		float m_num_addScroll;//プレーヤーが接地していない時に加算されるスクロール値

		float m_spd_scroll;

		#region Singleton実装
		private static ScrollManager m_instance;

		public static ScrollManager Instance{
			get{
				if (m_instance == null){
					m_instance = FindObjectOfType<ScrollManager>();
				}
				return m_instance;
			}
		}
		#endregion

		// Use this for initialization
		void Start () {
			//プレーヤーを取得して保管
			m_scr_player = GameObject.Find("Player").GetComponent<Player>();

		}
		
		// Update is called once per frame
		void Update () {
			ControllScrollSpeed ();
			Debug.Log (m_spd_scroll);
		}

		public void ControllScrollSpeed(){
			switch(m_scr_player.GetCurrentState ().Name){
			case "PlayerIdleState":
				m_spd_scroll = 0.005f;
				break;
			case "PlayerJumpState":
				m_spd_scroll += m_num_addScroll;
				break;
			case "PlayerKickState":
				m_spd_scroll += m_num_addScroll * 2;
				break;
			}
		}

		/// <summary>
		/// プレーヤーのジャンプ力から打ち出した、現在のスクロールスピードを返します。
		/// </summary>
		public float GetScrollSpeed(){
			return m_spd_scroll;
		}
	}
}