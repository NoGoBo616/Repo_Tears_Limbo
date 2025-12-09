using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simon_Dice : MonoBehaviour
{
    public Button[] botones;        
    public float tiempoEntrePasos = 0.5f;
    public float tiempoEncendido = 0.4f;
    public float escalaMaximaY = 1.5f;  
    public float animTiempo = 0.2f;
    public Minigame_Timer minigame;
    public GameObject[] gameObjects;

    public List<int> secuencia = new List<int>();
    private int indiceJugador = 0;
    private bool esperandoJugador = false;

    // Guardar colores originales y escalas originales
    private Color[] coloresOriginales;
    private Vector3[] escalasOriginales;

    private void OnEnable()
    {
        coloresOriginales = new Color[botones.Length];
        escalasOriginales = new Vector3[botones.Length];
        for (int i = 0; i < botones.Length; i++)
        {
            coloresOriginales[i] = botones[i].image.color;
            escalasOriginales[i] = botones[i].transform.localScale;
        }

        secuencia.Clear();
        IniciarJuego();
    }

    private void OnDisable()
    {
        for (int i = 0; i < botones.Length; i++)
        {
            botones[i].image.color = coloresOriginales[i];
            botones[i].transform.localScale = escalasOriginales[i];
        }
    }

    public void IniciarJuego()
    {
        secuencia.Clear();
        indiceJugador = 0;
        esperandoJugador = false;

        AñadirPaso();
    }

    void AñadirPaso()
    {
        int nuevoColor = Random.Range(0, botones.Length);
        secuencia.Add(nuevoColor);

        StartCoroutine(ReproducirSecuencia());
    }

    IEnumerator ReproducirSecuencia()
    {
        esperandoJugador = false;
        yield return new WaitForSeconds(1f);

        foreach (int indice in secuencia)
        {
            // Animación del botón
            StartCoroutine(AnimarBoton(indice));

            yield return new WaitForSeconds(tiempoEncendido + tiempoEntrePasos);
        }

        indiceJugador = 0;
        esperandoJugador = true;
    }

    // Llamado por cada botón al hacer clic
    public void PulsarColor(int colorIndex)
    {
        if (!esperandoJugador) return;

        //Cambia el transform.position por la posicion del boton que se pulse en cada momento
        Instantiate(gameObjects[colorIndex], botones[colorIndex].transform.position, Quaternion.identity);

        if (colorIndex == secuencia[indiceJugador])
        {
            indiceJugador++;

            if (indiceJugador >= secuencia.Count)
            {
                esperandoJugador = false;
                minigame.puntos = minigame.puntos + 10;
                Invoke(nameof(AñadirPaso), 1f);
            }
        }
        else
        {
            Debug.Log("GAME OVER");
            IniciarJuego();
            minigame.puntos = minigame.puntos - 5;
        }
    }

    // Animación de crecer y decrecer en Y y cambiar color
    IEnumerator AnimarBoton(int indice)
    {
        Button btn = botones[indice];
        Image img = btn.image;
        Color originalColor = coloresOriginales[indice];
        Vector3 originalScale = escalasOriginales[indice];

        // Cambiar color a blanco
        img.color = Color.lightPink;

        // Animación crecer Y
        float tiempo = 0f;
        while (tiempo < animTiempo)
        {
            float t = tiempo / animTiempo;
            btn.transform.localScale = new Vector3(originalScale.x, Mathf.Lerp(originalScale.y, originalScale.y * escalaMaximaY, t), originalScale.z);
            tiempo += Time.deltaTime;
            yield return null;
        }

        // Animación decrecer Y
        tiempo = 0f;
        while (tiempo < animTiempo)
        {
            float t = tiempo / animTiempo;
            btn.transform.localScale = new Vector3(originalScale.x, Mathf.Lerp(originalScale.y * escalaMaximaY, originalScale.y, t), originalScale.z);
            tiempo += Time.deltaTime;
            yield return null;
        }

        // Restaurar color y escala original
        img.color = originalColor;
        btn.transform.localScale = originalScale;
    }
}
