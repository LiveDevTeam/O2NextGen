using NUnit.Framework;
using O2NextGen.CertificateManagement.Domain.Data;
using O2NextGen.CertificateManagement.Infrastructure.Data;

namespace Tests.O2NextGen.CertificateManagement.Infrastructure.Data.Queries
{
    public class QueryHandlerTests
    {
        private static readonly Type QueryType = typeof(IQuery<>);
        private static readonly Type QueryHandlerType = typeof(IQueryHandler<,>);

        [Test]
        public void AllDomainQueriesHaveMatchingInfrastructureHandlerTest()
        {
            var existingQueries = GetAllQueries();
            var existingQueryHandlers = GetAllQueryHandlers();
    
            //Todo: convert to nunit tests
            // Assert.All(
            //     existingQueries,
            //     query => existingQueryHandlers.Single(handler => handler.GenericTypeArguments[0] == query));
        }

        private static IEnumerable<Type> GetAllQueries()
        {
            return QueryType.Assembly
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().SingleOrDefault(IsQueryInterface) != null);

            static bool IsQueryInterface(Type @interface)
                => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == QueryType;
        }

        private static IEnumerable<Type> GetAllQueryHandlers()
        {
            var infrastructureAssembly = typeof(CGenDbContext).Assembly;

            return infrastructureAssembly
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().SingleOrDefault(IsQueryHandlerInterface) != null)
                .Select(t => t.GetInterfaces().Single(IsQueryHandlerInterface));

            static bool IsQueryHandlerInterface(Type @interface)
                => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == QueryHandlerType;
        }
    }
}
