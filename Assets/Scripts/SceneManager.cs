using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadGame() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
}
