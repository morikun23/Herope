using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class DamageObject : MonoBehaviour {

		protected virtual void OnTriggerEnter2D(Collider2D arg_colldier) {
			if(arg_colldier.gameObject.layer == LayerMask.NameToLayer("Player")) {
				Player player = arg_colldier.transform.parent.GetComponent<Player>();
				player.Damage(1);
			}
		}
	}
}
