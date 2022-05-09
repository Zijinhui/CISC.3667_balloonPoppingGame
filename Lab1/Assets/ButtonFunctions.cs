using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] InputField playerNameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instruction() {
        SceneManager.LoadScene("Instruction");
    }

    public void Play() {
        string s = playerNameInput.text;
        PersistentData.Instance.SetName(s);
        SceneManager.LoadScene("Level_1");
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

    public void Setting() {
        SceneManager.LoadScene("Setting");
    }
}
