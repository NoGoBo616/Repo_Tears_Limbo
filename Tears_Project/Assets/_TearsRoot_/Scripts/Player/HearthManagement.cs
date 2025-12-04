using UnityEngine;

public class HearthManagement : MonoBehaviour
{
    public float hearts;

    private void OnEnable()
    {
        hearts = 50;
        DontDestroyOnLoad(this.gameObject);
    }
}
