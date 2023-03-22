
using UnityEngine;
using UnityEngine.SceneManagement;
public class Win : MonoBehaviour
{

    private void Update()
    {
        
    }

    public string levelToLoad = "";

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
