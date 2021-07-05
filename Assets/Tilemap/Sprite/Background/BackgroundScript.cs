using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    // Start is called before the first frame update
    MeshRenderer meshRenderer;
    Material mat;
    public float speed = 1;
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        mat.mainTexture.wrapMode = TextureWrapMode.Repeat;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = mat.mainTextureOffset;
        offset.x += Time.deltaTime * speed;
        mat.mainTextureOffset = offset;
    }
}
