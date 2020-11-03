using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Animator anim;
    public CharacterController controller;

    private string moveInputAxis = "Vertical";
    private string turnInputAxis = "Horizontal";

    public float rotationRate = 360;

    public float moveSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("vert", Input.GetAxis("Vertical"));
        float moveAxis = Input.GetAxisRaw(moveInputAxis);
        float turnAxis = Input.GetAxisRaw(turnInputAxis);
        ApplyInput(moveAxis, turnAxis);
    }
    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }
    private void Move(float input)
    {
        transform.Translate(Vector3.forward * input * moveSpeed);
    }
    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
