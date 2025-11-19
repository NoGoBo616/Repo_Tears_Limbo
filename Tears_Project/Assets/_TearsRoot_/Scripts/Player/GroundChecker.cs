using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public Player_Controller controller;

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
}
