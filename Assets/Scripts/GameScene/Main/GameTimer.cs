using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class GameTimer {

		private float m_elapsedTime;

		public float CurrentTime {
			get { return m_elapsedTime; }
		}

		public void Initialize() {
			m_elapsedTime = 0;
		}

		public void UpdateByFrame() {
			m_elapsedTime += Time.deltaTime;
		}
	}
}