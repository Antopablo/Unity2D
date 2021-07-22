using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string mName;

    [TextArea(3,10)]
    public string[] mSentences;

}
