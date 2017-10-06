//担当者：森田　勝
//概要　：オーディオリスト用のインターフェイス
//参考　：とくになし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public interface IAudioList {

		//初期化
		void Initialize();

		//再生されていないAudioSourceを非アクティブ状態にする
		void SearchAndFree();

		//取得可能なオーディオを取得する
		AudioSource GetAudioSource();
	}
}