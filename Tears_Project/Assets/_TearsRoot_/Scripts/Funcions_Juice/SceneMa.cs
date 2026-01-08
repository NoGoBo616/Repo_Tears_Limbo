using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMa : MonoBehaviour
{
    public HearthManagement animations;
    public float side;

    private void OnEnable()
    {
        animations = FindAnyObjectByType<HearthManagement>();
        animations.OutAnim();
    }

    public void LoadPosition(float lao)
    {
        animations.pos = lao;
    }

    public void LoadScene(int sceneToLoad)
    {
        StartCoroutine(Saltar(sceneToLoad));
    }

    IEnumerator Saltar(int scene)
    {
        animations.InAnim();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        yield return null;
    }
}
