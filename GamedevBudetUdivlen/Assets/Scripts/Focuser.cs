using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Focuser : MonoBehaviour {

    private GameObject previousSelected;
	public FInspectorController inspector;
    public TowerPanel sidePanel;
    public EventSystem es;
	void Update () 
    {
        if (es.IsPointerOverGameObject())
		{
            //Pointer over UI
            //print("da");
			return; // exit out of OnMouseDown() because its over the uGUI
		}
        else

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GameManager.instance.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                switch(hit.transform.tag){
                    case "Unit":
						hit.transform.GetComponent<UnitController>().OnFocused();
						if (previousSelected != null)
						{
							previousSelected.GetComponent<UnitController>().OnUnfocused();
						}
						previousSelected = hit.transform.gameObject;

                        break;
                    case "TowerPlace":
						TowerPlaceholder tp = hit.collider.gameObject.GetComponent<TowerPlaceholder>();
						if (!tp.Has_Tower)
						{
							sidePanel.openTowerPanel("Build", tp);
						}

                        break;
					case "Fabrique":
                        inspector.openInspector(hit.collider.gameObject);
						break;
					case "Spawner":
                        Spawner spw = hit.transform.GetComponent<Spawner>();
                        if(spw.HasNextWave())
                            spw.NextWave();
						break;
                    default:
                        print(hit.transform.gameObject.name);
                        break;

                }


            }
        }
	}
}
