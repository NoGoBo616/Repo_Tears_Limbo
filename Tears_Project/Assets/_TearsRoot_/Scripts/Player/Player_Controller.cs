using NUnit.Framework;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    [Header("Control")]
    public bool are_you_a_boy_or_a_girl;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] bool flip;
    public bool isGronded;
    [SerializeField] Vector2 moveinput;

    [Header("UI")]
    public float corason;
    public bool pause;

    [Header("Objects")]
    [SerializeField] GameObject boy;
    [SerializeField] GameObject girl;

    [SerializeField] Rigidbody2D playerRb;
    //Animator nya123nyaArigato;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        corason = 50;
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (are_you_a_boy_or_a_girl)
        {
            boy.gameObject.SetActive(true);
            girl.gameObject.SetActive(false);
        }
        else
        {
            boy.gameObject.SetActive(false);
            girl.gameObject.SetActive(true);
        }
        Flip();
    }

    //Movement

    public void HandleMovement(InputAction.CallbackContext context)
    {
        moveinput = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        if (!pause) playerRb.linearVelocity = new Vector3(moveinput.x * speed, playerRb.linearVelocity.y, 0);
    }

    //Flip

    public void Flip()
    {
        if (moveinput.x > 0 && !flip )
        {
            flip = true;
            gameObject.transform.localScale = new Vector2(1, 1);
        }
        if (moveinput.x < 0 && flip)
        {
            flip = false;
            gameObject.transform.localScale = new Vector2(-1, 1);
        }
    }

    //Jump

    public void HandleJump()
    {
        if (!pause)
        {
            if (isGronded)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    //Interact

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            Debug.Log("Interact");
        }
    }
}
