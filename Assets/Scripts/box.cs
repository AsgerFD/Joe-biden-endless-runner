using UnityEngine;

[CreateAssetMenu(fileName = "NewBox", menuName = "Box/NewBox")]
public class Box : ScriptableObject
{
    public int id;
    public string sender;
    public string receiver;
    public string adress;
    public double weight;
    public Sprite img;
}