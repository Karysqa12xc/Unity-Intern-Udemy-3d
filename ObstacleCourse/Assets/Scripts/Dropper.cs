using System.Diagnostics.Tracing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField]
    float timeToWait = 5f;
    new MeshRenderer renderer;
    new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {

        renderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        renderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeToWait)
        {
            rigidbody.useGravity = true;
            renderer.enabled = true;
        }
    }
}
