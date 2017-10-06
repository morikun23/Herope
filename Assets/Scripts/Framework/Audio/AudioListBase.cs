//担当者：森田　勝
//概要　：オーディオリストを作成するための基底クラス
//参考　：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ToyBox {
	public abstract class AudioListBase : MonoBehaviour {

		//実際に格納されるリスト
		protected List<AudioSource> m_list;

		//リストのサイズ
		protected int m_length;

		//現在のバッファ位置
		protected int m_currentBuffer;

		//デフォルトの名前
		protected string m_defaultName;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="arg_length">リストの長さ</param>
		/// <param name="arg_name">サウンド名</param>
		protected AudioListBase(int arg_length , string arg_name) {
			m_length = arg_length;
			m_currentBuffer = 0;
			m_defaultName = arg_name;
			m_list = new List<AudioSource>();
		}

		/// <summary>
		/// 初期化
		/// </summary>
		public virtual void Initialize() {
			for (int i = 0; i < m_length; i++) {
				AudioSource audioSource = new GameObject(m_defaultName).AddComponent<AudioSource>();
				audioSource.gameObject.SetActive(false);
				m_list.Add(audioSource);
			}
		}

		/// <summary>
		/// 再生されていないオーディオを非アクティブ状態にする
		/// </summary>
		public virtual void SearchAndFree() {
			List<AudioSource> freeAudioSources = m_list.Where(_ => !_.isPlaying).ToList();
			
			foreach (AudioSource audioSource in freeAudioSources) {
				audioSource.gameObject.SetActive(false);
			}
		}

		/// <summary>
		/// オーディオを返す
		/// 循環バッファ上で、現在指されているバッファを返します。
		/// </summary>
		/// <returns>使用可能のオーディオ</returns>
		public virtual AudioSource GetAudioSource() {
			if(m_currentBuffer >= m_length) { m_currentBuffer = 0; }
			m_list[m_currentBuffer].gameObject.SetActive(true);
			return m_list[m_currentBuffer++];
		}
	}
}