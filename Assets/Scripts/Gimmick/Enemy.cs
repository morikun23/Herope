﻿using System.Collections;
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


				obj_arm.transform.eulerAngles = new Vector3 (0,0,rot_arm);
				obj_head.transform.eulerAngles = new Vector3 (0,0,rot_head);
			}
		}

		/// <summary>
		/// 一定間隔で弾をうつ
		/// </summary>
		IEnumerator Shot(){
			while(true){
				yield return new WaitForSeconds (2);
				if (!flg_isDead) {
					GameObject baf_obj = Instantiate (obj_shot, obj_shotPoint.transform.position, obj_arm.transform.rotation);
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