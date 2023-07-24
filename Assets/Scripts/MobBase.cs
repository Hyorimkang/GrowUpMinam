using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBase : MonoBehaviour
{
    public float mobSpeed =0;
    public Vector2 startPosition;
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*Time.deltaTime*mobSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
