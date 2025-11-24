using UnityEngine;

public class Movement : MonoBehaviour
{
    HK_Input input;
    Sensors sensors;
    PlayerStats stats;
    Rigidbody2D body;
    HK_Animation animation;

    public bool Grounded { get; private set; }
    public bool Rolling { get; private set; }
    public int FacingDirection { get; private set; } = 1;

    float rollTimer;
    float rollDuration = 8f / 14f;

    void Start()
    {
        input = GetComponent<HK_Input>();
        sensors = GetComponent<Sensors>();
        stats = GetComponent<PlayerStats>();
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<HK_Animation>();
    }

    void Update()
    {
        UpdateGroundState();
        HandleFacing();
        HandleMovement();
        HandleJump();
        HandleRoll();
    }

    void UpdateGroundState()
    {
        Grounded = sensors.Ground.State();
    }

    void HandleFacing()
    {
        if (input.Horizontal > 0) FacingDirection = 1;
        else if (input.Horizontal < 0) FacingDirection = -1;

        GetComponent<SpriteRenderer>().flipX = (FacingDirection == -1);
    }

    void HandleMovement()
    {
        if (!Rolling)
        {
            // Normal movement
            body.linearVelocity = new Vector2(input.Horizontal * 7 * stats.Agility, body.linearVelocity.y);
        }
    }

    void HandleJump()
    {
        if (input.Jump && Grounded && !Rolling)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, 15 * stats.Agility);
            sensors.Ground.Disable(0.2f);
            
        
        }
    }

    void HandleRoll()
    {
        // Start rolling
    if (input.Roll && !Rolling && !sensors.IsWallSliding()&& Grounded)
    {
        Rolling = true;
        rollTimer = 0f;
        animation.HandleRollAnimation();  // Trigger roll animation once
    }

    // Rolling in progress
    if (Rolling)
    {
        rollTimer += Time.deltaTime;

        // Apply rolling movement
        body.linearVelocity = new Vector2(FacingDirection * 10 * stats.Agility, body.linearVelocity.y);

        // Stop rolling after duration
        if (rollTimer >= rollDuration)
        {
            Rolling = false;
        }
    }
    }
}
