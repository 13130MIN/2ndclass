using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ColorRay : MonoBehaviour
{
    public float maxDis = 100;
    public LayerMask maskBlue;
    public Material mt;

    GameObject obj;

    private void OnDrawGizmos()
    {
        RaycastHit hit;
        maskBlue = LayerMask.GetMask("Blue");
        bool isHit = Physics.Raycast(transform.position, transform.forward, out hit, maxDis, maskBlue);

        if (isHit )
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
