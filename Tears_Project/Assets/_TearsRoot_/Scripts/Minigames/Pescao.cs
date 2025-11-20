using UnityEngine;

public class Pescao : MonoBehaviour
{
    [SerializeField] float spedPescao;
    [SerializeField] GameObject burbujas;

    void Update()
    {
        transform.position = new Vector2(transform.position.x + spedPescao * Time.deltaTime,transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(burbujas, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
