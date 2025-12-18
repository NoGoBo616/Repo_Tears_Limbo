using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Plantica_2 : MonoBehaviour
{
    public GameObject[] neceities;
    public int listado;
    public Minigame_Timer almazenDePuntos;
    public GameObject VFXpos;
    public GameObject VFXneg;

    private void OnEnable()
    {
        StartCoroutine(Selector());
    }

    IEnumerator Selector()
    {
        listado = 0;
        yield return new WaitForSeconds(Random.Range(3,7));
        listado = Random.Range(1, neceities.Length);
        yield return new WaitForSeconds(5);
        StartCoroutine(Selector());
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
            almazenDePuntos.puntos = almazenDePuntos.puntos + 2;
            Instantiate(VFXpos, transform.position, Quaternion.identity);
        }
        if (listado != 1)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 2f;
            Instantiate(VFXneg, transform.position, Quaternion.identity);
        }
    }

    public void Agua()
    {
        if (listado == 2)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos + 2;
            Instantiate(VFXpos, transform.position, Quaternion.identity);
        }
        if (listado != 2)
        {
            almazenDePuntos.puntos = almazenDePuntos.puntos - 2f;
            Instantiate(VFXneg, transform.position, Quaternion.identity);
        }
    }
}
