using UnityEngine;
using UnityEngine.UI;

public class PauseMenue : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button QuitButton;
    GlobalPlayer globalPlayer;

    // Start is called before the first frame update
    void Start()
    {

        ResumeButton.onClick.AddListener(HandleResumeClicked);
        RestartButton.onClick.AddListener(HandleRestartClicked);
        QuitButton.onClick.AddListener(HandleExitClicked);

    }

    // Update is called once per frame
    void HandleResumeClicked()
    {
        GameManager.Instance.TogglePause();
    }

    void HandleRestartClicked()
    {
        Debug.Log("khgcjgcjgclulu");
        
        GameManager.Instance.ReStartGame();
    }

    void HandleExitClicked()
    {
        GameManager.Instance.ExitGame();

    }
}
