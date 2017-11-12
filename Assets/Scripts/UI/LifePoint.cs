using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope {
	public class LifePoint : MonoBehaviour {

		[SerializeField]
		Sprite m_activeLife;

		[SerializeField]
		Sprite m_damagedLife;

		[SerializeField]
		Image[] m_lifeImages;

		private Player m_playerBuf;

		private int m_currentLife;

		// Use this for initialization
		void Start() {
			m_playerBuf = FindObjectOfType<Player>();
			m_currentLife = m_playerBuf.Hp;
		}

		// Update is called once per frame
		void Update() {
			if(m_currentLife == m_playerBuf.Hp) return;

			m_currentLife = m_playerBuf.Hp;

			for(int i = 0; i < m_lifeImages.Length; i++) {
				if(m_currentLife > i) {
					m_lifeImages[i].sprite = m_activeLife;
				}
				else {
					m_lifeImages[i].sprite = m_damagedLife;
				}
			}

		}
	}
}