using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ConversationData : ScriptableObject
{
    [SerializeField] private TaggedImages images;
    [SerializeField] private string jsonFileName;
    [SerializeField] private List<ConversationLine> conversationLines;

    public IEnumerable<ConversationLine> Conversation => conversationLines;
        
    [ContextMenu("PopulateFromJson")]
    private void PopulateFromJson()
    {
        var jsonString = File.ReadAllText(jsonFileName);
        var lines = JsonSerializer.Create()
            .Deserialize<List<Intermediary>>(new JsonTextReader(new StringReader(jsonString)));

        conversationLines = lines?.Select(ToLine).ToList();
    }

    private ConversationLine ToLine(Intermediary line)
    {
        return new ConversationLine
        {
            Image = images.GetImageFromTag(line.ImageTag),
            Text = line.Text
        };
    }
    
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
public class ConversationLine
{
    [field: SerializeField]
    public Image Image { get; set; }
    
    [field:SerializeField]
    public string Text { get; set; }
}