﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            other.gameObject.GetComponentInParent<UnitController>().StartToDie();
        }
    }
}
