using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Herope {
	public class TitleScene : ToyBox.Scene {

		[SerializeField]
		Animator m_clickStart;

		[SerializeField]
		AudioSource bgm_;

		public override IEnumerator OnEnter () {
			//準備

			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.Fill(Color.black);
			yield return new WaitForSeconds(0.5f);

			fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(fade.IsFading);
		}

		public override IEnumerator OnUpdate () {
			yield return new WaitWhile(() => !Input.GetMouseButtonUp(0));

			AudioSource source = AppManager.Instance.m_audioManager.CreateSe ("Sys_Enter");
			source.Play ();

			m_clickStart.Play("Flash");

			for(int i = 1;i <= 60;i ++){
				bgm_.volume = 1f - ((float)i/60f);
				yield return null;
			}

		}

		public override IEnumerator OnExit () {

			//フェード
			Fade fade = AppManager.Instance.m_fade;

			fade.StartFade(new FadeOut() , Color.black , 0.5f);

			yield return new WaitWhile(fade.IsFading);
			//シーン遷移
			SceneManager.LoadScene("SceneMain");
			yield break;
		}

	}
}