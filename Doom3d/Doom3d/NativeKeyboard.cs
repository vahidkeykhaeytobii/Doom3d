﻿/// <summary>
/// Codes representing keyboard keys.
/// </summary>
/// <remarks>
/// Key code documentation:
/// http://msdn.microsoft.com/en-us/library/dd375731%28v=VS.85%29.aspx
/// </remarks>
internal enum KeyCode : int
{
    Space = 0x20,
    Left = 0x25,
    Right = 0x27,
    Escape = 0x1B,
    F10 = 0x79
}

/// <summary>
/// Provides keyboard access.
/// </summary>
internal static class NativeKeyboard
{
    /// <summary>
    /// A positional bit flag indicating the part of a key state denoting
    /// key pressed.
    /// </summary>
    private const int KeyPressed = 0x8000;

    /// <summary>
    /// Returns a value indicating if a given key is pressed.
    /// </summary>
    /// <param name="key">The key to check.</param>
    /// <returns>
    /// <c>true</c> if the key is pressed, otherwise <c>false</c>.
    /// </returns>
    public static bool IsKeyDown(KeyCode key)
    {
        return (GetKeyState((int)key) & KeyPressed) != 0;
    }

    /// <summary>
    /// Gets the key state of a key.
    /// </summary>
    /// <param name="key">Virtuak-key code for key.</param>
    /// <returns>The state of the key.</returns>
    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern short GetKeyState(int key);
}