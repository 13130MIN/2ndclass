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
    
    private AudioSource gunAudioPlayer;
    public AudioClip shotClip;
    public AudioClip reloadClip;
    
    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectEffect;
    
    public Transform fireTransform;

    public float damage = 25;
    public float fireDistance = 100f;

    public int ammoRemain = 100;
    public int magAmmo;
    public int magCapacity = 30;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
    
    [Range(0f, 10f)] public float maxSpread = 3f;
    [Range(1f, 10f)] public float stability = 1f;
    [Range(0.01f, 3f)] public float restoreFromRecoilSpeed = 2f;

    private float currentSpread;
    private float currentSpreadVelocity;

    private float lastFireTime;

    public float bulletLineEffectTime = 1f;

    private LayerMask excludeTarget;

    private void Awake()
    {
        bulletLineRenderer = GetComponent<LineRenderer>();
        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
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

    public bool Fire(Vector3 aimTarget)
    {
        //발사시도
        if (state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }

        return false;
    }
    
    private void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        //Physics.Raycast(쏘는 위치, 쏘는 방향, )
        if(Physics.Raycast(fireTransform.position, fireTransform.forward,out hit, fireDistance))
        {
            var target = hit.collider.GetComponent<Damageable>();

            if (target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }
            hitPosition = hit.point;
        }
        else
        {
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPosition));
    }

    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        muzzleFlashEffect.Play();
        shellEjectEffect.Play();
        bulletLineRenderer.SetPosition(0, fireTransform.position);
        bulletLineRenderer.SetPosition(1, hitPosition);
        yield return new WaitForSeconds(bulletLineEffectTime);
        bulletLineRenderer.enabled = false;
    }
    
    public bool Reload()
    {
        return false;
    }

    private IEnumerator ReloadRoutine()
    {
        state = State.Reloading;
        yield return new WaitForSeconds(reloadTime);
        state = State.Ready;
    }

    private void Update()
    {

    }
}