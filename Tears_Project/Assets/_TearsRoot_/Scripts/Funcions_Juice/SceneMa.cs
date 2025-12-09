using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMa : MonoBehaviour
{
    public HearthManagement animations;

    private void OnEnable()
    {
        animations = FindAnyObjectByType<HearthManagement>();
        animations.OutAnim();
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
