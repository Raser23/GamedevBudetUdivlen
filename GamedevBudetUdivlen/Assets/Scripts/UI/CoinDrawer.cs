using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDrawer : MonoBehaviour {
	public Text count;
	void Update () {
		count.text = GameManager.instance.coins.ToString();
	}
}
