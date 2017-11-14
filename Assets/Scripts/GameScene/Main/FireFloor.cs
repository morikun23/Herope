using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFloor : MonoBehaviour {

	[SerializeField]
	GameObject obj_advFloor;
	[SerializeField]
	GameObject obj_advFire;

	// Use this for initialization
	void Start () {
		if (Random.Range (0, 100) > 40) {
			obj_advFloor.SetActive (false);
			obj_advFire.SetActive (false);
		} else if(Random.Range (0, 100) > 50){
			obj_advFire.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
