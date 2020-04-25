using PlantsApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlantsApi.Services.Initializers
{
    public class RuntimeInitializer
    {
        private readonly IdentityContext identityContext;
        private readonly PlantsContext plantsContext;
        public RuntimeInitializer(IdentityContext identityContext,
                                  PlantsContext plantsContext)
        {
            this.identityContext = identityContext;
            this.plantsContext = plantsContext;
        }

        public void InitializePlants()
        {

        }

        public void InitializePlantStates()
        {

        }

        public void InitializeUsers()
        {

        }

        public void InitializePlantAssignments()
        {

        }

        public void InitializeIdentityUser()
        {

        }


    }
}
