using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
public void Lev1()
{
    SceneManager.LoadScene(1);
}
public void Lev2()
{
    SceneManager.LoadScene(2);
}
}
