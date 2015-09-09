using System;
using System.Collections.Generic;

using Bars.Core.DomainModels;
using Bars.Core.Providers;

namespace Bars.Services
{
    public class BarsFacade : IBarsFacade
    {
        private readonly IBarService _barService;

        public BarsFacade(IConfigurationProvider configurationProvider)
        {
            _barService = new BarService(configurationProvider);
        }

        public IEnumerable<Bar> GetBars()
        {
            return _barService.GetBars();
        }

        public Bar GetBar(string name)
        {
            return _barService.GetBar(name);
        }

        public void AddBar(string name)
        {
            _barService.AddBar(name);
        }

        public void DeleteBar(string name)
        {
            _barService.DeleteBar(name);
        }

        public void UpdateBar(string name)
        {
            _barService.UpdateBar(name);
        }
    }
}
