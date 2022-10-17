using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerManager : MonoBehaviour
{
    LeaderBoard _leaderBoard;

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
