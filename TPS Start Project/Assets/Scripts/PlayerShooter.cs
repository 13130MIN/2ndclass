using UnityEngine;


public class PlayerShooter : MonoBehaviour
{
    public Gun gun;
    private PlayerInput playerInput;
    private PlayerMovement playerMovement;
    private Animator playerAnimator;
    private Camera playerCamera;
    
    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInput = GetComponent<PlayerInput>();
        playerAnimator = GetComponent<Animator>();

        playerInput.OnFirePressed += FireButtonHandle;
    }

    private void Start()
    {

    }

    private void OnEnable()
    {
        gun.gameObject.SetActive(true);
        gun.Setup(this);
    }

    private void OnDisable()
    {
        gun.gameObject.SetActive(false);
    }

    private void FireButtonHandle()
    {
        playerMovement.SetRotation();
        gun.Fire();
    }

    private void FixedUpdate()
    {
        if (playerInput.fire)
        {
            gun.Fire();
        }
        else if (playerInput.reload)
        {
            //Reload();
        }
    }

    private void Update()
    {
        if (playerInput.reload)
        {
            if (gun.Reload()) playerAnimator.SetTrigger("Reload");
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
        
    }

    private void OnAnimatorIK(int layerIndex)
    {

    }
}