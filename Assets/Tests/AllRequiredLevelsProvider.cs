using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TestTools;

public class AllRequiredLevelsProvider : IEnumerable<string>
{
    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        var allLevelGUIDs = AssetDatabase.FindAssets("t:Scene", new[] { "Assets/Scenes" });
        foreach (var levelGUID in allLevelGUIDs)
        {
            var levelPath = AssetDatabase.GUIDToAssetPath(levelGUID);
            yield return levelPath;
        }
    }

    public IEnumerator GetEnumerator() => (this as IEnumerable<string>).GetEnumerator();
}