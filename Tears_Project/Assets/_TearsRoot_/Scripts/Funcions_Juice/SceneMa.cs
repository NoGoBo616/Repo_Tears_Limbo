using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMa : MonoBehaviour
{
    public HearthManagement animations;
    public float side;
    bool toched;

    private void OnEnable()
    {
        animations = FindAnyObjectByType<HearthManagement>();
        animations.OutAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        toched = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        toched = false;
    }

    public void LoadPosition(float lao)
    {
        if (toched) animations.pos = lao;
    }

    public void LoadScene(int sceneToLoad)
    {
        if (toched) StartCoroutine(Saltar(sceneToLoad));
    }

    IEnumerator Saltar(int scene)
    {
        animations.InAnim();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        yield return null;
    }
}
