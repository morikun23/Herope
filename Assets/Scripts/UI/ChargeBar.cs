//担当：森田　勝
//概要：UIのチャージバーのスクリプト
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope {
	public class ChargeBar : MonoBehaviour {

		//プレイヤー
		[SerializeField]
		private Player m_player;

		//塗りつぶしに使用するImageコンポーネント
		[SerializeField]
		private Image m_image;

		//元の色（色を変更するときに使用する）
		private Color m_colorBuf;

		// Use this for initialization
		void Start() {
			m_colorBuf = m_image.color;
		}

		// Update is called once per frame
		void Update() {
			this.Fill(m_player.m_chargePower);
		}

		/// <summary>
		/// 自身のスプライトを塗りつぶす
		/// 引数で渡された値の割合だけ表示させる
		/// </summary>
		/// <param name="arg_value"></param>
		void Fill(float arg_value) {
			m_image.fillAmount = arg_value;

			//チャージ力が最大の時に色を変更する
			if (m_player.m_chargePower >= 1){
				//オレンジ色
				m_image.color = new Color(1 , 0.5f , 0 , 1);
			}
			else {
				m_image.color = m_colorBuf;
			}
		}
	}
}