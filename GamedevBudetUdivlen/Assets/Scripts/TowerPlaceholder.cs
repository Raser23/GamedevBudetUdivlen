using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceholder : MonoBehaviour {

    public bool Has_Tower = false;

    public void CreateTower()
    {
        print("Menu appears");
        GameObject Tower = Instantiate(Resources.Load("Assault Tower (nice)", typeof(GameObject))) as GameObject;
        Tower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
        Has_Tower = true;
    }
}
