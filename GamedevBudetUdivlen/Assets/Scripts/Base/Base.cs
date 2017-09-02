using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {

    public BaseStats stats;

    public void Start()
    {
        stats.HpBelowZero += OnHpBelowZero;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Unit")
        {
            UnitController uc =  other.transform.gameObject.GetComponent<UnitController>();
            stats.currentHP -= uc.stats.dmgToBase;
            uc.StartToDie();
        }
    }

    void OnHpBelowZero()
    {
        print("У меня плохая новость, ваше хп меньше нуля"); 
    }
}
