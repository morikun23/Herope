using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToyBox {
	public abstract class Scene : MonoBehaviour {

		protected void Start() {
			StartCoroutine(GameLoop());
		}

		protected void Update() {

		}

		public abstract IEnumerator OnEnter();

		public abstract IEnumerator OnUpdate();

		public abstract IEnumerator OnExit();

		protected IEnumerator GameLoop() {
			
				Debug.Log(SceneManager.GetActiveScene().name + "EnterStart");
				//シーンを開始する
				yield return OnEnter();
				Debug.Log(SceneManager.GetActiveScene().name + "EnterEnd");

				Debug.Log(SceneManager.GetActiveScene().name + "UpdateStart");
				//シーンを実行する
				yield return OnUpdate();
				Debug.Log(SceneManager.GetActiveScene().name + "UpdateEnd");

				Debug.Log(SceneManager.GetActiveScene().name + "ExitStart");
				//シーンを終了する
				yield return OnExit();
				Debug.Log(SceneManager.GetActiveScene().name + "ExitEnd");
			
		}
	}
}