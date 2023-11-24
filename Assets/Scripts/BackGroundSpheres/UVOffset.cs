using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class UVOffset : MonoBehaviour
{
    [SerializeField] private float _normalizedTextureSize;
    [SerializeField] private int _atlasSize = 5;
    [SerializeField] private int _index;
    
    void OnEnable(){
        UpdatePropertyBlock();
    }

    public void UpdatePropertyBlock(){
        Renderer renderer = GetComponent<Renderer>();
        MaterialPropertyBlock block = new MaterialPropertyBlock();

        renderer.GetPropertyBlock(block);

        float y = _index / _atlasSize;
        float x = _index - (y * _atlasSize);

        block.SetVector("_BaseMap_ST", new Vector4(_normalizedTextureSize, _normalizedTextureSize, x * _normalizedTextureSize, y * _normalizedTextureSize));

        renderer.SetPropertyBlock(block);
    }
}
