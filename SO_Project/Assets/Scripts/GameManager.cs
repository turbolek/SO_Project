using Eflatun.SceneReference;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private SceneReference[] _scenesToLoad;

    private void Start()
    {
        StartGamepaly();
    }

    public async void StartGamepaly()
    {
        List<AsyncOperation> loadOperations = new List<AsyncOperation>();

        foreach (SceneReference scene in _scenesToLoad)
        {
            if (scene != null && SceneManager.GetSceneByBuildIndex(scene.BuildIndex) != null)
            {
                loadOperations.Add(SceneManager.LoadSceneAsync(scene.BuildIndex, LoadSceneMode.Additive));
            }
        }

        while (loadOperations.Count > 0)
        {
            for (int i = loadOperations.Count - 1; i >= 0; i--)
            {
                if (loadOperations[i].isDone)
                {
                    loadOperations.RemoveAt(i);
                }
            }

            await Task.Yield(); 
        }
    }
}
