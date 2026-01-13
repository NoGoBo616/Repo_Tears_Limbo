using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Player_Controller controller;

    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            controller.isGronded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            controller.isGronded = false;
        }
    }
    */

    private void Update()
    {
        controller.isGronded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);
    }
}
