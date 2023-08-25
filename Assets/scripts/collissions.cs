using UnityEngine;
using UnityEngine.SceneManagement;
public class collissions : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip death;
    [SerializeField] float delay = 1f;
    AudioSource audioSource;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "friendly":
                Debug.Log("the ship has collided with the launcher");
                break;
            case "Finish":
                startsuccessssequence();
                break;
            case "fuel":
                Debug.Log("the ship has collided with the fuel cell");
                break;
            default:
                startcrashsequence();
                break;
        }
    }
    void startsuccessssequence()
    {
        audioSource.PlayOneShot(success);
        GetComponent<movement>().enabled = false;
        Invoke("loadnextlevel", delay);
    }
    void startcrashsequence()
    {
        audioSource.PlayOneShot(death);
        GetComponent<movement>().enabled = false;
        Invoke("reloadlevel1", delay);
    }
    void loadnextlevel()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        int nextsceneindex = currentsceneindex + 1;
        if(nextsceneindex == SceneManager.sceneCountInBuildSettings)
        {
            nextsceneindex = 0;
        }
        SceneManager.LoadScene(nextsceneindex);
    }
    void reloadlevel1()
    {
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
}
