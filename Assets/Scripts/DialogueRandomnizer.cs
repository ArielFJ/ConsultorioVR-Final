using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DialogueObject;

public class DialogueRandomnizer : MonoBehaviour
{
    [SerializeField] public TextAsset[] Stories;
    TextAsset Story;

    public TextAsset Randomnizer()
    {
        int u = Random.Range(0, Stories.Length);
        Story = Stories[u];
        return Story;
    }

}
