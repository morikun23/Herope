//担当者：森田　勝
//概要　：フェードアウト（徐々に暗くなる）の実装クラス
//参考　：なし

using UnityEngine;

namespace ToyBox {
	public class FadeOut : IFadeAction {
		
		/// <summary>
		/// フェード開始処理
		/// </summary>
		/// <param name="arg_fadeInfo">フェード情報</param>
		public void OnEnter(Fade.FadeInfo arg_fadeInfo) {
			
			Color color = arg_fadeInfo.m_fadeObject.color;
			color.a = arg_fadeInfo.m_currentAlpha;

			arg_fadeInfo.m_fadeObject.color = color;
		}

		/// <summary>
		/// フェードのアップデート処理
		/// </summary>
		/// <param name="arg_fadeInfo">フェード情報</param>
		public void OnUpdate(Fade.FadeInfo arg_fadeInfo) {
			Color color = arg_fadeInfo.m_fadeObject.color;

			color.a = arg_fadeInfo.m_currentAlpha + Time.deltaTime / arg_fadeInfo.m_duration;
			arg_fadeInfo.m_fadeObject.color = color;
			arg_fadeInfo.m_currentAlpha = arg_fadeInfo.m_fadeObject.color.a;
		}

		/// <summary>
		/// フェード終了したか
		/// </summary>
		/// <param name="arg_fadeInfo">フェード情報</param>
		/// <returns></returns>
		public bool IsEnd(Fade.FadeInfo arg_fadeInfo) {
			return arg_fadeInfo.m_currentAlpha >= 0.99f;
		}

		/// <summary>
		/// フェード終了処理
		/// </summary>
		/// <param name="arg_fadeInfo">フェード情報</param>
		public void OnExit(Fade.FadeInfo arg_fadeInfo) {
			arg_fadeInfo.m_currentAlpha = Fade.FadeInfo.MAX;
		}
	}
}