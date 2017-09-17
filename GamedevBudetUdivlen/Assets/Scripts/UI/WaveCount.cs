using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCount : MonoBehaviour {

	public Text waves;
	void Update () {
		string mw = GameManager.instance.spawner.maxWaveCount.ToString();
		string cw = GameManager.instance.spawner.currentWaveNum.ToString();
		waves.text = cw + "/" + mw;
	}
}
