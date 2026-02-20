using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameState : MonoBehaviour
{
    
    [SerializeField] private int state;
    [SerializeField] private bool stateChanged;
	[SerializeField] private GameObject darkness;

    public void CheckState()
    {
        if (stateChanged)
        {
            switch (state)
            {
                case 0:
                    Debug.Log("Loading Room1");
					StartCoroutine(Sleep("Room1"));
                    break;
                case 1:
                    Debug.Log("Loading Room2");
					StartCoroutine(Sleep("Room2"));
                    break;
                case 2:
                    Debug.Log("Loading Room3");
					StartCoroutine(Sleep("Room3"));
					break;
                case 3:
                    Debug.Log("Loading Room4");
                    StartCoroutine(Sleep("Room4"));
                    break;
                case 4:
                    Debug.Log("Loading Room5");
                    StartCoroutine(Sleep("Room5"));
                    break;
                case 5:
                    Debug.Log("State 5");
                    break;
                case 6:
                    Debug.Log("State 6");
                    break;
            }
            stateChanged = false;
        }
    }
    
    public void AdvanceState()
    {
        stateChanged = true;
    }

	IEnumerator Sleep(string nextRoom)
    {
		darkness.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextRoom);
		//darkness.SetActive(false);
    }
}
