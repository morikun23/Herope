using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public class GameStartedDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 1; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if(rate <= 4) {
				return arg_gimmickList.Dictionary[3];
			}
			else {
				return arg_gimmickList.Dictionary[0];
			}
		}
	}
}