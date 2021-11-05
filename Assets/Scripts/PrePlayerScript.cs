using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrePlayerScript : FragileEntity
{
    public MeleeAttackItem attackItem;

    public Transform respawnTransform;


    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    public float horizontalSpeed = 2.0F;
    public float verticalSpeed = 2.0F;


    void Start()
    {
        characterController = GetComponent<CharacterController>();
        currentHp = initialHp;
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical")   +   transform.right * Input.GetAxis("Horizontal");
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);




        float h = horizontalSpeed * Input.GetAxis("Mouse X");
        float v = - verticalSpeed * Input.GetAxis("Mouse Y");
        transform.Rotate(v, h, 0);

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);



        if (Input.GetMouseButtonDown(0))
        {
            attackItem.TryAttack();
        }
    }


    public override void Die()
    {
        Debug.Log("You Died. Respawning...");

        currentHp = initialHp;
        transform.position = respawnTransform.position;
    }

}
