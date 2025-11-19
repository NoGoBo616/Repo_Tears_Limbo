using UnityEngine;

public class HeartsManager : MonoBehaviour
{
    public float hearts;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        hearts = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
