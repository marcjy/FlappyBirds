using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ObstacleGenerator ObstacleGenerator;
    public UIManager UIManager;
    public PlayerController Player;

    private void Awake()
    {
        UIManager.OnPlayAgain += HandlePlayAgain;
    }

    private void HandlePlayAgain(object sender, System.EventArgs e)
    {
        ClearGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartGame()
    {
        ObstacleGenerator.StartGenerator();
        Player.ResetPosition();
    }

    private void ClearGame()
    {
        ObstacleGenerator.StopGenerator();
        ObstacleGenerator.DestroyExistingObstacles();
    }

}
