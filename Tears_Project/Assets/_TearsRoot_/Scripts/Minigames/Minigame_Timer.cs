using UnityEngine;
using UnityEngine.UI;

public class Minigame_Timer : MonoBehaviour
{
    public float timeCrono;
    public Image cronoVista;
    public float puntos;
    public NPC_Dialogue NPC;

    private void OnEnable()
    {
        timeCrono = 60;
    }

    private void Update()
    {
        timeCrono = timeCrono - 1f * Time.deltaTime;
        cronoVista.fillAmount = timeCrono / 60;
        if (timeCrono <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        NPC.hearts = NPC.hearts + puntos/10;
        puntos = 0;
    }
}
