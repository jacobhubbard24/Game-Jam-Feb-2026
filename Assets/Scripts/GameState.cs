using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    
    [SerializeField] private int state;
    [SerializeField] private bool stateChanged;

    public void CheckState()
    {
        if (stateChanged)
        {
            switch (state)
            {
                case 0:
                    Debug.Log("Loading Room1");
                    SceneManager.LoadScene("Room1");
                    break;
                case 1:
                    Debug.Log("Loading SampleScene");
                    SceneManager.LoadScene("SampleScene");
                    break;
                case 2:
                    Debug.Log("Loading Room1");
                    SceneManager.LoadScene("Room1");
                    break;
                case 3:
                    Debug.Log("State 3");
                    break;
                case 4:
                    Debug.Log("State 4");
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
}
