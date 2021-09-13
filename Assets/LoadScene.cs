using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadScene :MonoBehaviour 
{
    public string levelName;

    public int levelNum;



    public void Start()
    {
        
    }

    public void SceneLoad()
    {
        // reload the scene
     //   SceneManager.LoadScene(SceneManager.GetSceneAt(levelNum).name);

        SceneManager.LoadScene(levelNum);
    }
}
