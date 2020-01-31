using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public float rate;
    private float index;
    private float timer;
    private float alpha;

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
        index = rate;
        timer = 0.0f;
        alpha = 255f;
    }
    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > index) {
            alpha = Mathf.Abs(alpha - 255f);
            Debug.Log(alpha);
            text.color = new Color(255f, 0f, 0f, alpha);
            index += rate;
        }
    }
}
