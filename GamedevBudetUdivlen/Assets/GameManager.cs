using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType{
    Assault,Arcane,Barracks,Buffer
}

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public List<UnitController> units;
    public Camera cam;

    public LayerMask unitsMask;

    public int coins = 0;

    public Dictionary<TowerType, GameObject> towerDict;

    void Awake()
    {
        instance = this;
        units = new List<UnitController>();
        towerDict[TowerType.Assault] = Resources.Load("Towers/Assault", typeof(GameObject)) as GameObject;
        towerDict[TowerType.Arcane] = Resources.Load("Tower/Arcane", typeof(GameObject)) as GameObject;
        towerDict[TowerType.Barracks] = Resources.Load("Tower/Barracks", typeof(GameObject)) as GameObject;
        towerDict[TowerType.Buffer] = Resources.Load("Tower/Buffer", typeof(GameObject)) as GameObject;
    }
	public void OnUnitCreated(UnitController controller)
	{
        units.Add(controller);
	}
	public void OnUnitDestroyed(UnitController controller)
	{
        units.Remove(controller);
	}

}
