using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using AutoMapper;
using Bytes2you.Validation;
using MVC5_Template.Web.Infrastructure.Contracts;

namespace MVC5_Template.Web.Infrastructure.Configs
{
    public class AutoMapperConfig
    {
        private readonly Assembly _assembly;

        public AutoMapperConfig(Assembly assembly)
        {
            Guard.WhenArgument(assembly, "Assembly").IsNull().Throw();

            this._assembly = assembly;
        }

        public static IMapperConfigurationExpression Configuration { get; private set; }

        public void Execute()
        {
            Mapper.Initialize(cfg =>
            {
                var types = this._assembly.GetExportedTypes();
                LoadStandardMappings(types, cfg);
                LoadCustomMappings(types, cfg);
                Configuration = cfg;
            });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMap<>) &&
                      !t.IsAbstract &&
                      !t.IsInterface
                select new
                {
                    Source = i.GetGenericArguments()[0],
                    Destination = t
                }).ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
                mapperConfiguration.CreateMap(map.Destination, map.Source);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                    from i in t.GetInterfaces()
                    where typeof(ICustomMappings).IsAssignableFrom(t) &&
                          !t.IsAbstract &&
                          !t.IsInterface
                    select (ICustomMappings)Activator.CreateInstance(t))
                .ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }
        }
    }
}
