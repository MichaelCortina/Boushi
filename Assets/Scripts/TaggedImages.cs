using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaggedImages : ScriptableObject
{
    [SerializeField] private List<TaggedImage> taggedImages;

    public Image GetImageFromTag(string imageTag)
    {
        return taggedImages.Find(image => image.Tag == imageTag)?.Image;
    }
    
    
    [System.Serializable]
    private class TaggedImage
    {
        public string Tag { get; set; }
        public Image Image { get; set; }
    }
}