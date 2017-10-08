using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope.Morita {
	public class DebugText : MonoBehaviour {

		Text m_text;

		Player player;

		// Use this for initialization
		void Start() {
			m_text = GetComponent<Text>();
			player = FindObjectOfType<Player>();
		}

		// Update is called once per frame
		void Update() {

			string state = player.GetCurrentState().ToString();
			m_text.text = state;
		}
	}
}