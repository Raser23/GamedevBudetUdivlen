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
    public Focuser focuser;

    public Spawner spawner;

    public int coins = 0;

    public Dictionary<TowerType, GameObject> towerDict;

    public Upgrade buildStart;

    void Awake()
    {
        instance = this;
        towerDict = new Dictionary<TowerType, GameObject>();
        units = new List<UnitController>();
        towerDict[TowerType.Assault] = Resources.Load<GameObject>("Towers/Assault");
        towerDict[TowerType.Arcane] = Resources.Load<GameObject>("Towers/Arcane");
        towerDict[TowerType.Barracks] = Resources.Load<GameObject>("Towers/Barracks");
        towerDict[TowerType.Buffer] = Resources.Load<GameObject>("Towers/Buffer");
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
