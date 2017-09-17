using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPanel : MonoBehaviour {
	public GameObject buildLayout;
	public GameObject upgradeLayout;
	public Button[] buttons = new Button[4];

	void Start(){
		GameManager.instance.focuser.ClickNotOnCanvas += closeTowerPanel;
	}



	public void openTowerPanel(string mode, TowerPlaceholder tp){
		gameObject.SetActive(true);

		if(mode == "Build"){
			buildLayout.SetActive(true);
			foreach(Button button in buttons){
				button.onClick.RemoveAllListeners();
			}
			buttons[0].onClick.AddListener(delegate(){ tp.CreateTower(TowerType.Assault); closeTowerPanel(); });
			buttons[1].onClick.AddListener(delegate(){ tp.CreateTower(TowerType.Barracks); closeTowerPanel(); });
			buttons[2].onClick.AddListener(delegate(){ tp.CreateTower(TowerType.Buffer); closeTowerPanel(); });
			buttons[3].onClick.AddListener(delegate(){ tp.CreateTower(TowerType.Arcane); closeTowerPanel(); });
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
