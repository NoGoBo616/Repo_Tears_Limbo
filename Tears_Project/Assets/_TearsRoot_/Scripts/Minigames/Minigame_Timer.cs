using UnityEngine;
using UnityEngine.UI;

public class Minigame_Timer : MonoBehaviour
{
    public float timeCrono;
    public Image cronoVista;

    private void OnEnable()
    {
        timeCrono = 60;
    }

    private void Update()
    {
        timeCrono = timeCrono - 0.01f;
        cronoVista.fillAmount = timeCrono / 60;
        if (timeCrono <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
