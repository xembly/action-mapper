using Microsoft.Extensions.DependencyInjection;
using System;

namespace Xembly.ActionMapper
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddKeyActions(this IServiceCollection services)
		{
			return AddKeyActions(services, Array.Empty<ActionRegister>());
		}

		public static IServiceCollection AddKeyActions(this IServiceCollection services, params ActionRegister[] actionRegisters)
		{
			var keyMapper = ActionRegister.KeyActionMapper();
			foreach (var actionRegister in actionRegisters) keyMapper.Add(actionRegister);
			return services.AddSingleton(keyMapper);
		}
	}
}
