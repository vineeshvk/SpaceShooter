using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject asteroids;
    public Vector3 spawnValue;

    public float startWave, asteroidGap, nextWave,asteroidCount;

    private bool flip = true;

    private int score = 0;
    public Text scoreText;

    void Start ()
    {
        StartCoroutine("Spawn");
        UpdateScore();
       
	}

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(startWave);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                Vector3 spawnposition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                GameObject obj = Instantiate(asteroids, spawnposition, asteroids.transform.rotation);
                if(flip == true)
                {
                    obj.transform.localScale = new Vector3(-obj.transform.localScale.x, obj.transform.localScale.y, obj.transform.localScale.z);
                   flip  = false;
                }
                else
                {
                    flip = true;
                }
                yield return new WaitForSeconds(asteroidGap);
            }
            yield return new WaitForSeconds(nextWave);
        }
    }

    public void Restart()
    {
        Invoke("EndGame",2f);
    }

    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1 );
    }
    public void AddScore()
    {
        score += 10;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }


}