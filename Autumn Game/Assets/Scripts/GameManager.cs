using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float leavesDestroyed;
    [SerializeField] float leavesOnGround;
    [SerializeField] Text coinCounterText;

    SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();

        leavesDestroyed = 0;
        leavesOnGround = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCounterText.text = leavesDestroyed.ToString("0");
        
        if(leavesOnGround >= 10f)
        {
            sceneLoader.LoadGameOverScene();
        }
    }

    public void AddLeafDestroyed()
    {
        leavesDestroyed++;
    }

    public void AddLeafOnGround()
    {
        leavesOnGround++;
    }

    public void RemoveLeafOnGround()
    {
        leavesOnGround--;
    }

}
