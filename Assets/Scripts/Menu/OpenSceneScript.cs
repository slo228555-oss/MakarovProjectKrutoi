using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenSceneScript : MonoBehaviour
{


    public void OpenScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
