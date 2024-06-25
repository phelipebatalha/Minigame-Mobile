using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour {
    public InputField nameInputField;
    public Button confirmButton;
    public Text displayText;
    public static PlayerNameInput PlayerNameInstance;

    private string playerName;

    void Awake()
    {
        if(PlayerNameInstance == null)
        PlayerNameInstance = this;
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start() {
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }

    void OnConfirmButtonClick() {
        playerName = nameInputField.text;

        displayText.text = "Player Name: " + playerName;

        Debug.Log("Player Name: " + playerName);
    }

    public string GetPlayerName() {
        return playerName;
    }
}
