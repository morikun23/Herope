using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Herope {
	public class MainScene : ToyBox.Scene {

		//プレイヤー
		private Player m_player;

		public override IEnumerator OnEnter () {
			//準備
			m_player = FindObjectOfType<Player>();
			m_player.Initialize();
			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(fade.IsFading);
		}

		public override IEnumerator OnUpdate () {
			while (true) {

				m_player.UpdateByFrame();
				if (m_player.GetCurrentState() == typeof(PlayerDeadState)) {
					//プレイヤーが死亡しているようなら終了演出へ移る
					break;
				}
				#if APP_DEBUG
				//ゲームをスキップするための隠しコマンド
				if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W)) {
					break;
				}
				#endif

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
			SceneManager.LoadScene("SceneResult");
		}

	}
}