using System;
using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }
    public State state { get; private set; }
    
    private PlayerShooter gunHolder;
    private LineRenderer bulletLineRenderer;
    
    private AudioSource audioSource;
    public AudioClip shotClip;
    public AudioClip reloadClip;
    
    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectEffect;
    
    public Transform fireTransform;
    public Transform leftHandMount;

    public float damage = 25;
    public float fireDistance = 100f;

    public int ammoRemain = 100;
    public int magAmmo;
    public int magCapacity = 30;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;

    private float lastFireTime;

    public float bulletLineEffectTime = 0.3f;

    private LayerMask excludeTarget;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        bulletLineRenderer = GetComponent<LineRenderer>();
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    private void Start()
    {
        state = State.Ready;
        magAmmo = magCapacity;
        lastFireTime = 0;
    }

    public void Setup(PlayerShooter gunHolder)
    {

    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    public bool Fire()
    {
        //발사시도
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
        return false;
    }
    
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPos = Vector3.zero;


        //Physics.Raycast(쏘는 위치, 쏘는 방향, out hit, 최대 거리) 
        if (Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            var target = hit.collider.GetComponent<Damageable>();

            if (target != null) 
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPos = hit.point;
        }
        else
        {
            hitPos = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPos));
        magAmmo--;
        if(magAmmo < 0)
        {
            state = State.Empty;    
        }
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        audioSource.clip = shotClip;
        audioSource.Play();

        muzzleFlashEffect.Play();
        shellEjectEffect.Play();
        bulletLineRenderer.SetPosition(0, fireTransform.position); 
        bulletLineRenderer.SetPosition(1, hitPosition);
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.1f);

        bulletLineRenderer.enabled = false;
    }
    
    public bool Reload()
    { 
        if (state == State.Reloading || magAmmo >= magCapacity)
        {
            return false;
        }

        StartCoroutine(ReloadRoutine());
        return true;
    }

    private IEnumerator ReloadRoutine()
    {
        audioSource.clip = reloadClip;
        audioSource.Play();

        state = State.Reloading;
        yield return new WaitForSeconds(reloadTime);
        magAmmo = magCapacity;
        state = State.Ready;
    }

    private void Update()
    {

    }
}