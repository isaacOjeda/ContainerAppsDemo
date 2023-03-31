using ContainerAppsDemo.Api.Infrastructure.Services;

namespace ContainerAppsDemo.Api.Common.Services;

public interface ICurrencyProvider
{
    Task<BanxicoResponse> GetDollarValue();
}