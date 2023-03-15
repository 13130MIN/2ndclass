using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string fireButtonName = "Fire1";
    public string jumpButtonName = "Jump";
    public string moveHorizontalAxisName = "Horizontal";
    public string moveVerticalAxisName = "Vertical";
    public string reloadButtonName = "Reload";

    public Vector2 moveInput { get; private set; }
    public bool fire { get; private set; }
    public bool reload { get; private set; }
    public bool jump { get; private set; }

    private void Update()
    {
        moveInput = new Vector2(Input.GetAxis(moveHorizontalAxisName), Input.GetAxis(moveVerticalAxisName));
        if (moveInput.sqrMagnitude > 1) moveInput = moveInput.normalized;
    }
}
