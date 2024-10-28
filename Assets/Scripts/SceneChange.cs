using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string sceneName;
    public float x;
    public float y;
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log(x + "x" + y + "y");
            y = player.transform.position.y;
            player.transform.position = new Vector3(x, y, 0);
            SceneManager.LoadScene(sceneName);
        }
    }
}
