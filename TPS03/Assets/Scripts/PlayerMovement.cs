using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Animator animator;
    
    private Camera followCam;
    
    public float speed = 6f;
    public float rotationspeed = 4f;

    public float currentSpeed =>
        new Vector2(characterController.velocity.x, characterController.velocity.z).magnitude;
    
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        followCam = Camera.main;
    }

    private void FixedUpdate()
    {
        Move(playerInput.moveInput);
        if (currentSpeed > 0.2f) Rotatation();
    }

    private void Update()
    {
        UpdateAnimation(playerInput.moveInput);
    }

    public void Move(Vector2 moveInput)
    {
        var moveDir = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);
        var veloicty = moveDir * speed;
        characterController.Move(veloicty * (Time.deltaTime));
    }

    public void Rotatation()
    {
        var targetRotation = followCam.transform.eulerAngles.y; //카메라의 y각도 
        transform.eulerAngles = Vector3.up * targetRotation; //캐릭터를 회전시킨다. 위쪽(0, 1, 0)
    }

    public void SetRotation()
    {   Vector3 target;

        bool isHit = playerInput.GetMouseWorldPositon(out target);

        if (isHit == true)
        {
            Vector3 dir = target - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir.normalized);
        }
    }

    public void Jump()
    {
        
    }

    private void UpdateAnimation(Vector2 moveInput)
    {
        animator.SetFloat("Vertical Move", moveInput.y);
        animator.SetFloat("Horizontal Move", moveInput.x);
    }
}