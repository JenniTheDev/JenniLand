using UnityEngine;
using UnityEngine.UI;

public class InputWindow : MonoBehaviour
{
    [SerializeField] private UserManager userManager;
    [SerializeField] private string textInput;

    public void SaveUserName(string input)
    {
        // var name = this.GetComponent<InputField>().;
        userManager.UpdateUserName(input);
        textInput = input;
    }
}