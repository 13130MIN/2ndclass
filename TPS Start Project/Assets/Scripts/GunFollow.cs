using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GunFollow : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
}
