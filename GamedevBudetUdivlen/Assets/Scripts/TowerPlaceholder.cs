using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceholder : MonoBehaviour {

    Camera cam;
    bool Has_Tower = false;
    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        if (!Has_Tower)
        {
            Ray ray = GameManager.instance.cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    CreateTower();
                }
            }
        }
    }

    void CreateTower()
    {
        print("Menu appears");
        GameObject Tower = Instantiate(Resources.Load("Assault Tower (nice)", typeof(GameObject))) as GameObject;
        Tower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);

        Has_Tower = true;
    }
}
