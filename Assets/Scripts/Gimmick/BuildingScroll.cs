using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class BuildingScroll : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {

			transform.Translate (new Vector3(0,ScrollManager.Instance.GetScrollSpeed(),0));
		}
	}
}
