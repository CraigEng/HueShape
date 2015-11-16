using System;
using StructureMap;

namespace HueShape.Core
{
    public static class IocContainer
    {
        private static readonly Container InstanceContainer;

        static IocContainer()
        {
            InstanceContainer = new Container();
        }

        public static void Configure<I, T>() where T : I
        {
            InstanceContainer.Configure((x => x.For<I>().Use<T>()));
        }

        public static void Configure<I, T>(Enum name) where T : I
        {
            InstanceContainer.Configure(x => x.For<I>().Use<T>().Named(name.ToString()));
        }

        public static T GetInstance<T>()
        {
            return InstanceContainer.GetInstance<T>();
        }

        public static T GetInstance<T>(Enum name)
        {
            return InstanceContainer.GetInstance<T>(name.ToString());
        }
    }
}