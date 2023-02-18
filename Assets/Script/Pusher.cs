using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 stratPosition;

    public float amplitube;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        stratPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float z = amplitube * Mathf.Sin(Time.time * speed);
        transform.localPosition = stratPosition + new Vector3(0, 0, z);
    }
}
