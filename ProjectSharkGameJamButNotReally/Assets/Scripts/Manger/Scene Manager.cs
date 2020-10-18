using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{
    void Start()
    {
        ScenceManager.LoadScene("Tutorial 1", LoadSceneMode.Additive);
    }
}
