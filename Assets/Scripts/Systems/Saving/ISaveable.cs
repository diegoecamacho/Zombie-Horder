using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class SaveDataBase
{
    public string Name;
}

public interface ISaveable
{
    SaveDataBase SaveData();
    void LoadData(SaveDataBase saveData);
}
