using UnityEngine;

public class Object_Script : MonoBehaviour
{
    public HearthManagement manager;
    public int objeto;
    public GameObject indicador;
    public bool recolectable;

    private void OnEnable()
    {
        manager = FindAnyObjectByType<HearthManagement>();
        this.gameObject.SetActive(true);
        indicador.gameObject.SetActive(false);
        recolectable = false;
    }

    private void Update()
    {
        if (manager.objects[objeto] == true)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("tocado");
            recolectable = true;
            indicador.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            recolectable = false;
            indicador.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (recolectable)
        {
            manager.objects[objeto] = true;
            this.gameObject.SetActive(false);
        }
    }
}