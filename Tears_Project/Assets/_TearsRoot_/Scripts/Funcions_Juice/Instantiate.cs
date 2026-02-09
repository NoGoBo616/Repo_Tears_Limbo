using Unity.VisualScripting;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject prefab;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Obtiene el primer punto de contacto
        ContactPoint2D contact = collision.contacts[0];

        // Instancia el prefab en ese punto
        Instantiate(prefab, contact.point, Quaternion.identity);
    }

}
