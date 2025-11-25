using UnityEngine;
using UnityEngine.UIElements;

public class Pinball_Controles : MonoBehaviour
{
    public float grados;
    public bool cliked;

    private void Update()
    {
        if (cliked)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, grados);
        }
        else
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void Clicar()
    {

    }
}
