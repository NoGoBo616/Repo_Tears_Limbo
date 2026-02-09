using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_Timer : MonoBehaviour
{
    public float timeCrono;
    public Image cronoVista;
    public float puntos;
    public HearthManagement NPC;
    public TMP_Text puntosText;
    public Animator anim;
    public Rigidbody2D rb;

    private void Awake()
    {
        NPC = FindAnyObjectByType<HearthManagement>();
    }

    private void OnEnable()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;

        // Opcional: Detener cualquier velocidad/fuerza actual
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        anim.SetTrigger("In");
        timeCrono = 60;
    }

    private void Update()
    {
        puntosText.text = (puntos).ToString();
        timeCrono = timeCrono - 1f * Time.deltaTime;
        cronoVista.fillAmount = timeCrono / 60;
        if (timeCrono <= 0)
        {
            StartCoroutine(Apagar());
        }
    }

    private void OnDisable()
    {
        NPC.hearts = NPC.hearts + puntos/5;
        puntos = 0;
    }

    IEnumerator Apagar()
    {
        anim.SetTrigger("Out");
        yield return new WaitForSeconds(2);
        rb.bodyType = RigidbodyType2D.Dynamic;
        gameObject.SetActive(false);
        yield return null;
    }
}
