using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Managers/New Manager(User)")]
public class UserManager : ScriptableObject
{
    [SerializeField] private UserData userData;
    [SerializeField] private string userName;

    public void Awake()
    {
        userData = new UserData();
    }

    public void UpdateUserName(string text)
    {
        userData.UserName = text;
        userName = userData.UserName;
    }
}