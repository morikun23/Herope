//担当者：森田　勝
//概要　：SEのオーディオを管理するクラス
//参考　：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ToyBox {
	public class SeList : AudioListBase, IAudioList {

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="arg_length">リストの長さ</param>
		public SeList(int arg_length) : base(arg_length,"SE") { }

		/// <summary>
		/// 初期化
		/// </summary>
		public override void Initialize() {
			Transform se = new GameObject("SE").GetComponent<Transform>();
			base.Initialize();
			foreach(AudioSource audioSource in m_list) {
				audioSource.transform.SetParent(se);
			}
			DontDestroyOnLoad(se);
		}

		/// <summary>
		/// 使用されていないオーディオを探索して非アクティブ状態にする
		/// </summary>
		public override void SearchAndFree() {
			base.SearchAndFree();
		}

		/// <summary>
		/// 使用可能なオーディオを取得する
		/// </summary>
		/// <returns>使用可能なオーディオ</returns>
		public override AudioSource GetAudioSource() {
			AudioSource audioSource = m_list.Find(_ => !_.isPlaying);
			audioSource.gameObject.SetActive(true);
			return audioSource;
		}
	}
}