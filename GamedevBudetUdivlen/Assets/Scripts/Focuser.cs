using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focuser : MonoBehaviour {

    private GameObject previousSelected;
	
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GameManager.instance.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Unit")
                {
                    hit.transform.GetComponent<UnitController>().OnFocused();
                    if(previousSelected != null)
                    {
                        previousSelected.GetComponent<UnitController>().OnUnfocused();
                    }
                    previousSelected = hit.transform.gameObject;
                }
            }
        }
	}
}
