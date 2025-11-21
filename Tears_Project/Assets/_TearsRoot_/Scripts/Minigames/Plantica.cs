using System.Collections;
using UnityEngine;

public class Plantica : MonoBehaviour
{
    public bool agua;
    public SolYAgua botones;
    public Minigame_Timer almazenDePuntos;
    public GameObject indicar_Agua;
    public GameObject indicar_Sol;

    private void OnEnable()
    {
        StartCoroutine(Cambio());
    }

    IEnumerator Cambio()
    {
        if (agua)
        {
            agua = false;
        }
        else
        {
            agua = true;
        }
        yield return new WaitForSeconds(Random.Range(3, 7));
        StartCoroutine(Cambio());
        yield return null;
    }

    private void Update()
    {
        if (!agua)
        {
            indicar_Sol.SetActive(true);
            indicar_Agua.SetActive(false);
        }
        else
        {
            indicar_Sol.SetActive(false);
            indicar_Agua.SetActive(true);
        }

        if (!agua && botones.sun)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos + 0.01f;
        }

        if (agua && botones.sun)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 0.01f;
        }

        if (agua && !botones.sun)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos + 0.01f;
        }

        if (!agua && !botones.sun)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 0.01f;
        }
    }
}
