using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class LifeBox : MonoBehaviour {

		[SerializeField]
		GameObject obj_lid;
		[SerializeField]
		GameObject obj_body;
		[SerializeField]
		GameObject obj_heart;

		[SerializeField]
		AnimationCurve cur_move;
		[SerializeField]
		Transform tra_lidEnd;
		[SerializeField]
		Transform tra_heartEnd;

		// Use this for initialization
		void Start () {
			StartCoroutine (Animation());
		}
		
		// Update is called once per frame
		void Update () {
			
		}

		IEnumerator Animation(){
			yield return StartCoroutine (PositionMove(tra_lidEnd.position,obj_lid));

			obj_lid.GetComponent<SpriteRenderer> ().sortingOrder = -2;

			yield return StartCoroutine (PositionMove(tra_heartEnd.position,obj_heart));

			yield return new WaitForSeconds (1);

			Player baf_player = FindObjectOfType<Player>();
			if(baf_player.Hp < 3){
				baf_player.Damage (-1);
			}
			Destroy (gameObject);

		}

		IEnumerator PositionMove(Vector3 pos,GameObject obj){

			Vector3 baf_posInit = obj.transform.position;
			Vector3 baf_posEnd = pos;

			float baf_distX = baf_posEnd.x - baf_posInit.x;
			float baf_distY = baf_posEnd.y - baf_posInit.y;

			for(int i = 1;i <= 20;i ++){

				obj.transform.position = new Vector3 (
					baf_posInit.x + (cur_move.Evaluate((float)i / (float)20) * baf_distX),
					baf_posInit.y + (cur_move.Evaluate((float)i / (float)20) * baf_distY),
					transform.position.z);
				yield return null;
			}

			yield break;
		}


	}
}
