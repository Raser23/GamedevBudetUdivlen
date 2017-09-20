using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlaceholder : MonoBehaviour {

    public Upgrade currentTowerUpgrade;

    private GameObject prevTower;
    private GameObject currentTower;

    public bool HasUpgrade{
        get { return currentTowerUpgrade.next.Count > 0; }
    }

    private void Start()
    {
        prevTower = null;
    }

    public void CreateTower(TowerType type)
    {
        print(GameManager.instance.towerDict[type]);

    }

    public void UpgradeTower(int index)
    {
        print("upgrading");
        List<Upgrade> next = currentTowerUpgrade.next;
        UpgradeTo(next[index]);

    }
    void UpgradeTo(Upgrade upgrd)
    {
        currentTowerUpgrade = upgrd;
        prevTower = currentTower;

        if (prevTower != null)
            Destroy(prevTower);

        currentTower = Instantiate(upgrd.prefab);

		currentTower.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 2);
    }


}
