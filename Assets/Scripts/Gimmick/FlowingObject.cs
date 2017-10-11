using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class FlowingObject : ToyBox.ObjectBase {

		public float m_speed;

		// Use this for initialization
		protected virtual void Start() {

		}

		// Update is called once per frame
		protected virtual void Update() {
			m_transform.position += Vector3.up * m_speed;
		}
	}
}