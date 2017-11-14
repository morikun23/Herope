using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {

	/// <summary>
	/// 難易度0
	/// 始まった瞬間は様子見でギミックは出さない
	/// </summary>
	public class GameStartedDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 0; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			return arg_gimmickList.Dictionary[0];
		}
	}

	/// <summary>
	/// 難易度1
	/// 火事ギミック初登場
	/// 避けやすい火事ギミックを少し生成する
	/// </summary>
	public class FirstFireDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 1; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if(rate < 3) {
				return arg_gimmickList.Dictionary[1];
			}
			else{
				return arg_gimmickList.Dictionary[0];
			}
		}
	}

	/// <summary>
	/// 難易度2
	/// 子供初登場
	/// 火事ギミックの出現率を上げる
	/// </summary>
	public class FirstRescueDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 2; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if (rate < 5) {
				return arg_gimmickList.Dictionary[3];
			}
			else if (rate < 6) {
				return arg_gimmickList.Dictionary[1];
			}
			else {
				return arg_gimmickList.Dictionary[0];
			}
		}
	}

	/// <summary>
	/// 難易度3
	/// 敵キャラ初登場
	/// 様子見のため、火事ギミックを出現させない
	/// </summary>
	public class FirstEnemyDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 3; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if (rate < 2) {
				return arg_gimmickList.Dictionary[2];
			}
			else if (rate < 3) {
				return arg_gimmickList.Dictionary[3];
			}
			else {
				return arg_gimmickList.Dictionary[0];
			}
		}
	}

	/// <summary>
	/// 難易度4
	/// 全てのギミックを初めて出現させる
	/// ただし空のギミックもある程度出現させる
	/// </summary>
	public class FirstAllGimmickDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 4; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if (rate < 3) {
				return arg_gimmickList.Dictionary[1];
			}
			else if (rate < 4) {
				return arg_gimmickList.Dictionary[2];
			}
			else if (rate < 5) {
				return arg_gimmickList.Dictionary[3];
			}
			else {
				return arg_gimmickList.Dictionary[0];
			}
		}
	}

	/// <summary>
	/// 難易度5
	/// 全てのギミックを出現させる
	/// 空のギミックの出現率も下げる
	/// ここでプレイヤーを殺す
	/// </summary>
	public class GameCriMaxDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 5; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if (rate < 3) {
				return arg_gimmickList.Dictionary[1];
			}
			else if (rate < 6) {
				return arg_gimmickList.Dictionary[2];
			}
			else if (rate < 8) {
				return arg_gimmickList.Dictionary[3];
			}
			else {
				return arg_gimmickList.Dictionary[0];
			}
		}
	}

	/// <summary>
	/// 難易度6
	/// 全てのギミックをまんべんなく出現させる
	/// 空のギミックは出現させない
	/// 今度こそプレイヤーを殺す
	/// </summary>
	public class AllGimmickOnlyDifficulty : IGameDifficulty {

		int IGameDifficulty.Difficulty {
			get { return 6; }
		}

		GameObject IGameDifficulty.LotteryGimmick(GimmickList arg_gimmickList) {
			int rate = UnityEngine.Random.Range(0 , 10);

			if (rate < 3) {
				return arg_gimmickList.Dictionary[2];
			}
			else if (rate < 6) {
				return arg_gimmickList.Dictionary[3];
			}
			else {
				return arg_gimmickList.Dictionary[1];
			}
		}
	}
}