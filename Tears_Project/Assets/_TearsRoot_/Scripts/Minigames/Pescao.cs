using UnityEngine;

public class Pescao : MonoBehaviour
{
    [SerializeField] float spedPescao;
    [SerializeField] GameObject burbujas;
    [SerializeField] GameObject pointSum;
    [SerializeField] GameObject pointRes;
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
        Instantiate(pointSum, transform.position, Quaternion.identity);
        spawn.SumarPuntos(puntosPes);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destruct"))
        {
            Instantiate(pointRes, transform.position, Quaternion.identity);
            spawn.RestarPuntos();
            Destroy(this.gameObject);
        }
    }
}
