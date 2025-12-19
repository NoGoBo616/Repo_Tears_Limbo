using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Plantica_2 : MonoBehaviour
{
    public GameObject[] neceities;
    public int listado;
    bool pulsado;
    public Minigame_Timer almazenDePuntos;
    public GameObject VFXpos;
    public GameObject VFXneg;

    private void OnEnable()
    {
        pulsado = true;
        StartCoroutine(Selector());
    }

    IEnumerator Selector()
    {
        listado = 0;
        yield return new WaitForSeconds(Random.Range(3,7));
        Debug.Log("preparado");
        listado = Random.Range(1, neceities.Length);
        pulsado = false;
        yield return new WaitForSeconds(5);
        if (!pulsado)
        {
            Debug.Log("fallaste");
            StartCoroutine(Selector());
        }
        else
        {
            Debug.Log("acertaste");
            yield return null;
        }
        yield return null;
    }

    private void Update()
    {
        for (int i = 0; i < neceities.Length; i++)
        {
            neceities[i].SetActive(i == listado);
        }
    }

    public void Sol()
    {
        if (listado == 1)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos + 1;
            Instantiate(VFXpos, transform.position, Quaternion.identity);
        }
        if (listado != 1)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 1;
            Instantiate(VFXneg, transform.position, Quaternion.identity);
        }
        pulsado = true;
        StartCoroutine(Selector());
    }

    public void Agua()
    {
        if (listado == 2)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos + 1;
            Instantiate(VFXpos, transform.position, Quaternion.identity);
        }
        if (listado != 2)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 1;
            Instantiate(VFXneg, transform.position, Quaternion.identity);
        }
        pulsado = true;
        StartCoroutine(Selector());
    }
}
