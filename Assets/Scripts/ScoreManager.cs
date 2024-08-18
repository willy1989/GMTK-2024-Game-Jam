using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : Singleton<ScoreManager>
{
    [SerializeField] private Config config;
    [SerializeField] private TMP_Text levelScoreText;
    [SerializeField] private TMP_Text bestLevelScoreText;
    [SerializeField] private TMP_Text totalScoreText;

    private int forceAddedCount;
    private int scaleChangedCount;
    private int levelScore;
    private int bestLevelScore;
    private int totalScore;

    private PlayerMovementController pmc;
    private PlayerScaleController psc;
    private EndOfLevelZone eolz;

    // Track best scores for each level to produce an aggregate score 
    private readonly Dictionary<string, int> bestScoreByLevel = new();

    protected override void Init()
    {
        base.Init();
        foreach (var level in config.Levels)
        {
            bestScoreByLevel.Add(level.SceneName, default);
        }
    }

    protected override void OnActiveSceneChanged(Scene prev, Scene next)
    {
        base.OnActiveSceneChanged(prev, next);
        forceAddedCount = 0;
        scaleChangedCount = 0;
        UpdateScore();

        pmc = FindObjectOfType<PlayerMovementController>(true);
        if (pmc != null)
        {
            pmc.OnActionMade += OnForceAdded;
        }
        else
        {
            Debug.LogError("PlayerMovementController not found");
        }

        psc = FindObjectOfType<PlayerScaleController>(true);
        if (psc != null)
        {
            psc.OnActionMade += OnScaleChanged;
        }
        else
        {
            Debug.LogError("PlayerScaleController not found");
        }

        eolz = FindObjectOfType<EndOfLevelZone>(true);
        if (eolz != null)
        {
            eolz.EndOfLevelReachedEvent += OnEndOfLevelReached;
        }
        else
        {
            Debug.LogError("EndOfLevelZone not found");
        }
    }

    protected override void OnSceneUnloaded(Scene scene)
    {
        base.OnSceneUnloaded(scene);

        // Clean up listeners
        pmc.OnActionMade -= OnForceAdded;
        psc.OnActionMade -= OnScaleChanged;
        eolz.EndOfLevelReachedEvent -= OnEndOfLevelReached;
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
        var level = config.GetLevelBySceneName(SceneManager.GetActiveScene().name);
        Debug.Log("[score] final level score: " + levelScore);

        if (levelScore > bestLevelScore)
        {
            bestLevelScore = levelScore;
        }
        bestLevelScoreText.SetText("Level high score: " + bestLevelScore);

        var bestEverLevelScore = bestScoreByLevel[level.SceneName];
        if (bestLevelScore > bestEverLevelScore)
        {
            bestScoreByLevel[level.SceneName] = bestLevelScore;
        }
        Debug.Log("[score] best score by level: " + JsonUtility.ToJson(bestScoreByLevel.ToList()));

        totalScore = 0;
        foreach (var bestScore in bestScoreByLevel.Values)
        {
            totalScore += bestScore;
        }
        Debug.Log("[score] total score: " + totalScore);
        totalScoreText.SetText("Total score: " + totalScore);
    }
}
