using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void LateUpdate()
    { 
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
