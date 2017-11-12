using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;

namespace Herope{
	public class Enemy : MonoBehaviour {

		[SerializeField]
		GameObject obj_head;
		[SerializeField]
		GameObject obj_arm;

		[SerializeField]
		GameObject obj_shot;
		[SerializeField]
		GameObject obj_shotPoint;

		// Use this for initialization
		void Start () {
			StartCoroutine (Shot());
		}
		
		// Update is called once per frame
		void Update () {

			float rot_head = Mathf.Atan2 (ScrollManager.Instance.GetPlayerPosition().y - obj_head.transform.position.y,
				ScrollManager.Instance.GetPlayerPosition().x - obj_head.transform.position.x) * Mathf.Rad2Deg;
			float rot_arm = Mathf.Atan2 (ScrollManager.Instance.GetPlayerPosition().y - obj_arm.transform.position.y,
				ScrollManager.Instance.GetPlayerPosition().x - obj_arm.transform.position.x) * Mathf.Rad2Deg;


			obj_arm.transform.eulerAngles = new Vector3 (0,0,rot_arm);
			obj_head.transform.eulerAngles = new Vector3 (0,0,rot_head);
		}

		/// <summary>
		/// 一定間隔で弾をうつ
		/// </summary>
		IEnumerator Shot(){
			while(true){
				yield return new WaitForSeconds (1);

				GameObject baf_obj = Instantiate (obj_shot,obj_shotPoint.transform.position,obj_arm.transform.rotation);
				baf_obj.GetComponent<EnemyShot> ().SetMoveSpeed (0.1f);
			}
		}
	}
}