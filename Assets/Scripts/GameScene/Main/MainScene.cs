using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToyBox;
using UnityEngine.SceneManagement;

namespace Herope {
	public class MainScene : ToyBox.Scene {

		//プレイヤー
		private Player m_player;

		//タイマー（時間経過で難易度上昇？）
		private GameTimer m_timer;

		//ギミック生成用
		private GeneratorManager m_generatorManager;

		//ゲーム内スコア
		private GameScore m_score;

		//現在の難易度
		private int m_currentDifficulty;

		public override IEnumerator OnEnter () {

			//準備
			m_player = FindObjectOfType<Player>();
			m_generatorManager = GetComponent<GeneratorManager>();
			m_score = FindObjectOfType<GameScore>();
			m_timer = new GameTimer();

			//初期化
			m_player.Initialize();
			m_score.InitializeScore();
			
			//フェード
			Fade fade = AppManager.Instance.m_fade;
			fade.StartFade(new FadeIn() , Color.black , 0.5f);
			yield return new WaitWhile(fade.IsFading);

		}

		public override IEnumerator OnUpdate () {

			//ゲーム開始
			m_timer.Initialize();
			UpdateDifficulty(new GameStartedDifficulty());
			m_score.StartCounter();

			while (true) {
				#region 各ゲーム要素の更新
				m_timer.UpdateByFrame();
				m_player.UpdateByFrame();
				#endregion

				#region 難易度の更新
				if (GameScore.Score >= 12000) {
					//空のギミックは出現させない
					//プレイヤーが死ぬような難易度
					if (m_currentDifficulty != 6) {
						//インスタンス生成の重複を防ぐため、難易度が変更されていない場合のみ処理する
						UpdateDifficulty(new AllGimmickOnlyDifficulty());
					}
				}
				else if(GameScore.Score >= 8000) {
					//空のギミックの出現率を下げる
					if (m_currentDifficulty != 5) {
						//インスタンス生成の重複を防ぐため、難易度が変更されていない場合のみ処理する
						UpdateDifficulty(new GameCriMaxDifficulty());
					}
				}
				else if (GameScore.Score >= 5000) {
					//全てのギミックを解禁する
					if (m_currentDifficulty != 4) {
						//インスタンス生成の重複を防ぐため、難易度が変更されていない場合のみ処理する
						UpdateDifficulty(new FirstAllGimmickDifficulty());
					}
				}
				else if (GameScore.Score >= 3000) {
					//敵キャラ初登場、様子見のため火事ギミックを無くす
					if (m_currentDifficulty != 3) {
						UpdateDifficulty(new FirstEnemyDifficulty());
					}
				}
				else if (GameScore.Score >= 1500) {
					//子供救助ギミック初登場
					if (m_currentDifficulty != 2) {
						UpdateDifficulty(new FirstRescueDifficulty());
					}
				}
				else if (GameScore.Score >= 300) {
					//火事ギミック初登場
					if (m_currentDifficulty != 1) {
						UpdateDifficulty(new FirstFireDifficulty());
					}
				}
				#endregion


				#region 終了検知
				if (m_player.GetCurrentState() == typeof(PlayerDeadState)) {
					//プレイヤーが死亡しているようなら終了演出へ移る
					break;
				}
				#endregion
				
				#if APP_DEBUG
				//ゲームをスキップするための隠しコマンド
				if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.W)) {
					break;
				}
				#endif

				yield return null;
			}

			m_score.StopCounter();
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

		/// <summary>
		/// 難易度を設定する
		/// </summary>
		/// <param name="arg_nextDifficulty"></param>
		private void UpdateDifficulty(IGameDifficulty arg_nextDifficulty) {
			m_generatorManager.SetDifficulty(arg_nextDifficulty);
			m_currentDifficulty = arg_nextDifficulty.Difficulty;
		}
	}
}