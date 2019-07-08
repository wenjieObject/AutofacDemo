using Autofac;
using IService;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;

namespace AutofacDemo
{
    public class DefaultModuleRegister: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //注册当前程序集中以“User”结尾的类,暴漏类实现的所有接口，生命周期为PerLifetimeScope
            var baseType = typeof(IUser); //排除基类
            builder.RegisterAssemblyTypes(typeof(User).Assembly)
                 .Where(t => t.Name.EndsWith("User"))
                 .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                 .AsImplementedInterfaces();

            //注册所有"MyApp.Repository"程序集中的类
            //builder.RegisterAssemblyTypes(GetAssembly("Service")).AsImplementedInterfaces();
        }

        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }


    }
}
