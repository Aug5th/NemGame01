using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MyMonoBehaviour
{
    [SerializeField]
    private string poolName = "Prefabs";
    [SerializeField]
    protected List<Transform> prefabs;
    [SerializeField]
    protected List<Transform> poolObjects;
    [SerializeField]
    private Transform holder;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //LoadPrefabs();
        LoadHolder();
    }

    private void LoadHolder()
    {
        if (holder != null)
            return;
        holder = transform.Find("Holder");
    }
    public virtual Transform Spawn(int prefabType, Vector3 spawnPosition, Quaternion rotation)
    {
        Transform prefab = GetPrefab(prefabType);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found");
            return null;
        }

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPosition, rotation);
        newPrefab.parent = holder;

        return newPrefab;
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        foreach (Transform poolObject in poolObjects)
        {
            if(poolObject.name == prefab.name)
            {
                poolObjects.Remove(poolObject);
                return poolObject;
            }
        }

        Transform newObject = Instantiate(prefab);
        newObject.name = prefab.name;
        return newObject;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjects.Add(obj);
        obj.gameObject.SetActive(false);
    }

    //protected void LoadPrefabs()
    //{
    //    if (prefabs.Count > 0)
    //        return;

    //    Transform prefabObjects = transform.Find(poolName);
    //    if (prefabObjects != null)
    //    {
    //        foreach (Transform prefab in prefabObjects)
    //        {
    //            prefabs.Add(prefab);
    //        }
    //        HidePrefabs();

    //        Debug.Log(transform.name + " : LoadPrefabs with pool : "+ poolName);
    //    }
    //    else
    //    {
    //        Debug.LogError(transform.name + " : LoadPrefabs nullllll ");
    //    }
    //}

    //protected void HidePrefabs()
    //{
    //    foreach (Transform prefab in prefabs)
    //    {
    //        prefab.gameObject.SetActive(false);
    //    }
    //}

    protected abstract Transform GetPrefab(int prefabType);

}
