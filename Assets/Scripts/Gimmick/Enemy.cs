using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope;
using ToyBox;

namespace Herope{
	public class Enemy : MonoBehaviour {

		[SerializeField]
		GameObject obj_head;
		[SerializeField]
		GameObject obj_arm;
		[SerializeField]
		GameObject obj_body;

		[SerializeField]
		GameObject obj_shot;
		[SerializeField]
		GameObject obj_shotPoint;

		SpriteRenderer spr_;
		[SerializeField]
		Sprite spr_dead;

		bool flg_isDead;
		Player scr_player;

		[SerializeField]
		bool flg_flip;

		// Use this for initialization
		void Start () {
			StartCoroutine (Shot());
			scr_player = GameObject.Find ("Player").GetComponent<Player> ();
			spr_ = GetComponent<SpriteRenderer> ();
		}
		
		// Update is called once per frame
		void Update () {
			if(!flg_isDead){
				float rot_head = Mathf.Atan2 (ScrollManager.Instance.GetPlayerPosition().y - obj_head.transform.position.y,
					ScrollManager.Instance.GetPlayerPosition().x - obj_head.transform.position.x) * Mathf.Rad2Deg;
				float rot_arm = Mathf.Atan2 (ScrollManager.Instance.GetPlayerPosition().y - obj_arm.transform.position.y,
					ScrollManager.Instance.GetPlayerPosition().x - obj_arm.transform.position.x) * Mathf.Rad2Deg;

				if (!flg_flip) {
				//	Debug.Log (obj_head.transform.eulerAngles);
					//if(obj_head.transform.eulerAngles.z <= 180){
						
						obj_arm.transform.eulerAngles = new Vector3 (0, 0, rot_arm);
						obj_head.transform.eulerAngles = new Vector3 (0, 0, rot_head);
					//}
				} else {
					obj_arm.transform.eulerAngles = new Vector3 (0, 0, rot_arm + 180);
					obj_head.transform.eulerAngles = new Vector3 (0, 0, rot_head + 180);
				}
			}
		}

		/// <summary>
		/// 一定間隔で弾をうつ
		/// </summary>
		IEnumerator Shot(){
			while(true){
				yield return new WaitForSeconds (2);
				GameObject baf_obj;
				if (!flg_isDead) {
					if (!flg_flip) {
						baf_obj = Instantiate (obj_shot, obj_shotPoint.transform.position, obj_arm.transform.rotation);
					} else {
						baf_obj = Instantiate (obj_shot, obj_shotPoint.transform.position, Quaternion.Euler(new Vector3(0,0,
							obj_arm.transform.eulerAngles.z + 180)));
					}
					baf_obj.GetComponent<EnemyShot> ().SetMoveSpeed (0.1f);
				}
			}
		}

		void OnTriggerStay2D(Collider2D col){
			if(scr_player.GetCurrentState().Name == "PlayerKickState" && !flg_isDead){
				flg_isDead = true;
				StartCoroutine (Dead());
			}
		}

		IEnumerator Dead(){
			float baf_spdX = -0.03f;
			float baf_spdY = 0.1f;

			AudioSource source = AppManager.Instance.m_audioManager.CreateSe ("Attack");
			source.Play ();

			Destroy (obj_arm);
			Destroy (obj_body);
			Destroy (obj_head);

			spr_.sprite = spr_dead;

			for (int i = 0;i < 180;i ++){
				transform.Translate (new Vector3(baf_spdX,baf_spdY,0));
				baf_spdX += 1 / 180;
				baf_spdY -= 0.01f;
				yield return null;
			}

			Destroy (gameObject);

		}
	}
}