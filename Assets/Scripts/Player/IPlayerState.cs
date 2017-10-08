using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Herope {
	public interface IPlayerState {

		/// <summary>
		/// この状態になったときの処理
		/// </summary>
		/// <param name="arg_player"></param>
		void OnEnter(Player arg_player);

		/// <summary>
		/// この状態でいるときの処理
		/// </summary>
		/// <param name="arg_player"></param>
		void OnUpdate(Player arg_player);

		/// <summary>
		/// この状態がおわるときの処理
		/// </summary>
		/// <param name="arg_player"></param>
		void OnExit(Player arg_player);

		/// <summary>
		/// 次に遷移される状態を取得する
		/// </summary>
		/// <param name="arg_player"></param>
		/// <returns></returns>
		IPlayerState GetNextState(Player arg_player);
	}
}