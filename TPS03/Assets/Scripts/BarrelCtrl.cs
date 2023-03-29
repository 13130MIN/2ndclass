using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour, IDamageable
{
    public Texture[] textures;
    private MeshRenderer render;

    public GameObject expEffect; //���� ȿ��
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
            //�и�
            AttkBarrel(damage, hitNormal);
        }
    }

    private void AttkBarrel(float damage, Vector3 hitNormal)
    {
        rd.AddForce(hitNormal * -1 * damage, ForceMode.Impulse);
    }

    private void ExpBarrel()
    {
        //���� ȿ�� ��ƼŬ ���� => �ν��Ͻ�ȭ
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
