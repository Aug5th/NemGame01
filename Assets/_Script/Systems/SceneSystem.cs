using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSystem : PresistentSingleton<SceneSystem>
{
    public TransactionEntry TransactionEntry { get; set; }

    public void SetTransactionEntry(TransactionEntry transactionEntry)
    {
        TransactionEntry = transactionEntry;
    }
}

[Serializable]
public enum TransactionEntry
{
    None,
    East,
    West,
    South,
    North
}

[Serializable]

public enum Scene
{
    None,
    Jungle1,
    Jungle2
}
