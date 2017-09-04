using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultCollider : MonoBehaviour {
	
	public Transform upgradeMenu;

	void OnMouseDown(){
		drawUpgradeMenu();
	}
	public void drawUpgradeMenu(){
		//Instantiate(upgradeMenu, gameObject.transform.position + new Vector3(0, 8, -2), Quaternion.Euler(-20, 0, 0), gameObject.gameObject.transform);
		Instantiate(upgradeMenu, gameObject.gameObject.transform, false);

	}
}
