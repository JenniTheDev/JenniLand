using System.Collections.Generic;

[System.Serializable]
public struct UserData
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public Dictionary<string, int> GameHighScores;

    public UserData(int id, string userName = "")
    {
        Id = id;
        UserName = userName;
        GameHighScores = new Dictionary<string, int>();
    }
}