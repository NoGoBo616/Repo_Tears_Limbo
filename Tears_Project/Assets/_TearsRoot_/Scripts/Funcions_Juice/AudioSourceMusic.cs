using System.Collections;
using UnityEngine;

public class AudioSourceMusic : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sonidos;
    public int musica;

    private void Start()
    {
        StartCoroutine(Reproducir());
    }

    IEnumerator Reproducir()
    {
        musica = Random.Range(0, sonidos.Length);
        yield return new WaitForSeconds(3);
        audioSource.clip = sonidos[musica];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        StartCoroutine(Reproducir());
        yield return null;
    }
}
