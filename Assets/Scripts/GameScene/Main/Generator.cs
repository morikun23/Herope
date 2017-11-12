using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class Generator : MonoBehaviour {

		//出現させるギミックたち
		private readonly Queue<GameObject> m_registerdGimmicks = new Queue<GameObject>();

		//コルーチンのバッファ
		private Coroutine m_coroutineBuf;

		private const int CAPACITY = 20;

		[SerializeField]
		private float m_interval;

		public float Interval {
			get {
				return m_interval;
			}
			set {
				m_interval = value;
				StopCoroutine(m_coroutineBuf);
				StartGenerator();
			}
		}

		//最後に生成したオブジェクト（追従用）
		public GameObject lastGimmick;

		// Use this for initialization
		void Start() {
			StartGenerator();
		}

		public bool WaitForLastGimmick() {
			return Vector3.Distance(
				lastGimmick.transform.position + Vector3.up * ScrollManager.Instance.GetScrollSpeed() ,
				this.transform.position) <= 3.0f;
		}

		private void StartGenerator() {
			m_coroutineBuf = StartCoroutine(Generate());
		}

		private IEnumerator Generate() {
			while (true) {
				yield return new WaitWhile(WaitForLastGimmick);

				if(m_registerdGimmicks.Count <= 0) {
					continue;
				}
				GameObject gimmick = m_registerdGimmicks.Dequeue();
				lastGimmick = Instantiate(gimmick , this.transform.position , Quaternion.identity);
			}
		}

		public void RegisterGimmick(GameObject arg_gimmick) {
			if(arg_gimmick == null) { return; }
			if(m_registerdGimmicks.Count > CAPACITY) { return; }
			m_registerdGimmicks.Enqueue(arg_gimmick);
		}

		public int GetCurrentCount() {
			return m_registerdGimmicks.Count;
		}
	}
}