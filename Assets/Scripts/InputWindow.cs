using UnityEngine;
using TMPro;

public class InputWindow : MonoBehaviour
{
    [SerializeField] private UserManager userManager;
    [SerializeField] private TMP_InputField inputField;

    public void SaveUserName(string input)
    {
        userManager.UpdateUserName(inputField.text);
    }
}