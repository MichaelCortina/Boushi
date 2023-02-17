using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ConversationData : ScriptableObject
{
    [SerializeField] private TaggedImages images;
    [SerializeField] private string jsonFilePath;
    [SerializeField] private List<ConversationLine> conversationLines;

    public IEnumerable<ConversationLine> Conversation => conversationLines;

    [ContextMenu("PopulateFromJSON")]
    private void PopulateFromJson() =>
        conversationLines =
            Utils.FromJSON<List<Intermediary>>(jsonFilePath)
                ?.Select(ToLine).ToList();

    private ConversationLine ToLine(Intermediary line) =>
        new(images.GetImageFromTag(line.ImageTag), line.Text);

    [System.Serializable]
    private class Intermediary
    {
        [field: SerializeField]
        public string ImageTag { get; set; }
    
        [field: SerializeField]
        public string Text { get; set; }
    }
}

[System.Serializable]
public sealed class ConversationLine
{
    [SerializeField] private Sprite sprite; 
    [SerializeField] private string text;

    public Sprite Sprite => sprite;
    public string Text => text;
    
    public ConversationLine(Sprite sprite, string text)
    {
        this.sprite = sprite;
        this.text = text;
    }
}