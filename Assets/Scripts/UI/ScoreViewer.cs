using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope {
	public class ScoreViewer : MonoBehaviour {

		Text m_text;

		[SerializeField]
		GameScore m_score;

		// Use this for initialization
		void Start() {
			m_text = GetComponent<Text>();
		}

		// Update is called once per frame
		void Update() {
			m_text.text = m_score.Score.ToString().PadLeft(6,'0');
		}
	}
}