using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MyMonoBehaviour
{
    [SerializeField] private TransactionEntry _transactionEntry;


    private void Start()
    {
        if(_transactionEntry == SceneSystem.Instance.TransactionEntry)
        {
            PlayerController.Instance.transform.position = transform.position;
        }
    }
}
