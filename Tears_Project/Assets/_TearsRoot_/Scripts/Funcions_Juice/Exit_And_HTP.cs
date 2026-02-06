using UnityEngine;

public class Exit_And_HTP : MonoBehaviour
{
    public GameObject HTP;

    private void Start()
    {
        HTP.SetActive(false);
    }

    public void OnHTP()
    {
        HTP.SetActive(true);
    }

    public void OffHTP()
    {
        HTP.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}