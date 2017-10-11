using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class FireArea : FlowingObject {

		// Use this for initialization
		protected override void Start() {

		}

		// Update is called once per frame
		protected override void Update() {
			base.Update();
		}

		protected virtual void OnTriggerEnter2D(Collider2D arg_colldier) {
			if(arg_colldier.gameObject.layer == LayerMask.NameToLayer("Player")) {
				Player player = arg_colldier.transform.parent.GetComponent<Player>();
				player.Damage(1);
			}
		}
	}
}