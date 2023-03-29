using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour, IDamageable
{
    public Texture[] textures;
    private MeshRenderer render;

    public GameObject expEffect; //폭발 효과
    private int hitCount = 0;
    private Rigidbody rd;

    public void OnDamage(float damage, Vector3 hitPosition, Vector3 hitNormal)
    {
        if (++hitCount == 3)
        {
            ExpBarrel();
        }
        else
        {
            //밀림
            AttkBarrel(damage, hitNormal);
        }
    }

    private void AttkBarrel(float damage, Vector3 hitNormal)
    {
        rd.AddForce(hitNormal * -1 * damage, ForceMode.Impulse);
    }

    private void ExpBarrel()
    {
        //폭발 효과 파티클 생성 => 인스턴스화
        GameObject exp = Instantiate(expEffect, transform.position, transform.rotation);
        Destroy(exp, 2f);

        rd.mass = 1f;
        rd.AddForce(Vector3.up * 1500);
        Destroy(gameObject, 2f);
    }

    void Start()
    {
        rd = GetComponent<Rigidbody>();
        render = GetComponentInChildren<MeshRenderer>();
        int index = Random.Range(0, textures.Length);
        render.material.mainTexture = textures[index];
    }

    void Update()
    {
        
    }
}
