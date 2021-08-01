using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Iventory/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public string itemDescription;
    public Sprite image;
    public int hpGiven;
    public int speedGiven;
    public float speedDuration;
    public int price;
}
