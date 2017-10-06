//担当者：森田　勝
//概要　：フェード実装用のインターフェイス
//参考　：なし

namespace ToyBox {
	public interface IFadeAction {
		
		//フェード開始処理
		void OnEnter(Fade.FadeInfo arg_fadeInfo);

		//アップデート
		void OnUpdate(Fade.FadeInfo arg_fadeInfo);

		//フェード終了したか
		bool IsEnd(Fade.FadeInfo arg_fadeInfo);

		//フェード終了処理
		void OnExit(Fade.FadeInfo arg_fadeInfo);
	}
}