using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDebugger : MonoBehaviour
{
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
