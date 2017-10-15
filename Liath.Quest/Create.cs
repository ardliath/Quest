using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Liath.Quest
{
    /// <summary>
    /// Creates things, all sorts of things
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Creates a mock
        /// </summary>
        /// <typeparam name="T">The type to create a mock of</typeparam>
        /// <returns>The mocked object</returns>
        public static T Mock<T>()
        {
            var stringAssemblyName = "DynamicAssemblyExample";
            AssemblyName assemblyName = new AssemblyName(stringAssemblyName);
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.RunAndSave);            
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name, assemblyName.Name + ".dll");

            var className = typeof(T).FullName + "Mock";
            TypeBuilder typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public);

            foreach (var methodToMock in typeof(T).GetMethods())
            {
                MethodBuilder myHelloMethod = typeBuilder.DefineMethod(methodToMock.Name,
                        MethodAttributes.Public | MethodAttributes.Virtual,
                        methodToMock.ReturnType,
                        methodToMock.GetParameters().Select(p => p.ParameterType).ToArray());

            https://msdn.microsoft.com/en-us/library/4775a47y(v=vs.110).aspx
                // Generate IL for 'GetGreeting' method.
                ILGenerator myMethodIL = myHelloMethod.GetILGenerator();
                myMethodIL.Emit(OpCodes.Ldstr, "Hello ");
                myMethodIL.Emit(OpCodes.Ldstr, "World!");
                MethodInfo emptyMethod = typeof(String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
                myMethodIL.Emit(OpCodes.Call, emptyMethod);
                if (methodToMock.ReturnType != typeof(void))
                {
                    myMethodIL.Emit(OpCodes.Ret);
                }
            }
            
            typeBuilder.AddInterfaceImplementation(typeof(T));
            //var theType = typeBuilder.CreateType();
            //var instance = Activator.CreateInstance(theType);
            //var returnValue = theType.GetMethod("HelloMethod").Invoke(instance, new string[] { "Adam" });
            //typeBuilder.SetParent(typeof(T));            

            return (T)Activator.CreateInstance(typeBuilder.CreateType());            
        }



        public void EmptyMethod()
        {

        }
    }
}
