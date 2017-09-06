﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "Units/Wave", order = 1)]
public class Wave:ScriptableObject 
{
    public List<GameObject> units;

    public GameObject getUnit(int index)
    {
        return units[index];
    }


}
