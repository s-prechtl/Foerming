using System;
using TMPro;
using UnityEngine;

public class HoverManager : MonoBehaviour {
    #region Singleton

    public static HoverManager instance;

    private void Awake() {
        if (instance != null) {
            Debug.LogWarning("More than one instance of HoverManager found");
        }

        instance = this;
    }

    #endregion
    
    public TextMeshProUGUI descriptionText;
    public RectTransform descriptionHoverBackground;

    public static Action<string, Vector2> onMouseHoverDescription;
    public static Action onMouseExit;

    private void OnEnable() {
        onMouseHoverDescription += ShowDescription;
        onMouseExit += HideDescription;
    }

    private void OnDisable() {
        onMouseHoverDescription -= ShowDescription;
        onMouseExit -= HideDescription;
    }

    private void Start() {
        HideDescription();
    }
    
    /**
     * Show the description Text at the mouse position
     */
    private void ShowDescription(string description, Vector2 mousePos) {
        descriptionText.text = description;
        descriptionHoverBackground.sizeDelta =
            new Vector2(descriptionText.preferredWidth > 200 ? 200 : descriptionText.preferredWidth,
                descriptionText.preferredHeight);
        
        descriptionHoverBackground.gameObject.SetActive(true);
        float descBgX = descriptionHoverBackground.sizeDelta.x;
        descriptionHoverBackground.transform.position =
            new Vector2(mousePos.x + (descBgX / 2) + (descBgX / 16), mousePos.y);
    }

    /**
     * Hide the description Text
     */
    public void HideDescription() {
        descriptionText.text = default;
        descriptionHoverBackground.gameObject.SetActive(false);
    }
}