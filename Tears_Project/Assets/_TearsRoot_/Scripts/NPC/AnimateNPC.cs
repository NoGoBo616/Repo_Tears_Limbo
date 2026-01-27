using UnityEngine;

public class AnimateNPC : MonoBehaviour
{
    public Animator[] animator;
    public GameObject[] personajes;
    public int skin;
    public NPC_Dialogue minigame;
    public NPC_Object obgeto;
    public bool tipo;

    private void OnEnable()
    {
        if (tipo)
        {
            minigame = GetComponent<NPC_Dialogue>();
            obgeto = null;
        }
        else
        {
            obgeto = GetComponent<NPC_Object>();
            minigame = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        personajes[skin].SetActive(true);

        if (tipo)
        {
            if(minigame.dialogoAct == 0)
            {
                animator[skin].SetBool("Talk", false);
                Debug.Log("callao");
            }
            if (minigame.dialogoAct != 0)
            {
                animator[skin].SetBool("Talk", true);
                Debug.Log("hablando");
            }
        }
        else
        {
            if (obgeto.dialogoAct == 0)
            {
                animator[skin].SetBool("Talk", false);
                Debug.Log("callao");
            }
            if (obgeto.dialogoAct != 0)
            {
                animator[skin].SetBool("Talk", true);
                Debug.Log("hablando");
            }
        }
    }
}
