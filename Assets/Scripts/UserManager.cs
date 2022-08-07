using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Scriptable Objects/Managers/New Manager(User)")]
public class UserManager : ScriptableObject
{
    [SerializeField] private UserData userData;
    private int upperIdLimit = 9999;
    private List<int> usedIds;

    public void Awake()
    {
        userData = new UserData();
    }

    public void UpdateUserName(string text)
    {
        userData.UserName = text;
    }

    public void CreateId()
    {
        userData.Id = Random.Range(0, upperIdLimit);
        if (usedIds.Contains(userData.Id))
        {
            userData.Id = Random.Range(0, upperIdLimit);
        }
        usedIds.Add(userData.Id);
    }
}