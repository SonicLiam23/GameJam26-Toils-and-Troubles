using UnityEngine;

public interface Brick
{
    // curse setup, called when the curse is created
    public void ApplyCurse();

    // Activate the curses effect, this is the main curse behaviour
    public void ActivateCurse();

    // runs every tick
    public void UpdateCurse();

    public BrickCore Core { get; }

}
