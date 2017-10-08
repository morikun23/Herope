using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope.Morita {
	public class PhysicsManager : MonoBehaviour {

		// Use this for initialization
		void Start() {
			Physics2D.gravity = Vector2.left * 9.81f;
		}

		// Update is called once per frame
		void Update() {

		}
	}
}