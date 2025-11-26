using UnityEngine;
using UnityEngine.UIElements;

public class Pinball_Controles : MonoBehaviour
{
    public float gradosOn;
    public float gradosOff;
    public bool cliked;
    public float velocidad = 300f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float objetivo = cliked ? gradosOn : gradosOff;
        float anguloActual = rb.rotation;

        float anguloNuevo = Mathf.MoveTowards(anguloActual, objetivo, velocidad * Time.deltaTime);

        rb.MoveRotation(anguloNuevo);
    }


    public void Click()
    {
        if (cliked)
        {
            cliked = false;
        }
        else
        {
            cliked = true;
        }
    }
}
