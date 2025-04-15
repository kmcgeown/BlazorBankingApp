namespace Web.Services;

public class AuthStateService
{
    public string? CurrentUsername { get; private set; }

    public bool IsLoggedIn => !string.IsNullOrEmpty(CurrentUsername);
    
    public event Action? OnChange;

    private const string HardcodedPass = "password";
    
    public Task<bool> LoginAsync(string username, string password)
    {
        if (password == HardcodedPass)
        {
            CurrentUsername = username;
            NotifyStateChanged();
            return Task.FromResult(true);
        }
        
        CurrentUsername = null; 
        return Task.FromResult(false);     
    }

    public Task LogoutAsync()
    {
        CurrentUsername = null;
        NotifyStateChanged();
        return Task.CompletedTask;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}