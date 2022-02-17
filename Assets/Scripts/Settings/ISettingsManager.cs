

public interface ISettingsManager
{
    /// <summary>
    /// Actual loaded settings
    /// </summary>
    public ISettings Settings { get; }
    

    /// <summary>
    /// Tries to load settings
    /// </summary>
    /// <returns>If successful, returns true, else returns false</returns>
    public bool TryLoadSettings();

    /// <summary>
    /// Tries to save settings to manager-specified type of storage
    /// </summary>
    /// <returns>If successful, returns true, else returns false</returns>
    public bool TrySaveSettings();

    /// <summary>
    /// Drops game config to Settings-specified default
    /// </summary>
    public void ResetSettingsToDefault();
}
