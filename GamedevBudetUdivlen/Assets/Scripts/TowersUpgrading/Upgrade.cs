using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerUpgrade", menuName = "Towers/Upgrade", order = 1)]
public class Upgrade : ScriptableObject {

    public List<Upgrade> next;
    public GameObject prefab;
    public Sprite icon;
}
