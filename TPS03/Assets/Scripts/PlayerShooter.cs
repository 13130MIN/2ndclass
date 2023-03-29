using UnityEngine;


public class PlayerShooter : MonoBehaviour
{
    public enum AimState
    {
        Idle,
        HipFire
    }

    public AimState aimState { get; private set; }

    public Gun gun;
    public LayerMask excludeTarget;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private Animator playerAnimator;
    private Camera playerCamera;
    
    private Vector3 aimPoint;
    private bool linedUp => !(Mathf.Abs( playerCamera.transform.eulerAngles.y - transform.eulerAngles.y) > 1f);
    private bool hasEnoughDistance => !Physics.Linecast(transform.position + Vector3.up * gun.fireTransform.position.y,gun.fireTransform.position, ~excludeTarget);
    
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        playerInput.OnFirePressed += FireButtonHandle;
    }

    private void Start()
    {

    }

    //private void OnEnable()
    //{
    //    gun.gameObject.SetActive(true);
    //    gun.Setup(this);
    //}

    //private void OnDisable()
    //{
    //    gun.gameObject.SetActive(false);
    //}

    private void FireButtonHandle()
    {
        playerMovement.SetRotation();   
        gun.Fire();
    }

    private void Update()
    {
        if (playerInput.reload)
        {
            if (gun.Reload()) playerAnimator.SetTrigger("Reload");
            //Reload();
        }
    }

    public void Shoot()
    {

    }

    public void Reload()
    {
        
    }

    private void UpdateAimTarget()
    {
 
    }

    private void UpdateUI()
    {
        if (gun == null || UIManager.Instance == null) return;
        
        UIManager.Instance.UpdateAmmoText(gun.magAmmo, gun.ammoRemain);
        
        UIManager.Instance.SetActiveCrosshair(hasEnoughDistance);
        UIManager.Instance.UpdateCrossHairPosition(aimPoint);
    }

    private void OnAnimatorIK(int layerIndex)
    {

    }
}