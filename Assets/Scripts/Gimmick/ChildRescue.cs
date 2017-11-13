using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Herope; 

namespace Herope{
	public class ChildRescue : MonoBehaviour {

		enum Status{
			Wait,
			Carry,
			Comp
		}
		Status enu_status;

		Player scr_player;

		[SerializeField]
		Sprite spr_hukidasiHelp;
		[SerializeField]
		Sprite spr_hukidasiThx;
		[SerializeField]
		GameObject obj_hukidasi;
		SpriteRenderer spr_hukidasi;
	
		[SerializeField]
		GameObject obj_body;
		SpriteRenderer spr_body;
		[SerializeField]
		Sprite spr_sit;
		[SerializeField]
		Sprite spr_carry;

		[SerializeField]
		GameObject obj_heli;
		GameObject obj_heliSpawn;

		Hericopter scr_hericopter;

		// Use this for initialization
		void Start () {
			enu_status = Status.Wait;
			scr_player = GameObject.Find ("Player").GetComponent<Player> ();

			spr_hukidasi = obj_hukidasi.GetComponent<SpriteRenderer> ();
			spr_body = obj_body.GetComponent<SpriteRenderer> ();

			obj_heliSpawn = GameObject.Find ("HeliSpawn");
		}
		
		// Update is called once per frame
		void Update () {
			switch(enu_status){
			case Status.Wait:
				spr_hukidasi.sprite = spr_hukidasiHelp;
				spr_body.sprite = spr_sit;
				break;
			case Status.Carry:
				spr_hukidasi.sprite = null;
				spr_body.sprite = spr_carry;
				break;
			case Status.Comp:
				spr_hukidasi.sprite = spr_hukidasiThx;
				spr_body.sprite = spr_sit;
				spr_body.flipX = true;
				break;
			}
		}

		void OnTriggerEnter2D (Collider2D arg_colldier){
			if (enu_status == Status.Wait && arg_colldier.gameObject.layer == LayerMask.NameToLayer("Player")) {
				enu_status = Status.Carry;

				transform.parent = scr_player.transform;
				transform.localPosition = new Vector3 (0, 0, transform.position.z);
				CallHeri ();
			} else if(enu_status == Status.Carry && arg_colldier.gameObject.layer == LayerMask.NameToLayer("Heli")){
				enu_status = Status.Comp;

				transform.parent = arg_colldier.transform;
				transform.localPosition = new Vector3 (-1.6f, -0.3f, transform.position.z);
				HeriExit ();
			}
			//Destroy (gameObject);

		}

		void CallHeri(){
			scr_hericopter = Instantiate (obj_heli,obj_heliSpawn.transform.position,Quaternion.identity).GetComponent<Hericopter>();
		}

		void HeriExit(){
			StartCoroutine (scr_hericopter.ExitHeli());
		}
	}
}
