using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MyMonoBehaviour
{
    [SerializeField] private Scene _scene;
    [SerializeField] private TransactionEntry _transactionEntry;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(_scene.ToString());
            SceneSystem.Instance.SetTransactionEntry(_transactionEntry);
        }
    }
}
