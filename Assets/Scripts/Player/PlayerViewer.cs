using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class PlayerViewer : ToyBox.AnimationObject {

		public void Initialize(Player arg_player) {

		}

		public void UpdateByFrame(Player arg_player) {
			if (arg_player.m_isStrongMode) {
				//無敵モード中は点滅させる
				m_spriteRenderer.enabled = !m_spriteRenderer.enabled;
			} else {
				m_spriteRenderer.enabled = true;
			}
		}
	}
}