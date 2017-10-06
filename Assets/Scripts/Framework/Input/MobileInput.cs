//担当者：久野(佐藤から引継ぎ)
//概要　：スマホからの入力を取ることのできるオブジェクトの基底クラス
//		　基本的には148行目以降の関数を継承先で呼び出すだけです。
//参考：佐藤に聞いて
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToyBox{
	public class MobileInput : MonoBehaviour {

		Vector3[] m_pos_input = new Vector3[10];
		Vector3[] m_pos_inputScreen = new Vector3[10];
		Vector3[] m_pos_inputBefore = new Vector3[10];
		Vector3[] m_pos_inputScreenBefore = new Vector3[10];
		Vector3[] m_pos_init = new Vector3[10];
		Vector3 num_size;

		public Transform pos_rotatePoint;

		bool[] flg_start = new bool[10];
		bool[] flg_move = new bool[10];
		int[] num_rotateDirection = new int[10];

		// Use this for initialization
		public void Start () {
			//サイズの取得
			if (GetComponent<BoxCollider2D> ()) {
				num_size = GetComponent<BoxCollider2D>().bounds.size;
			} else if(GetComponent<CircleCollider2D> ()){
				num_size = GetComponent<CircleCollider2D>().bounds.size;
			}else if(GetComponent<SpriteRenderer>()){
				num_size = GetComponent<SpriteRenderer> ().bounds.size;
			}

			//回転の中心を取得(Hieralkey上で何もなければ)
			if(pos_rotatePoint == null){
				pos_rotatePoint = transform;
			}
		}

		// Update is called once per frame
		public void Update () {

			#if UNITY_ANDROID && DEVICE_ANDROID

			int baf_i = 0;
			foreach (Touch t in Input.touches) {

				baf_i++;
				//タッチ位置を取得
				//１フレーム前のタッチ座標を格納
				m_pos_inputBefore[baf_i] = m_pos_input[baf_i];
				m_pos_inputScreenBefore [baf_i] = m_pos_inputScreen [baf_i];
				m_pos_inputScreen[baf_i] = t.position;
				m_pos_input[baf_i] = Camera.main.ScreenToWorldPoint (t.position);


				switch(t.phase){
				case TouchPhase.Began:
					if (!CheckHitPoint (m_pos_input[baf_i]))
						continue;
					Started ();
					m_pos_init[baf_i] = m_pos_input[baf_i];
					flg_start[baf_i] = true;
					break;

				case TouchPhase.Moved:
					if (!flg_start [baf_i])
						continue;
					Moving (t.deltaPosition);
					CheckRotate (baf_i);
					flg_move [baf_i] = true;
					break;

				case TouchPhase.Ended:
					if (!flg_start [baf_i])
						continue;

					if (!CheckMove (baf_i)) {
						SwipeEnd ();
					} else {
						TouchEnd ();
					}
					flg_start [baf_i] = false;
					flg_move [baf_i] = false;
					num_rotateDirection [baf_i] = 0;

					m_pos_input [baf_i] = Vector3.zero;
					m_pos_inputBefore [baf_i] = Vector3.zero;
					break;
				}

				if (flg_move[baf_i] && flg_start[baf_i]) {
					if(num_rotateDirection[baf_i] == 1){
						RightRotate (1);
					}else if(num_rotateDirection[baf_i] == -1){
						LeftRotate (-1);
					}
					break;
				}
			}
			#endif

			#if UNITY_STANDALONE_WIN || DEVELOP
			if(Input.GetMouseButtonDown(0)){
				//タッチ位置を取得
				//１フレーム前のタッチ座標を格納
				m_pos_inputBefore[0] = m_pos_input[0];
				m_pos_inputScreenBefore [0] = m_pos_inputScreen [0];
				m_pos_inputScreen[0] = Input.mousePosition;
				m_pos_input[0] = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				if(Input.GetMouseButtonDown(0)){
					if (!CheckHitPoint (m_pos_input[0]))
						return;
					Started ();
					m_pos_init[0] = m_pos_input[0];
					flg_start[0] = true;
				}else if(Input.GetMouseButtonUp(0)){
					if (!flg_start [0])
						return;
					Moving (Input.mouseScrollDelta);
					CheckRotate (0);
					flg_move [0] = true;
				}else{
					if (!flg_start [0])
						return;
					Moving (Input.mouseScrollDelta);
					CheckRotate (0);
					flg_move [0] = true;
					//return;
				}

				if (flg_move[0] && flg_start[0]) {
					if(num_rotateDirection[0] == 1){
						RightRotate (1);
					}else if(num_rotateDirection[0] == -1){
						LeftRotate (-1);
					}
					//return;
				}
			}
			#endif
		}

		/// <summary>
		/// Checks the hit point.
		/// </summary>
		/// <returns><c>true</c>, if hit point was checked, <c>false</c> otherwise.</returns>
		/// <param name="arg_pos">Argument position.</param>
		bool CheckHitPoint(Vector3 arg_pos){
			//タッチ箇所がオブジェクトと重なっているかチェック
			//transform.position = pos;

			if (arg_pos.x <= pos_rotatePoint.position.x + num_size.x / 2 && arg_pos.x >= pos_rotatePoint.position.x - num_size.x / 2 &&
				arg_pos.y <= pos_rotatePoint.position.y + num_size.y / 2 && arg_pos.y >= pos_rotatePoint.position.y - num_size.y / 2) {
				return true;
			}
			return false;
		}

		//タッチの許容範囲かどうかの計測
		bool CheckMove(int arg_i){
			if(Mathf.Abs(m_pos_input[arg_i].x - m_pos_init[arg_i].x) <= 1 &&
				Mathf.Abs(m_pos_input[arg_i].y - m_pos_init[arg_i].y) <= 1){
				return true;
			}
			return false;
		}

		//どのくらい回転したかチェック
		void CheckRotate(int arg_i){
			Vector2 baf_pos = pos_rotatePoint.position;
			float baf_rotBef = Vector2.Angle(pos_rotatePoint.position,m_pos_inputBefore[arg_i] - pos_rotatePoint.position);
			float baf_rotNew = Vector2.Angle(pos_rotatePoint.position,m_pos_input[arg_i] - pos_rotatePoint.position);

			Debug.DrawRay (pos_rotatePoint.position,m_pos_input[arg_i] - pos_rotatePoint.position);
			Debug.Log (baf_rotNew - baf_rotBef);

			if(baf_rotNew - baf_rotBef > 5 && ((baf_rotBef > 0 && baf_rotNew > 0) || (baf_rotBef < 0 && baf_rotNew < 0))){
				num_rotateDirection[arg_i] = 1;
			}
			else if(baf_rotNew - baf_rotBef < -5 && ((baf_rotBef > 0 && baf_rotNew > 0) || (baf_rotBef < 0 && baf_rotNew < 0))){
				num_rotateDirection[arg_i] = -1;
			}
		}

		//各イベント呼び出し
		//	タッチ開始
		public virtual void Started(){}
		//	スワイプ中
		public virtual void Moving(Vector2 direc){}
		//	スワイプせずにタッチ終了
		public virtual void TouchEnd(){}
		//	スワイプ後タッチ終了
		public virtual void SwipeEnd(){}
		//	右回転
		public virtual void RightRotate(float dist){}
		//	左回転
		public virtual void LeftRotate(float dist){}



	}
}