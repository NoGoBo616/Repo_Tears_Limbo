using UnityEngine;

public class Points_Pinbal : MonoBehaviour
{
    public float puntosADar;
    public Minigame_Timer contador;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bolita"))
        {
            contador.puntos = contador.puntos + puntosADar;
        }
    }
}
