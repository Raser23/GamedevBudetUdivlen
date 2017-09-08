using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipecUnit : UnitController {

    public override void OnCrossNode(Node n)
    {
        
        List<Node> nodes = n.GetAllNodes();
        if(nodes.Count >1){
            //print(n.name);
            SetTargetNode(nodes[0]);
            for (int i = 1; i < nodes.Count;i++)
            {
                GameObject go = Instantiate(gameObject, transform.position, Quaternion.identity,transform.parent);
                UnitController uc = go.GetComponent<UnitController>();
                uc.SetTargetNode(nodes[i]);
                GameManager.instance.OnUnitCreated(uc);
            }

        }
    }
}
