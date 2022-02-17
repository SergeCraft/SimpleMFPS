using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSettingsManager : ISettingsManager
{
    
    public ISettings Settings { get; private set; }


    public bool TryLoadSettings()
    {
        try
        {
            Settings = new SimpleSettings();
            if (Settings != null) return true;
            throw new ApplicationException("Settings load failure");
        }
        catch
        {
            return false;
        };
    }

    public bool TrySaveSettings()
    {
        return true;
    }

    public void ResetSettingsToDefault()
    {
        Settings.ResetToDefault();
    }
}
