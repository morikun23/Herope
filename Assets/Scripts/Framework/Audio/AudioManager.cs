//担当者：森田　勝
//概要　：Audioの追加などを行う際に、
//　　　　使用するクラス
//　　　　SeやBgmのリストを所持している管理クラス
//　　　　Singleton構造で設計
//参考　：とくになし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ToyBox {
	public class AudioManager : MonoBehaviour {
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		private AudioManager() { }

		// Singletonインスタンス
		private static AudioManager m_instance;

		/// <summary>
		/// インスタンスの取得
		/// nullだった場合、自動的に生成させる
		/// </summary>
		public static AudioManager Instance {
			get {
				if (m_instance == null) {
					m_instance = new GameObject("AudioManager").AddComponent<AudioManager>();
				}
				return m_instance;
			}
		}

		//Se管理クラス
		private IAudioList m_seList;

		//Bgm管理クラス
		private IAudioList m_bgmList;

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			m_seList = new SeList(10);
			m_seList.Initialize();
			
			m_bgmList = new BgmList(1);
			m_bgmList.Initialize();

			StartCoroutine(OnUpdate());
		}
		
		/// <summary>
		/// BGMを追加する
		/// </summary>
		/// <param name="arg_audioClip">再生するオーディオ</param>
		/// <returns>生成されたAudioSource</returns>
		public AudioSource CreateBgm(AudioClip arg_audioClip) {
			AudioSource freeAudioSource = m_bgmList.GetAudioSource();
			freeAudioSource.clip = arg_audioClip;
			return freeAudioSource;
		}
		
		/// <summary>
		/// SEを追加する
		/// </summary>
		/// <param name="arg_audioClip">再生するオーディオ</param>
		/// <returns>生成されたAudioSource</returns>
		public AudioSource CreateSe(AudioClip arg_audioClip) {
			AudioSource freeAudioSource = m_seList.GetAudioSource();
			freeAudioSource.clip = arg_audioClip;
			return freeAudioSource;
		}

		/// <summary>
		/// アップデート処理
		/// </summary>
		public IEnumerator OnUpdate() {
			while (true) {
				m_seList.SearchAndFree();
				m_bgmList.SearchAndFree();
				yield return null;
			}
		}

	}
}