using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRayCaster1 : MonoBehaviour
{
    float maxDis = 10f;
    private LayerMask maskBlue;
    public Material mt;
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        GameObject obj;

        maskBlue = LayerMask.GetMask("Blue");
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, maxDis, maskBlue);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);

            obj = hit.collider.gameObject;
            obj.GetComponent<MeshRenderer>().material = mt;
        }
        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * maxDis);
        }
    }
}
