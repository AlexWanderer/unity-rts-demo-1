using UnityEngine;
using System.Collections;

using RTS;

public class MainMenu : Menu {

    protected override void SetButtons() {
        buttons = new string[] { "New Game", "Load Game", "Change Player", "Quit Game" };
    }

    protected override void HandleButton(string text) {
        base.HandleButton(text);
        switch (text) {
            case "New Game":
                NewGame();
                break;
            case "Load Game":
                LoadGame();
                break;
            case "Change Player":
                ChangePlayer();
                break;
            case "Quit Game":
                ExitGame();
                break;
        }
    }

    protected override void HideCurrentMenu() {
        base.HideCurrentMenu();
        GetComponent<MainMenu>().enabled = false;
    }

    private void NewGame() {
        ResourceManager.MenuOpen = false;
        Application.LoadLevel("Map");

        // Make sure that the loaded level runs at normal speed
        Time.timeScale = 1.0f;
    }

    private void ChangePlayer() {
        GetComponent<MainMenu>().enabled = false;
        GetComponent<SelectPlayerMenu>().enabled = true;
        SelectionList.LoadEntries(PlayerManager.GetPlayerNames());
    }

    void OnLevelWasLoaded() {
        Screen.showCursor = true;
        if (PlayerManager.GetPlayerName() == "") {
            // No player yet selected so enabled SetPlayerMenu
            GetComponent<MainMenu>().enabled = false;
            GetComponent<SelectPlayerMenu>().enabled = true;
        } else {
            // Player selected so enable MainMenu
            GetComponent<MainMenu>().enabled = true;
            GetComponent<SelectPlayerMenu>().enabled = false;
        }
    }
}
