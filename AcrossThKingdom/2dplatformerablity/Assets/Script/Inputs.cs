using UnityEngine;

public class HK_Input : MonoBehaviour
{
    public float Horizontal { get; set; }
    
    public bool Jump { get; set; }
    public bool Roll { get; set; }
    public bool Attack { get; set; }
    public bool BlockStart { get; set; }
    public bool BlockEnd { get; set; }
    public bool Hurt { get; set; }
    public bool Death { get; set; }

    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");

        Jump = Input.GetKeyDown(KeyCode.Space);
        Roll = Input.GetKeyDown(KeyCode.LeftShift);
        Attack = Input.GetMouseButtonDown(0);
        BlockStart = Input.GetMouseButtonDown(1);
        BlockEnd = Input.GetMouseButtonUp(1);

        Hurt = Input.GetKeyDown(KeyCode.Q);
        Death = Input.GetKeyDown(KeyCode.E);

    }
}
