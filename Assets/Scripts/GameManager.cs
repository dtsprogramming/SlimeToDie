using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject playerPrefab;
    public GameObject player;

    public int currentScene = 0;

    public int slimeballs = 0;

    public int GravityScale = 30;

    // Player UI
    public TMP_Text scoretext;
    public TMP_Text VentText;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
            //Debug.LogError(message: "I tried to create a second game manager.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // handle UI value
        scoretext.text = slimeballs + "/10";
    }

    public void LoadLevel(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
        // Potentially Dangerous
        currentScene++;
    }

    public void loadLevel(int indexToLoad)
    {
        SceneManager.LoadScene(indexToLoad);
        currentScene = indexToLoad;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentScene += 1);
    }

    public void FlipGravity()
    {
        GravityScale *= -1;
    }
}
