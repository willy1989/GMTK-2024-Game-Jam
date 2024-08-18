using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private Config config;
    [SerializeField] private TMP_Text levelScoreText;

    private int forceAddedCount;
    private int scaleChangedCount;
    private int levelScore;
    //private int totalScore;

    protected override void OnActiveSceneChanged(Scene prev, Scene next)
    {
        base.OnActiveSceneChanged(prev, next);
        forceAddedCount = 0;
        scaleChangedCount = 0;
        UpdateScore();

        var pmc = FindObjectOfType<PlayerMovementController>(true);
        if (pmc != null)
        {
            pmc.OnForceAdded += OnForceAdded;
        }
        else
        {
            Debug.LogError("PlayerMovementController not found");
        }

        var psc = FindObjectOfType<PlayerScaleController>(true);
        if (psc != null)
        {
            psc.OnScaleChanged += OnScaleChanged;
        }
        else
        {
            Debug.LogError("PlayerScaleController not found");
        }

        var eolz = FindObjectOfType<EndOfLevelZone>(true);
        if (eolz != null)
        {
            eolz.EndOfLevelReachedEvent += OnEndOfLevelReached;
        }
        else
        {
            Debug.LogError("EndOfLevelZone not found");
        }
    }

    public void OnForceAdded()
    {
        forceAddedCount++;
        UpdateScore();
    }

    public void OnScaleChanged()
    {
        scaleChangedCount++;
        UpdateScore();
    }

    void UpdateScore()
    {
        var level = config.GetLevelBySceneName(SceneManager.GetActiveScene().name);

        levelScore = level.BaseScore - (level.MovePenalty * (forceAddedCount + scaleChangedCount));
        levelScore = Mathf.Max(levelScore, 0);
        Debug.Log("[score] level score updated to: " + levelScore);

        levelScoreText.SetText("Level score: " + levelScore);
    }

    public void OnEndOfLevelReached()
    {
        Debug.Log("[score] final level score: " + levelScore);
    }
}
