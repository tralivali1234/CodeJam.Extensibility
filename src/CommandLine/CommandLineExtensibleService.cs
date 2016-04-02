using System;
using System.Collections.Generic;

using CodeJam.Extensibility.Instancing;

using JetBrains.Annotations;

namespace CodeJam.Extensibility.CommandLine
{
	/// <summary>
	/// Extensible command line service.
	/// </summary>
	public class CommandLineExtensibleService : CommandLineService
	{
		/// <summary>
		/// Ibitialize instance.
		/// </summary>
		public CommandLineExtensibleService(
				[NotNull] IServiceProvider serviceProvider,
				[NotNull] Func<CommandLineRulesProviderInfo[]> providerInfosGetter,
				CommandQuantifier commandQuantifier)
			: base(() => CreateRules(serviceProvider, providerInfosGetter, commandQuantifier))
		{
			if (serviceProvider == null) throw new ArgumentNullException(nameof(serviceProvider));
			if (providerInfosGetter == null) throw new ArgumentNullException(nameof(providerInfosGetter));
		}

		private static CmdLineRules CreateRules(
			IServiceProvider serviceProvider,
			Func<CommandLineRulesProviderInfo[]> providerInfosGetter,
			CommandQuantifier commandQuantifier)
		{
			var infos = providerInfosGetter();
			var cmdRules = new List<CommandRule>();
			var optRules = new List<OptionRule>();
			foreach (var info in infos)
			{
				var provider = (ICommandLineRulesProvider)info.ProviderType.CreateInstance(serviceProvider);
				cmdRules.AddRange(provider.GetCommands());
				optRules.AddRange(provider.GetOptions());
			}
			return new CmdLineRules(commandQuantifier, cmdRules.ToArray(), optRules.ToArray());
		}
	}
}