using System.Collections.Generic;

using Bars.Core.DomainModels;

namespace Bars.Services
{
    internal interface IBarService
    {
        IEnumerable<Bar> GetBars();

        Bar GetBar(string name);

        void AddBar(string name);

        void UpdateBar(string name);

        void DeleteBar(string name);
    }
}
