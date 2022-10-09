using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class ShowSceneOnFirstStartUp : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (PlayerPrefs.GetInt("FirstStartUp") == 0)
            {
                PlayerPrefs.SetInt("FirstStartUp", 1);
                PlayerPrefs.Save();
                return;
            }
            
            SceneManager.LoadScene(2);
        }
    }
}
