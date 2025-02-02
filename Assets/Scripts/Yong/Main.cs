using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoSingleton<Main>
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Instance.InitPlayerController();
        JsonManager.Instance.InitJsonManager();
        UIManager.Instance.InitUIManager();
        EventListener.Instance.InitEventListener();
        EnemySpawner.Instance.InitEnemySpawner();
        
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space))
        {
            EventListener.Instance.SendMessage(EventListener.MessageEvent.Message_GetSkill);
        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.Instance.ShowBasicPropUI();
        }
    }
    // 管理游戏整体进程逻辑
    private void GameStart()
    {
        EventListener.Instance.SendMessage(EventListener.MessageEvent.Message_FirstChoose);
        SpriteManager spm = GameObject.Find("SpriteManager").GetComponent<SpriteManager>();
        spm.spawnSprites();
    }
    
}
