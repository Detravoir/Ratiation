using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    public void Awake()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
