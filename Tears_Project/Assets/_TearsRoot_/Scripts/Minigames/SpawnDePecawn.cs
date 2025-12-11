using System.Collections;
using UnityEngine;

public class SpawnDePecawn : MonoBehaviour
{
    [SerializeField] Vector2[] ubicaciones;
    [SerializeField] GameObject[] peses;
    [SerializeField] float tiempo;
    [SerializeField] Minigame_Timer minijuegoDerPes;

    private void OnEnable()
    {
        StartCoroutine(Aparision());
    }

    IEnumerator Aparision()
    {
        gameObject.transform.position = ubicaciones[Random.Range(0, ubicaciones.Length)];
        Instantiate(peses[Random.Range(0, peses.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(tiempo);
        StartCoroutine(Aparision());
        yield return null;
    }

    public void SumarPuntos(float capturas)
    {
        minijuegoDerPes.puntos = minijuegoDerPes.puntos + capturas;
    }

    public void RestarPuntos()
    {
        minijuegoDerPes.puntos = minijuegoDerPes.puntos - 1;
    }
}
