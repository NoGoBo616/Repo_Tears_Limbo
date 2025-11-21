using UnityEngine;

public class Pescao : MonoBehaviour
{
    [SerializeField] float spedPescao;
    [SerializeField] GameObject burbujas;
    [SerializeField] float puntosPes;
    [SerializeField] SpawnDePecawn spawn;

    private void OnEnable()
    {
        spawn = FindAnyObjectByType<SpawnDePecawn>();
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x + spedPescao * Time.deltaTime,transform.position.y);
    }

    public void Pescar()
    {
        Instantiate(burbujas, transform.position, Quaternion.identity);
        spawn.SumarPuntos(puntosPes);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destruct"))
        {
            Destroy(this.gameObject);
        }
    }
}
