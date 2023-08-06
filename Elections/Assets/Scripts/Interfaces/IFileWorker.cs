using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFileWorker
{
    public object Load(object saveDataByDefault);
    public void Save(object data);
    public void Delete();
}
