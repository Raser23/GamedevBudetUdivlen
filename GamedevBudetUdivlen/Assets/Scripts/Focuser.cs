using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focuser : MonoBehaviour {

    private GameObject previousSelected;
	public FInspectorController inspector;
    public TowerPanel sidePanel;

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
                else
                if (hit.transform.tag == "TowerPlace")
                {
                    TowerPlaceholder tp = hit.collider.gameObject.GetComponent<TowerPlaceholder>();
                    if (!tp.Has_Tower)
                    {
                        sidePanel.openTowerPanel("Build", tp);
                    }
                }
                else
                //print(hit.transform.name);
				if (hit.transform.tag == "Fabrique")
				{
                    //print("Here");  
                    inspector.openInspector(hit.collider.gameObject);
				}
                else
                {
                    //clicknuli prosto taks       
                }

            }
        }
	}
}
