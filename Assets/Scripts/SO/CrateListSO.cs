using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu]
public class CrateListSO : ScriptableObject
{

    public Crate[] CratesList;

    public void OpenAll()
    {
        foreach (Crate crate in CratesList)
        {
            crate.Open();
        }
    }

    public void CloseAll()
    {
        foreach (Crate crate in CratesList)
        {
            crate.Close();
        }
    }
}
