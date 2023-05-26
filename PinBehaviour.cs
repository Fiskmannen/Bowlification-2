using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehaviour : MonoBehaviour
{
    public bool standing;
    public Vector3 originPosition;
    public Quaternion originRotation;
    // Start is called before the first frame update
    void Start()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        standing = false;
    }
    public void resetToOrigin()
    {
        transform.position = originPosition;
        transform.rotation = originRotation;
        standing = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
