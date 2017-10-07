using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Herope {
	public class StartUpScene : ToyBox.Scene {

		public override IEnumerator OnEnter () {
			//準備

			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.Fill(Color.black);
			//シーン遷移
			SceneManager.LoadScene("SceneTitle");

			yield break;
		}

		public override IEnumerator OnUpdate () {
			yield break;
		}

		public override IEnumerator OnExit () {
			
			yield break;
		}

	}
}