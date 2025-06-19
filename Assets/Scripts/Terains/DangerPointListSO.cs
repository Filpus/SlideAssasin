namespace Terains
{
    public class DangerPointListSO
    {
        public DangerPoint[] DangerPoints;

        public void ActiveAll()
        {
            foreach (DangerPoint dangerPoint in DangerPoints)
            {
                dangerPoint.Active();
            }
        }

        public void DisactiveAll()
        {
            foreach (DangerPoint dangerPoint in DangerPoints)
            {
                dangerPoint.Disactive();
            }
        }
    }
}