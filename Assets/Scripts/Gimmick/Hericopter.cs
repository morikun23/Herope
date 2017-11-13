using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hericopter : MonoBehaviour {

	[SerializeField]
	AnimationCurve cur_move;
	[SerializeField]
	int num_moveFrame;

	[SerializeField]
	GameObject obj_lifeBox;
	Transform tra_lifeBoxSpawn;

	//[SerializeField]
	Transform tra_waitPosition;
	//[SerializeField]
	Transform tra_exitPosition;

	// Use this for initialization
	void Start () {
		
		tra_waitPosition = GameObject.Find ("HeliWait").transform;
		tra_exitPosition = GameObject.Find ("HeliExit").transform;
		tra_lifeBoxSpawn = GameObject.Find ("LifeBoxSpawn").transform;

		StartCoroutine(PositionMove (tra_waitPosition.position));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator PositionMove(Vector3 pos){

		Vector3 baf_posInit = transform.position;
		Vector3 baf_posEnd = pos;

		float baf_distX = baf_posEnd.x - baf_posInit.x;
		float baf_distY = baf_posEnd.y - baf_posInit.y;

		for(int i = 1;i <= num_moveFrame;i ++){

			transform.position = new Vector3 (
				baf_posInit.x + (cur_move.Evaluate((float)i / (float)num_moveFrame) * baf_distX),
				baf_posInit.y + (cur_move.Evaluate((float)i / (float)num_moveFrame) * baf_distY),
				transform.position.z);
			yield return null;
		}

		yield break;
	}

	public IEnumerator ExitHeli(){

		Instantiate (obj_lifeBox,tra_lifeBoxSpawn.position,Quaternion.identity);
		yield return StartCoroutine(PositionMove (tra_exitPosition.position));
		Destroy (gameObject);
	}


}
