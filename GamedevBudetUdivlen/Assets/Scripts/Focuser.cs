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
                if (hit.transform.tag == "TowerPlace")
                {
                    if (!hit.collider.gameObject.GetComponent<TowerPlaceholder>().Has_Tower)
                    {
                        hit.collider.gameObject.GetComponent<TowerPlaceholder>().CreateTower();
                    }
                }

                //print(hit.transform.name);
				if (hit.transform.tag == "Fabrique")
				{
                    //print("Here");  
                    hit.transform.GetComponent<Fabrique>().StartEvacuating();
				}

            }
        }
	}
}
