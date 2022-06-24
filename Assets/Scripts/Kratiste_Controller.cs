using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kratiste_Controller : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody2d;

    bool crafting;
    Vector2 inputMovement;
    float entitySpeed = 1.5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigidbody2d.velocity = inputMovement * entitySpeed * 100.0f * Time.fixedDeltaTime;

        if (inputMovement.magnitude != 0.0f) animator.SetBool("Moving", true);
        else animator.SetBool("Moving", false);
        animator.SetBool("Crafting", crafting);
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) { 
            inputMovement = Vector2.zero;
            crafting = true;
        }
        else crafting = false;

        if (crafting) return;

        inputMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
