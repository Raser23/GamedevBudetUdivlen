using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour {
	public GameObject buildLayout;
	public GameObject upgradeLayout;
	public Button[] buttons = new Button[4];

	public void openTowerPanel(string mode, TowerPlaceholder tp){
		gameObject.SetActive(true);

		if(mode == "Build"){
			buildLayout.SetActive(true);
			buttons[0].onClick.AddListener(tp.CreateTower);
			buttons[0].onClick.AddListener(closeTowerPanel);
		}
		else if(mode == "Upgrade"){
			upgradeLayout.SetActive(true);
		}
		else{
			Debug.Log("Wrong mode");
		}
	}

	public void closeTowerPanel(){
		gameObject.SetActive(false);
		buildLayout.SetActive(false);
		upgradeLayout.SetActive(false);
	}	
}
