using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleSet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene("IngameSpace");
    }

    // Update is called once per frame
    public void Load()
    {
        Debug.Log("Load");
    }

    public void Setting()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void Quit()
    {
        Debug.Log("Quit");
    }
}
