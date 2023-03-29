using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBoxCast : MonoBehaviour
{
    float maxDis = 10f;
    private LayerMask maskBlue;

    private void OnDrawGizmos()
    {
        RaycastHit hit;

        //maskBlue = LayerMask.GetMask("Blue");

        //bool isHit = Physics.BoxCast(transform.position, transform.lossyScale / 2, transform.forward, out hit,
        //    transform.rotation, maxDis, maskBlue);

        bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, transform.forward, out hit,
            maxDis);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            //Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, transform.lossyScale);
            Gizmos.DrawWireSphere(transform.position + transform.forward * hit.distance, transform.lossyScale.x / 2);
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDis);
        }
    }
}
