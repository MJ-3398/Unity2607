using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    public void Back()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
