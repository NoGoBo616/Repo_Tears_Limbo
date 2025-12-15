using UnityEngine;

public class LaPorta : MonoBehaviour
{
    public string[] dialoge;
    public bool canTalk;

    private void OnEnable()
    {
        canTalk = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }

    public void HandleTalk()
    {
        if (canTalk)
        {
            Debug.Log("La puesrta esta hablando");
        }
    }
}
