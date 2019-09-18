using DataService.Entity;
using DataService.Infrastructure;

namespace DataService.Repository
{

    public interface IConfigurationRepository : IRepository<Configuration>
    {
    }

    public class ConfigurationRepository : Repository<Configuration>, IConfigurationRepository
    {
    }
}
