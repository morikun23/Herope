using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize {
	[RuntimeInitializeOnLoadMethod]
	static void OnRuntimeMethodLoad() {
		Screen.SetResolution(1920 , 1080 , false , 60);
	}
}