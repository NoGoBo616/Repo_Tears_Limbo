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

    private void OnEnable()
    {
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
        gameObject.SetActive(false);
        yield return null;
    }
}
