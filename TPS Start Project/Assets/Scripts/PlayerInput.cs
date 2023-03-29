using UnityEngine;
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

        if (fire)
        {
            OnFirePressed?.Invoke();
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mousePos, 0.5f);
        Gizmos.DrawWireSphere(mousePos, 0.5f);
    }

    public bool GetMouseWorldPosition(out Vector3 point)
    {
        //point에 마우스 좌표를 넣어주세요
        //ray를 쐈을 때, 맞았으면 true, 안맞으면 false 반환

        //마우스 포인터 위치 받아 ray발사
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        float depth = cam.farClipPlane;

        point = Vector3.zero;

        if (Physics.Raycast(cameraRay, out hit, depth, ground))
        {
            mousePos = hit.point;
            return true;
        }
        else
        {
            return false;
        }
    }
}