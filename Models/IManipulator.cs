namespace WillDriveByMyselfApp.Models
{
    public interface IManipulator
    {
        void Add(object obj);
        object Get(object obj);
    }
}
