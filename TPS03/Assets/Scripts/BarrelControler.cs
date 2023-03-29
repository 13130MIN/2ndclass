using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BarrelControler : MonoBehaviour
{
    public Texture[] textures;
    private MeshRenderer render;

    void Start()
    {
        render = GetComponentInChildren<MeshRenderer>();
        int index = Random.Range(0, textures.Length);
        render.material.mainTexture = textures[index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
