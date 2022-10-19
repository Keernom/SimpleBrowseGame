using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    LeaderBoard _leaderBoard;
    [SerializeField] TMP_InputField _inputField;

    private void Start()
    {
        _leaderBoard = FindObjectOfType<LeaderBoard>();
        StartCoroutine(SetupRutine());
    }

    IEnumerator SetupRutine()
    {
        yield return LoginRutine();
        yield return _leaderBoard.FetchTopHighscoreRutine();
    }

    public void SetPlayerName()
    {
        if (_inputField == null) return;
        LootLockerSDKManager.SetPlayerName(_inputField.text, (response) =>
        { 
            if (response.success)
            {
                Debug.Log("Successfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name " + response.Error );
            }
        }
        );
    }

    IEnumerator LoginRutine()
    {
        bool done = false;

        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Error");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);
    }
}
