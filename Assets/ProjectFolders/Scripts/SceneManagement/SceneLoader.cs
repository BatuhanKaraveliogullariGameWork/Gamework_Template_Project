using UnityEngine;
using UnityEngine.SceneManagement;
using ElephantSDK;

[CreateAssetMenu(fileName = "NewSceneLoader", menuName = "SceneManagement/SceneLoader")]
public class SceneLoader : ScriptableObject
{
    [Header("Events")]
    [SerializeField] private VoidEvent onLevelFailed;
    [SerializeField] private VoidEvent onLevelCompleted;

    [Header("Variables")]
    [SerializeField] private IntVariable elephantLevelCount;
    [SerializeField] private IntVariable playerLevelCount;

    private void OnEnable() 
    {
        onLevelCompleted.AddListener(OnLevelCompleted);
        onLevelFailed.AddListener(OnLevelFailed);
    }

    private void OnDisable() 
    {
        onLevelCompleted.RemoveListener(OnLevelCompleted);
        onLevelFailed.RemoveListener(OnLevelFailed);
    }

    private void OnLevelFailed()
    {
        Elephant.LevelFailed(elephantLevelCount.Value);
        LoadCurrentLevel();
    }

    private void OnLevelCompleted()
    {
        Elephant.LevelCompleted(elephantLevelCount.Value);
        if(playerLevelCount.Value >= 5) LoadRandomLevel();
        else LoadNextLevel();
    }

    public void LoadFirstLevel()
    {
        elephantLevelCount.SetValue(2);
        playerLevelCount.SetValue(1);
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
        Elephant.LevelStarted(elephantLevelCount.Value);
    }

    private void LoadNextLevel()
    {
        elephantLevelCount.Increase(1);
        playerLevelCount.Increase(1);
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
        Elephant.LevelStarted(elephantLevelCount.Value);
    }

    private void LoadCurrentLevel()
    {
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
        Elephant.LevelStarted(elephantLevelCount.Value);
    }

    private void LoadRandomLevel()
    {
        int value = Random.Range(2,6);
        elephantLevelCount.SetValue(value);
        playerLevelCount.Increase(1);
        SceneManager.LoadSceneAsync(elephantLevelCount.Value, LoadSceneMode.Single);
        Elephant.LevelStarted(elephantLevelCount.Value);
    }
}
