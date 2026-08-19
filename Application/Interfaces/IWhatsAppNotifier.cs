namespace Application.Interfaces
{
    /// <summary>
    /// Web-side port of Data/WhatsAppNotifier.cs (desktop) - sends a WhatsApp message via the same
    /// Green API gateway, using the same SystemSettings-stored credentials the desktop admin already
    /// configured (Etmam.SettingsForm's "الإشعارات" section), so there's nothing new to set up.
    ///
    /// Unlike the desktop version, this must never spawn a detached background Task.Run: the caller's
    /// IApplicationDbContext is scoped to the current HTTP request and would be disposed once the
    /// response is sent, so a truly fire-and-forget send racing past the request's end could touch a
    /// disposed context. Callers await this inline instead - it still never lets a notification
    /// failure surface as an error, it just costs the request an extra network round-trip instead of
    /// happening completely out of band.
    /// </summary>
    public interface IWhatsAppNotifier
    {
        /// <summary>Never throws - a disabled/unconfigured setup or a Green API failure is swallowed
        /// silently (the action that triggered the notification has already succeeded and must not be
        /// affected by this).</summary>
        Task SendAsync(string? rawPhoneNumber, string message, CancellationToken ct = default);
    }
}
