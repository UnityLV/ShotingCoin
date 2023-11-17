using UnityEngine;

public class MaterialOffset : MonoBehaviour
{
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;
    public Material imageMaterial;


    void Update()
    {
        imageMaterial.mainTextureOffset = new Vector2(Time.time * scrollSpeedX, Time.time * scrollSpeedY);
    }
}