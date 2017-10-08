using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Herope.Morita {
	public class JumpButton : MonoBehaviour {

		Player player;

		[Range(0 , 1)]
		[SerializeField]
		float jumpPower;

		// Use this for initialization
		void Start() {
			player = FindObjectOfType<Player>();
		}

		// Update is called once per frame
		void Update() {
			
		}

		public void OnButtonDown() {
			player.m_chargePower = jumpPower;
			player._StateTransition(new PlayerJumpState());
		}
	}
}