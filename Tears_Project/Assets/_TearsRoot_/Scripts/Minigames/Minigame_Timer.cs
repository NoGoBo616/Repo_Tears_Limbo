using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Minigame_Timer : MonoBehaviour
{
    public float timeCrono;
    public Image cronoVista;
    public float puntos;
    public NPC_Dialogue NPC;

    public Animator anim;
    public Rigidbody2D rb;

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
        timeCrono = timeCrono - 1f * Time.deltaTime;
        cronoVista.fillAmount = timeCrono / 60;
        if (timeCrono <= 0)
        {
            StartCoroutine(Apagar());
        }
    }

    private void OnDisable()
    {
        NPC.hearts = NPC.hearts + puntos/10;
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
