using System.Threading.Tasks;

namespace UstSoft.EnglishTraining.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
