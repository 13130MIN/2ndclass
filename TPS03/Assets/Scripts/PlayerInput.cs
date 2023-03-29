using Unity.Profiling;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class PlayerInput : MonoBehaviour
{
    public LayerMask ground;
    public Vector3 mousePos { get; private set; }

    public Action OnFirePressed = null;

    public string fireButtonName = "Fire1";
    public string jumpButtonName = "Jump";
    public string moveHorizontalAxisName = "Horizontal";
    public string moveVerticalAxisName = "Vertical";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool jump { get; private set; }

    public Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxis(moveHorizontalAxisName), Input.GetAxis(moveVerticalAxisName));
        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;

        fire = Input.GetButtonDown(fireButtonName);
        reload = Input.GetButtonDown(reloadButtonName);

        if(fire)
        {
            OnFirePressed?.Invoke();
        }
    }
    
    public bool GetMouseWorldPositon(out Vector3 point)
    {
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        
        float depth = cam.farClipPlane;

        point = Vector3.zero;

        if (Physics.Raycast(cameraRay, out hit, depth, ground))
        {
            point = hit.point;
            return true;
        }
        point = Vector3.zero;
        return false;
    }
}