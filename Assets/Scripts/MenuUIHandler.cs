using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    // Reference inputfield
    public TMP_InputField inputField;
    public TMP_Text bestText;

    public void SaveName()
    {
       DataManager.Instance.Name = inputField.text;
       DataManager.Instance.currentName = inputField.text;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bestText.text = "Best Score : " + DataManager.Instance.Name + " : " + DataManager.Instance.HighScore;
    }

    public void StartNew()
    {
        SaveName();
        Debug.Log(DataManager.Instance.Name);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }

    public void ResetBestScore()
    {
        DataManager.Instance.Name = inputField.text;
        DataManager.Instance.HighScore = 0;
        DataManager.Instance.SaveNameScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
