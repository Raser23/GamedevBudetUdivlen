using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Units/Wave", order = 1)]
public class Wave:ScriptableObject 
{
    public List<GameObject> units;

    Queue<GameObject> unts;
    public GameObject getUnit()
    {
        if (unts == null)
            unts = new Queue<GameObject>(units);
        return unts.Dequeue();
    }
    public int unspawnedUnits{
        
		get
		{
			if (unts == null)
				unts = new Queue<GameObject>(units);
            return unts.Count; }
    }
    public void Reset()
    {
        unts = null;
    }
}
