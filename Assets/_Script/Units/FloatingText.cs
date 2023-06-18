using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class FloatingText : MyMonoBehaviour
{
    [SerializeField] float timeToLive = 1f;
    [SerializeField] float floatSpeed = 3f;
    [SerializeField] Vector3 floatDirection = new Vector3(0, 1, 0);

    //[SerializeField] Vector3 offset = new Vector3(0, 0.1f, 0);
    [SerializeField] Vector3 randomIntensity = new Vector3(0.5f, 0.1f, 0);
    
    [SerializeField] TextMeshPro textMeshPro;
    float timeElapsed = 0.0f;
    RectTransform rectTransform;
    Color startingColor;
    ObjectPool<FloatingText> pool;

    private void Start()
    {   
        RandomPosition();
        rectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponent<TextMeshPro>();
        startingColor = textMeshPro.color;
        
    }

    public void ResetTimeElapsed()
    {
        timeElapsed = 0.0f;
    }

    public void SetPool(ObjectPool<FloatingText> pool)
    {
        this.pool = pool;
    }

    private void RandomPosition()
    {
        //transform.localPosition += offset;
        transform.localPosition += new Vector3(Random.Range(-randomIntensity.x, randomIntensity.x), 
            Random.Range(-randomIntensity.y, randomIntensity.y),
            Random.Range(-randomIntensity.z, randomIntensity.z));

    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        rectTransform.localPosition += floatDirection * floatSpeed * Time.deltaTime;
        textMeshPro.color = new Color(startingColor.r, startingColor.g, startingColor.b, 1 - (timeElapsed / timeToLive));
        if(timeElapsed > timeToLive)
        {
            pool.Release(this);
        }
    }
}
