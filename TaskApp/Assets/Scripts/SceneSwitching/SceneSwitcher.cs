using UnityEngine.SceneManagement;

namespace SceneSwitch
{
    public class SceneSwitcher
    {
        public SceneSwitcher() { }

        public void SwitchScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
