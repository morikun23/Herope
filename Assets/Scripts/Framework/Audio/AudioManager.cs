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

		//Se管理クラス
		private IAudioList m_seList;

		//Bgm管理クラス
		private IAudioList m_bgmList;

		//Audioフォルダの固定パス
		private const string FOLDER = "Audio/";
		private const string BGM = "BGM/";
		private const string SE = "SE/";

		/// <summary>
		/// 初期化
		/// </summary>
		public void Initialize() {
			m_seList = new SeList(30);
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
			if (arg_audioClip == null) {
				Debug.LogError ("空のAudioClipが渡されました");
				return null;
			}

			AudioSource freeAudioSource = m_bgmList.GetAudioSource();
			if(freeAudioSource == null) {
				Debug.LogError ("AudioSourceの容量不足です");
				return null; 
			}
			freeAudioSource.clip = arg_audioClip;
			return freeAudioSource;
		}

		/// <summary>
		/// BGMを追加する
		/// ※Resources内の専用フォルダにファイルを入れてください
		/// </summary>
		/// <param name="arg_clipName">再生するオーディオのファイル名</param>
		/// <returns></returns>
		public AudioSource CreateBgm(string arg_clipName) {

			if (string.IsNullOrEmpty (arg_clipName)) {
				Debug.LogError ("文字列が空です");
				return null;
			}

			AudioClip clip = Resources.Load<AudioClip>(FOLDER + BGM + arg_clipName);
			if (clip == null) {
				Debug.LogError ("ファイル取得失敗");
				return null;
			}
			return this.CreateBgm(clip);
		}

		/// <summary>
		/// SEを追加する
		/// </summary>
		/// <param name="arg_audioClip">再生するオーディオ</param>
		/// <returns>生成されたAudioSource</returns>
		public AudioSource CreateSe(AudioClip arg_audioClip) {

			if (arg_audioClip == null) {
				Debug.LogError ("空のAudioClipが渡されました");
				return null;
			}

			AudioSource freeAudioSource = m_seList.GetAudioSource();
			if(freeAudioSource == null) {
				Debug.LogError ("AudioSourceの容量不足です");
				return null; 
			}
			freeAudioSource.clip = arg_audioClip;
			return freeAudioSource;
		}

		/// <summary>
		/// SEを追加する
		/// ※Resources内の専用フォルダにファイルを入れてください
		/// </summary>
		/// <param name="arg_clipName"></param>
		/// <returns></returns>
		public AudioSource CreateSe(string arg_clipName) {
			if (string.IsNullOrEmpty (arg_clipName)) {
				Debug.LogError ("文字列が空です");
				return null;
			}
				

			AudioClip clip = Resources.Load<AudioClip>(FOLDER + SE + arg_clipName);
			if (clip == null) {
				Debug.LogError ("ファイル取得失敗");
				return null;
			}
			return this.CreateSe(clip);
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