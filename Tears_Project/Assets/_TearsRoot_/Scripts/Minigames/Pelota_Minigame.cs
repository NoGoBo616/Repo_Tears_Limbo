using System.Collections;
using UnityEngine;

public class Pelota_Minigame : MonoBehaviour
{
    public Rigidbody2D rb;
    public float time;

    private void OnEnable()
    {
        StartCoroutine(Crono());
    }

    IEnumerator Crono()
    {
        rb.simulated = false;
        yield return new WaitForSeconds(time);
        rb.simulated = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bolita"))
        {
            this.gameObject.SetActive(false);
            this.gameObject.transform.position = new Vector2(Random.Range(-0.1f, -0.11f), 7);
            this.gameObject.SetActive(true);
        }
    }
}
