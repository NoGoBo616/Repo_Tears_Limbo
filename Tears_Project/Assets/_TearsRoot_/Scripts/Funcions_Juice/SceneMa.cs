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
        side = lao;
    }

    public void LoadScene(int sceneToLoad)
    {
        StartCoroutine(Saltar(sceneToLoad, side));
    }

    IEnumerator Saltar(int scene, float laito)
    {
        animations.InAnim();
        //animations.pos = laito;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
        yield return null;
    }
}
