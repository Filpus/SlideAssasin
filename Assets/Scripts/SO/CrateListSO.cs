using System.Security.Cryptography.X509Certificates;
using UnityEngine;

[CreateAssetMenu]
public class CrateList : MonoBehaviour
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

    public void SwitchSelectedGroup(int id)
    {
        foreach (Crate crate in CratesList)
        {
            if (crate.group_id == id)
            {
                crate.SwitchState();
            }
        }
    }
    public void OpenSelectedGroup(int id)
    {
        foreach (Crate crate in CratesList)
        {
            if (crate.group_id == id)
            {
                crate.Open();
            }
        }
    }

    public void CloseSelectedGroup(int id)
    {
        foreach (Crate crate in CratesList)
        {
            if (crate.group_id == id)
            {
                crate.Close();
            }        
        }
    }

}
