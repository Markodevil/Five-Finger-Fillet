using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    // Loads scenes
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
