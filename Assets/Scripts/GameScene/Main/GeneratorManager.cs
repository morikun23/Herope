using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {

	#region シリアライズ化させるための記述
	[System.Serializable]
	public class GimmickList : Serialize.DictionaryBase<int , GameObject , Gimmick> {

	}

	[System.Serializable]
	public class Gimmick : Serialize.KeyAndValue<int , GameObject> {
		public Gimmick(int key , GameObject value) : base(key , value) {

		}
	}
	#endregion

	public class GeneratorManager : MonoBehaviour {

		[SerializeField]
		private GimmickList m_gimmickList;
		
		private IGameDifficulty m_currentDifficulty;

		[SerializeField]
		Generator m_mainGenerator;

		// Use this for initialization
		void Start() {

		}

		// Update is called once per frame
		void Update() {
			if(m_currentDifficulty == null) {
				return;
			}

			if(m_mainGenerator.GetCurrentCount() < 5) {
				for(int i = 0; i < 5; i++) {
					//進行度によって、Generatorに予約するギミックを抽選する
					m_mainGenerator.RegisterGimmick(m_currentDifficulty.LotteryGimmick(m_gimmickList));
				}
			}
		}

		public void SetDifficulty(IGameDifficulty arg_difficulty) {
			m_currentDifficulty = arg_difficulty;
		}
	}
}