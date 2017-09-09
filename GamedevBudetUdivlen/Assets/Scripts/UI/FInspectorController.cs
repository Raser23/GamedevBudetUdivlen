using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FInspectorController : MonoBehaviour {
	public Button evButton;

	public void backToGame(){
		gameObject.SetActive(false);
	}

	public void openInspector(GameObject factory){
		gameObject.SetActive(true);
		evButton.onClick.AddListener(factory.GetComponent<Fabrique>().StartEvacuating);
		evButton.onClick.AddListener(backToGame);
	}
}
