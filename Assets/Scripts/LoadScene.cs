using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void GoToScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
