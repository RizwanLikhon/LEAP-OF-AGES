
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float scrollspeed = 0.5f;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat=GetComponent<SpriteRenderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset+=(Time.deltaTime*scrollspeed)/10f;
        mat.SetTextureOffset("_MainTex",new Vector2(offset,0));
        
    }
}
