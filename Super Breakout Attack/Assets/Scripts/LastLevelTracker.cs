using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelTracker : MonoBehaviour
{
    [SerializeField] GameStatus gameStatus;
    [SerializeField] SceneLoader sceneLoader;
    // cached reference
    Level level;
    

    // Start is called before the first frame update
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameStatus = FindObjectOfType<GameStatus>();
        //gameStatus.UpdateScenes();
        sceneLoader.UpdateSceneIndices();
    }

}
