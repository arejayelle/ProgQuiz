using System.Collections;
using System.Collections.Generic;
using _Runtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private CharacterController controller;
    [SerializeField, Min(0)] private float speed = 5f;
    [SerializeField, Min(0)] private float rotationSpeed = 10f;

    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private Transform groundCheck;
    [SerializeField, Min(0)] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField, Min(0)] private float jumpHeight = 2f;

    private Vector3 movement;
    private Vector3 gravitationalForce;
    private bool isGrounded;
    private bool jumpMomentumCheck;

    private void Update()
    {
        // calculate movement input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 forward = Vector3.ProjectOnPlane(cam.transform.forward, Vector3.up).normalized;
        Vector3 right = Vector3.ProjectOnPlane(cam.transform.right, Vector3.up).normalized;
        movement = right * horizontal + forward * vertical;

        // check if player is trying to move
        if (movement != Vector3.zero)
        {
            // look in the direction of the movement
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), rotationSpeed * Time.deltaTime);
            PlayerManager.instance.animRun(true);
        }
        else
        {
            PlayerManager.instance.animRun(false);
        }

        // check if mario is grounded
        isGrounded = false;
        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, whatIsGround);
        for (int i = 0; i < hitColliders.Length; ++i)
        {
            if (hitColliders[i].gameObject == this.gameObject)
                continue;

            if (!hitColliders[i].isTrigger)
            {
                isGrounded = true;
                break;
            }
        }

        jumpMomentumCheck = jumpMomentumCheck && Input.GetButton("Jump") && !isGrounded;

        // simulate gravity
        if (isGrounded)
        {
            // mario is standing on ground
            gravitationalForce.y = gravity * Time.deltaTime;
            jumpMomentumCheck = true;
            PlayerManager.instance.animJump(false);
        }
        else
        {
            // mario is in the air
            if (!jumpMomentumCheck && gravitationalForce.y > 0)
                gravitationalForce.y = 0;
            else
            {
                gravitationalForce.y += gravity * Time.deltaTime;
            }
        }
        
        // jump
        if (Input.GetButton("Jump") && isGrounded)
        {
            gravitationalForce.y = Mathf.Sqrt(-2 * jumpHeight * gravity);
            AudioAssets.i.marioYa.Play();
            PlayerManager.instance.animJump(true);
        }

        // move mario
        var actualSpeed = isBoosted ? boostedSpeed : speed;
        controller.Move((movement * actualSpeed * Time.deltaTime) + (gravitationalForce * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.collider.gameObject.name);
    }
    
    private bool isBoosted = false;
    [SerializeField, Min(0)] private float boostedSpeed = 8f;
    private float boostStart;
    [SerializeField] private float boostTime = 2f;
    
    private void CheckBoost()
    {
        var deltaTime = Time.time - boostStart;
        if (deltaTime >= boostTime)
        {
            boostStart = -1;
            isBoosted = false;
        }
    }

    public void Boost()
    {
        boostStart = Time.time;
        isBoosted = true;
    }
}
