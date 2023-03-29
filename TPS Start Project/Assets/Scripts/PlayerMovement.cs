using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    private PlayerInput playerInput;
    private Animator animator;

    private Camera followCam;

    public float speed = 6f;
    public float rotationSpeed = 4;

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
        if (currentSpeed > 0.2f)
        {
            Rotate();
        }
    }

    private void Update()
    {

    }

    public void Move(Vector2 moveInput)
    {
        //갈 방향, 길이 1
        var moveDirection = Vector3.Normalize(transform.forward * moveInput.y + transform.right * moveInput.x);
        var velocity = moveDirection * speed;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Rotate()
    {
        //var targetRoatation = followCam.transform.eulerAngles.y; //카메라의 y 각도
        //transform.eulerAngles = Vector3.up * targetRoatation; //캐릭터를 회전시킨다. 위쪽(0,1,0)
    }

    public void SetRotation()
    {
        Vector3 target;
        bool isHit = playerInput.GetMouseWorldPosition(out target);
        if (isHit)
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
        animator.SetFloat("Horizontal Move",moveInput.x);
    }
}
