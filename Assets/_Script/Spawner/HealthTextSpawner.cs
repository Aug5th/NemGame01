using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class HealthTextSpawner : MyMonoBehaviour
{
    private static HealthTextSpawner instance;
    public static HealthTextSpawner Instance => instance;
    [SerializeField]
    private Transform holder;
    private ObjectPool<FloatingText> healthTextPool;

    protected override void LoadComponents()
    {
        if (instance == null)
            instance = this;
        else
            Debug.LogWarning("HealthTextSpawner is existing");
        LoadHolder();
        base.LoadComponents();
    }

    private void LoadHolder()
    {
        if (holder != null)
            return;
        holder = transform.Find("Holder");
    }
    private void Start()
    {
        InitHealthTextPool();
        //SpawnHealthText("12312", Color.blue);
    }

    private void InitHealthTextPool()
    {
        healthTextPool = new ObjectPool<FloatingText>(() =>
        {
            var healthText = ResourceSystem.Instance.GetFloatingText();
            var prefab = healthText.Prefab;
            return Instantiate(prefab);
        }, healthText =>
        {
            healthText.gameObject.SetActive(true);
        }, healthText =>
        {
            healthText.gameObject.SetActive(false);
        }, healthText =>
        {
            Destroy(healthText.gameObject);
        }, false, 10, 20);
    }

    public virtual FloatingText SpawnHealthText(string text , Color color)
    {
        var healthText = healthTextPool.Get();
        healthText.ResetTimeElapsed();
        healthText.SetPool(healthTextPool);
        var textMeshPro = healthText.GetComponent<TextMeshPro>();
        textMeshPro.text = text;
        textMeshPro.color = color;
        healthText.gameObject.transform.SetParent(holder);
        return healthText;
    }
}
