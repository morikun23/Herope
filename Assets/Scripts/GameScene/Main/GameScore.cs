using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class GameScore : MonoBehaviour {

		private static float m_score;

		public const int MAX_SCORE = 999999;

		public static int Score {
			get { return (int)m_score; }
		}

		private Coroutine m_coroutineBuf;

		// Use this for initialization
		void Start() {
			StartCoroutine(OnUpdate());
		}

		public void InitializeScore() {
			m_score = 0;
		}

		public void StartCounter() {
			if(m_coroutineBuf != null) { return; }
			m_coroutineBuf = StartCoroutine(OnUpdate());
		}

		public void StopCounter() {
			StopCoroutine(m_coroutineBuf);
			m_coroutineBuf = null;
		}

		private IEnumerator OnUpdate() {
			while (true) {
				yield return new WaitWhile(() => !ScrollManager.Instance.isActiveAndEnabled);

				AddScore(ScrollManager.Instance.GetScrollSpeed() * 10);
			}
		}

		public void AddScore(float arg_value) {
			if(m_score + arg_value >= MAX_SCORE) {
				m_score = MAX_SCORE;
			}
			else {
				m_score += arg_value;
			}
		}
	}
}