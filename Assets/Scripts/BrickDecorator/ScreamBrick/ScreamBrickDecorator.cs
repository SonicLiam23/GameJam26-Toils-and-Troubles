using UnityEngine;

public class ScreamBrickDecorator : BrickDecorator
{
    public ScreamBrickDecorator(Brick decoratedBrick) : base(decoratedBrick)
    {}

    float timer = 5f;
    bool activated = false;

    AudioSource audio;

    override public void ActivateCurse()
    {
        decoratedBrick.ActivateCurse();
        activated = true;
        audio.PlayOneShot(GameManager.Instance.ScreamSFX, 1f);
        timer = 5.1f;
        Core.spriteRenderer.sprite = GameManager.Instance.ScreamingLoud;
    }

    override public void ApplyCurse()
    {
        if (audio == null) audio = Core.gameObject.AddComponent<AudioSource>();

        decoratedBrick.ApplyCurse();

        Debug.Log("ScreamBrick!");

        Core.spriteRenderer.sprite = GameManager.Instance.ScreamingQuiet;

       

    }

    override public void UpdateCurse()
    {
        decoratedBrick.UpdateCurse();

        timer -= Time.deltaTime;

        if (!activated && timer <= 0f)
        {
            ActivateCurse();
        }

        if (activated)
        {
            if (timer <= 0f) StopEffect();
        }
    }

    public void StopEffect()
    {
        Core.spriteRenderer.sprite = GameManager.Instance.ScreamingQuiet;
        activated = false;
        audio.Stop();
        timer = 20f;
    }


}
