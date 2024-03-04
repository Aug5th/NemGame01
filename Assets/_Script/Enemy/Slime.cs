using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyBase
{
    protected override void SetDropItems()
    {
        base.SetDropItems();
        ItemStructure item = new ItemStructure();
        item.ItemCode = ItemCode.Slime;
        item.Quantity = 17;
        dropList.Add(item);
    }
}
