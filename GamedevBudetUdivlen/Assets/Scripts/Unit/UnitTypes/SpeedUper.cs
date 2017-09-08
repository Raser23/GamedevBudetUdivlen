using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUper : UnitController {

    public float range;
    public GameObject RangeDrawer;

    protected override void Start()
    {
        base.Start();
        RangeDrawer.transform.localScale = new Vector3(range, range, 0.5f);
    }

    protected override void Update()
    {
        base.Update();

        Collider[] cols = Physics.OverlapSphere(transform.position, range, GameManager.instance.unitsMask);
        foreach (Collider col in cols)
        {
            if (col.gameObject == gameObject)
                continue;
            //print(col.name);
            SpeedUp su = col.gameObject.GetComponent<SpeedUp>();
            if(su != null)
            {
                su.ResetWorkingTime();
            }else
            {
                su = col.gameObject.AddComponent<SpeedUp>();

            }
            su.SetInfo(10, 5);
        }
        //print("Уууух бля как быстро");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,range);
    }
}
