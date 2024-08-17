using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [TextArea(3, 10)]
    [SerializeField] private string textContent;
    [SerializeField] private GameObject popup;
    [SerializeField] private TMP_Text popupText;
    [SerializeField] private GameObject staticCard;
    [SerializeField] private GameObject background;

    private void Start()
    {
        var staticText = staticCard.GetComponentInChildren<TMP_Text>();
        staticText.SetText(textContent);
        staticCard.SetActive(false);

        popup.SetActive(true);
        popupText.SetText(textContent);
        var button = popup.GetComponentInChildren<Button>();
        button.onClick.AddListener(OnPopupClose);

        background.SetActive(true);
    }

    public void OnPopupClose()
    {
        popup.SetActive(false);
        staticCard.SetActive(true);
        background.SetActive(false);
    }

    private void OnDestroy()
    {
        var button = popup.GetComponentInChildren<Button>();
        button.onClick.RemoveAllListeners();
    }
}
