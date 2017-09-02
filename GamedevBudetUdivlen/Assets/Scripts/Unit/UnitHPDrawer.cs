using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitHPDrawer:MonoBehaviour {
    public Dictionary<UnitController, RectTransform> hpBars;
    public static UnitHPDrawer instance;
    public GameObject hpBarsObj;
    public GameObject hpBarPrefab;
    public void Awake()
    {
        instance = this;
        hpBars = new Dictionary<UnitController, RectTransform>();
    }

    private void Update()
    {
        foreach(UnitController uc in GameManager.instance.units)
        {
            if(!hpBars.ContainsKey(uc))
            {
                hpBars.Add(uc,createHpBar(uc));
            }
        }
        List<UnitController> delete = new List<UnitController>();
        foreach (UnitController uc in hpBars.Keys)
		{
            if(!GameManager.instance.units.Contains(uc))
            {
                delete.Add(uc);

            }
		}
        foreach(UnitController uc in delete)
        {
            hpBars[uc].GetComponent<HPBar>().DestroySelf();
			hpBars.Remove(uc);
			
        }
        //MoveBars();
    }



    RectTransform createHpBar(UnitController uc)
    {
        GameObject bar = Instantiate(hpBarPrefab);
        bar.transform.SetParent(hpBarsObj.transform);

        HPBar hpbar = bar.gameObject.GetComponent<HPBar>();
        hpbar.hp = uc.stats;
        hpbar.following = uc.HpBarPos;
        hpbar.StartUpdating();

        return bar.GetComponent<RectTransform>();
    }
    public void MoveBars()
    {
        foreach(UnitController uc in hpBars.Keys)
        {
            RectTransform bar = hpBars[uc];
            Vector3 screenPos = GameManager.instance.cam.WorldToScreenPoint(uc.HpBarPos.transform.position);

            bar.position = screenPos; 
            //bar.gameObject.GetComponent<Slider>().value = uc.stats.clampedHP;
        } 
    }
}
