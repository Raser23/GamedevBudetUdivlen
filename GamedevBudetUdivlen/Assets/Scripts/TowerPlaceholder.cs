using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceholder : MonoBehaviour {

    public bool Has_Tower = false;


    public void CreateTower(TowerType type)
    {
        print(GameManager.instance.towerDict[type]);
        GameObject Tower = Instantiate(GameManager.instance.towerDict[type]);
        
        Tower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
        Has_Tower = true;
    }
}
