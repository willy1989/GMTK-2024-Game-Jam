using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string textContent;
    [SerializeField] private GameObject popup;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private GameObject staticCard;
    [SerializeField] private GameObject generalCard;
    [SerializeField] private GameObject background;

    public event UnityAction OnTutorialOpened;
    public event UnityAction OnTutorialClosed;

    // TODO: only show popup on first try of level?
    private void Start()
    {
        var staticText = staticCard.GetComponentInChildren<TMP_Text>();
        staticText.SetText(textContent);
        staticCard.SetActive(false);
        generalCard.SetActive(false);

        popup.SetActive(true);
        popupText.SetText(textContent);
        var button = popup.GetComponentInChildren<Button>();
        button.onClick.AddListener(OnPopupClose);

        background.SetActive(true);
        OnTutorialOpened?.Invoke();
    }

    public void OnPopupClose()
    {
        popup.SetActive(false);
        staticCard.SetActive(true);
        generalCard.SetActive(true);
        background.SetActive(false);
        OnTutorialClosed?.Invoke();
    }

    private void OnDestroy()
    {
        var button = popup.GetComponentInChildren<Button>();
        button.onClick.RemoveAllListeners();
    }
}
