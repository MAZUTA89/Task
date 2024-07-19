using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Загружаем бут сцену в первую очередь
/// </summary>
public static class BootPerformer
{
    private static readonly string s_bootStrapSceneName;
    static BootPerformer()
    {
        s_bootStrapSceneName = "BootstrapScene";
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Perform()
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var loadedScene = SceneManager.GetSceneAt(i);

            if(loadedScene.name == s_bootStrapSceneName)
            {
                return;
            }
        }

        SceneManager.LoadScene(s_bootStrapSceneName, LoadSceneMode.Additive);
    }
}
