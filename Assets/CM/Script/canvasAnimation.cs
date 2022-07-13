using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canvasAnimation : MonoBehaviour
{
    public GameObject ATK_info, DEF_info, Event_HP_info, Trap_HP_info, Enemy_info, Win_info, Lose_info;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseATKinfo()
    {
        ATK_info.SetActive(false);
    }

    public void CloseDEFinfo()
    {
        DEF_info.SetActive(false);
    }

    public void CloseEventHPinfo()
    {
        Event_HP_info.SetActive(false);
    }

    public void CloseTrapHPinfo()
    {
        Trap_HP_info.SetActive(false);
    }

    public void CloseMonsterinfo()
    {
        Enemy_info.SetActive(false);
    }

    public void ReTry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

}
