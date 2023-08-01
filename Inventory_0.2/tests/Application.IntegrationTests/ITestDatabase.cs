using System.Data.Common;

namespace Inventory_0._2.Application.IntegrationTests;
public interface ITestDatabase
{
    Task InitialiseAsync();

    DbConnection GetConnection();

    Task ResetAsync();

    Task DisposeAsync();
}
