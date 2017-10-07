using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Herope {
	public class ResultScene : ToyBox.Scene {

		public override IEnumerator OnEnter () {
			//準備

			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(fade.IsFading);
		}

		public override IEnumerator OnUpdate () {
			while (true) {

				if (true) {
					//TODO:遷移条件
					break;
				}


				yield return null;
			}
		}

		public override IEnumerator OnExit () {
			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.StartFade(new FadeOut() , Color.black , 0.5f);
			yield return new WaitWhile(fade.IsFading);

			//後処理

			//シーン遷移
			SceneManager.LoadScene("SceneTitle");
		}

	}
}