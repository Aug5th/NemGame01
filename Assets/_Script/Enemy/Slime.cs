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
        item.Amount = 2;
        dropList.Add(item);
    }
}
