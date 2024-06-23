using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour {
    public InputField nameInputField;
    public Button confirmButton;
    public Text displayText;

    private string playerName;

    void Start() {
        // Adicionar listener ao botão de confirmação
        confirmButton.onClick.AddListener(OnConfirmButtonClick);
    }

    void OnConfirmButtonClick() {
        // Capturar o nome do jogador do campo de entrada de texto
        playerName = nameInputField.text;

        // Exibir o nome do jogador (opcional)
        displayText.text = "Player Name: " + playerName;

        // Você pode agora usar playerName como quiser no seu jogo
        Debug.Log("Player Name: " + playerName);
    }

    public string GetPlayerName() {
        return playerName;
    }
}
