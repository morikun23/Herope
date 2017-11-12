using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public interface IGameDifficulty {
		
		/// <summary>
		/// 明示的な難易度
		/// </summary>
		int Difficulty { get; }

		/// <summary>
		/// ギミックを抽選する
		/// </summary>
		/// <returns></returns>
		GameObject LotteryGimmick(GimmickList arg_gimmickList);
	}
}