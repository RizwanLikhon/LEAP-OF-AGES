using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{
    public int NextLevel;

    // Level move zoned enter, if collider is a Player
    // Move game to another scence

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger Entered");

        if (collision.gameObject.tag == "Player")
        {
            print("Switching Scence to" + NextLevel);
            SceneManager.LoadScene(NextLevel, LoadSceneMode.Single);
        }
    }
}
