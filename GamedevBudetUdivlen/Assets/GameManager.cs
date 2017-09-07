using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public List<UnitController> units;
    public Camera cam;

    public LayerMask unitsMask;

    public int coins = 0;

    void Awake()
    {
        instance = this;
        units = new List<UnitController>();
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
