using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //Set the name in the inspector pls ty
    public string targetScene;

    private void OnTriggerEnter(Collider other)
    {     
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}