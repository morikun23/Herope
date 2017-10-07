//担当：森田　勝
//概要：アプリケーション内のパブリック機能および
//　　　パブリックなマネージャーを管理しているクラス
//　　　ユーティリティを使用するためにはこのクラスにアクセスする
//参考：なし

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox {
	public class AppManager : MonoBehaviour {

		#region Singleton実装

		private static AppManager m_instance;

		public static AppManager Instance {
			get {
				if (m_instance == null) {
					m_instance = new GameObject("AppManager").AddComponent<AppManager>();
					m_instance.Initialize();
				}
				return m_instance;
			}
		}

		private AppManager() {
		}

		#endregion

		//オーディオ環境
		public AudioManager m_audioManager { get; private set; }

		//フェード環境
		public Fade m_fade { get; private set; }

		void Initialize () {
			m_audioManager = AudioManager.Instance;
			m_audioManager.Initialize();
			m_fade = FindObjectOfType<Fade>();
			if (!m_fade) {
				m_fade = Instantiate(Resources.Load<GameObject>("Prefabs/FadeCanvas")).GetComponentInChildren<Fade>();
			}
			m_fade.Initialize();
			DontDestroyOnLoad(this.gameObject);
			DontDestroyOnLoad(m_audioManager.gameObject);
			DontDestroyOnLoad(m_fade.transform.parent.gameObject);
		}

	}
}