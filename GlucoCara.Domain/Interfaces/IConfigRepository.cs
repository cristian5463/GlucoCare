using GlucoCare.Domain.Entities;

namespace GlucoCare.Domain.Interfaces
{
    public interface IConfigRepository
    {
        ConfigEntity GetById(int id);
        IEnumerable<ConfigEntity> GetAll();
        void Add(ConfigEntity config);
        void Update(ConfigEntity config);
        void Delete(int id);
    }
}
