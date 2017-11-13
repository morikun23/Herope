using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope {
	public class ScoreViewer : MonoBehaviour {

		Text m_text;
		
		// Use this for initialization
		void Start() {
			m_text = GetComponent<Text>();
		}

		// Update is called once per frame
		void Update() {
			m_text.text = GameScore.Score.ToString().PadLeft(6,'0');
		}
	}
}