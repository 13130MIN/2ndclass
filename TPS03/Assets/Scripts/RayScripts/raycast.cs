using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    float maxDis = 100f;
    private LayerMask maskBlue;
    public Material mt;
    private void OnDrawGizmos()
    {
        RaycastHit hit;
        GameObject obj;
        

        maskBlue = LayerMask.GetMask("Blue");
        bool isHtit = Physics.Raycast(transform.position, transform.forward, out hit, maxDis, maskBlue);
        
        if(isHtit) 
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
