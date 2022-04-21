using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (menuName = "Items")]
public class Item : ScriptableObject
{
    public int id;
    public int maxcount;
    public Image itemimage;
}
