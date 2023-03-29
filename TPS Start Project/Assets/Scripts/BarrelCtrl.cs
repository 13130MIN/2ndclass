using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public Texture[] textures;
    private MeshRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponentInChildren<MeshRenderer>();
        int idx = Random.Range(0, textures.Length);
        render.material.mainTexture = textures[idx];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
