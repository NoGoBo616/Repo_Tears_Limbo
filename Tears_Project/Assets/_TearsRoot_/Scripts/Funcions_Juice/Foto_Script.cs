using UnityEngine; 
 
public class Foto_Script : MonoBehaviour 
{
    public GameObject indicador;
    public GameObject foto;
    public bool recolectable;

    private void OnEnable()
    {
        indicador.gameObject.SetActive(false);
        recolectable = false;
        foto.gameObject.SetActive(false);
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
            foto.gameObject.SetActive(false);
        }
    }

    public void Interact()
    {
        if (recolectable)
        {
            foto.gameObject.SetActive (true);
        }
    }

    public void Deselect()
    {
        foto.gameObject.SetActive(false);
    }
} 
 