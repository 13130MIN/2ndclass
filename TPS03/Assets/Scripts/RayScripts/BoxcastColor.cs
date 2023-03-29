using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class BoxcastColor : MonoBehaviour
{
    float maxD = 100f;
    private LayerMask maskB;

    private void OnDrawGizmos()
    {
        RaycastHit hit;

        //maskB = LayerMask.GetMask("Blue");
        //bool isHtit = Physics.BoxCast(transform.position, transform.lossyScale, transform.forward, out hit,
        //    transform.rotation, maxD, maskB);

        bool isHtit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit,
            maxD);

        if (isHtit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxD);
        }
    }
}
