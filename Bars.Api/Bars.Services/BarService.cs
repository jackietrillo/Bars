using System;
using System.Collections.Generic;

using Bars.Core.DomainModels;
using Bars.Core.Providers;
using Bars.Data.Repositories;

namespace Bars.Services
{
    internal class BarService: ServiceBase, IBarService
    {
        private readonly IBarRepository _barRepository;

        public BarService(IConfigurationProvider configurationProvider) : base()
        {
            _barRepository = new BarRepository(configurationProvider);
        }

        public IEnumerable<Bar> GetBars()
        {
            Log.Debug("GetBars was called");
            return _barRepository.GetBars();

        }

        public Bar GetBar(string name)
        {
            return _barRepository.GetBar(name);
        }

        public void AddBar(string name)
        {
            if (name == null || name.Trim() == string.Empty)
                throw new ArgumentException("Parameter name cannot be null or empty.");

            _barRepository.AddBar(name);
        }

        public void DeleteBar(string name)
        {
            _barRepository.DeleteBar(name);
        }

        public void UpdateBar(string name)
        {
            _barRepository.UpdateBar(name);
        }
    }
}
