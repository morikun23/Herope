using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class Helicopter_enemy : MonoBehaviour {

		[SerializeField]
		Transform tra_wait;
		[SerializeField]
		Transform tra_ceil;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			if(transform.position.y < tra_ceil.position.y){
				transform.Translate(new Vector3(0,ScrollManager.Instance.GetScrollSpeed (),0));	
			}

			if (transform.position.y > tra_wait.position.y) {
				transform.Translate (0, -0.04f, 0);
			}
				
		}
	}

}