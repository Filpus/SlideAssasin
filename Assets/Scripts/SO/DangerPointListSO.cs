using UnityEngine;

namespace Terains
{
    public class DangerPointList : MonoBehaviour
    {
        public DangerPoint[] DangerPoints;


        public void ActiveSelectedGroup(int id)
        {
            foreach (DangerPoint dangerPoint in DangerPoints)
            {
                if (dangerPoint.groupId == id )
                {
                    dangerPoint.StartPreparing();
                }
            }
        }

        public void MakeProgressForAll()
        {
            foreach (DangerPoint dangerPoint in DangerPoints)
            {
                dangerPoint.MakeProgress();
            }
        }
    }
}