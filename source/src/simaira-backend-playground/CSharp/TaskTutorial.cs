namespace simaira_backend_playground.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class TaskTutorial
    {
        public async Task<IList<string>> GetMenus()
        {
            return new List<string>();
        }

        public Task<IList<string>> GetSubMenus()
        {
            return Task.FromResult<IList<string>>( new List<string>());
        }
    }
}
