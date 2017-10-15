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

            foreach(var method in typeof(T).GetMethods())
            {
                //var methodBuilder = typeBuilder.DefineMethod(method.Name, 
                //    MethodAttributes.Public, 
                //    CallingConventions.Any, 
                //    method.ReturnType, 
                //    method.GetParameters().Select(p => p.ParameterType).ToArray());

                //// https://stackoverflow.com/questions/7671220/creating-method-dynamically-and-executing-it
                //var methodBody = typeof(Create).GetMethod("EmptyMethod").GetMethodBody();
                //var il = methodBody.GetILAsByteArray();

    //            typeof(Create)
    //.GetField("m_localSignature", BindingFlags.NonPublic | BindingFlags.Instance)
    //.SetValue(methodBody, typeof(Create).Module.ResolveSignature(methodBody.LocalSignatureMetadataToken));

    //            methodBuilder.SetMethodBody(il,
    //                methodBody.MaxStackSize,
    //                typeof(Create).Module.ResolveSignature(methodBody.LocalSignatureMetadataToken),
    //                null,
    //                null);


                ////https://stackoverflow.com/questions/4460859/methodbuilder-createmethodbody-problem-in-dynamic-type-creation
                //var ILcodes = methodBody.GetILAsByteArray();
                //var ilGen = methodBuilder.GetILGenerator();
                //methodBuilder.CreateMethodBody(ILcodes, ILcodes.Length);

                ////methodBuilder.CreateMethodBody(il, methodBody.MaxStackSize);
            }

            //typeBuilder.AddInterfaceImplementation(typeof(T));


            MethodBuilder myHelloMethod = typeBuilder.DefineMethod("HelloMethod",
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    typeof(String), 
                    new Type[] { typeof(String) });

        https://msdn.microsoft.com/en-us/library/4775a47y(v=vs.110).aspx
            // Generate IL for 'GetGreeting' method.
            ILGenerator myMethodIL = myHelloMethod.GetILGenerator();
            myMethodIL.Emit(OpCodes.Ldstr, "Hi!");
            myMethodIL.Emit(OpCodes.Ldarg_1);
            MethodInfo infoMethod = typeof(String).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
            myMethodIL.Emit(OpCodes.Call, infoMethod);
            myMethodIL.Emit(OpCodes.Ret);

            var theType = typeBuilder.CreateType();
            var instance = Activator.CreateInstance(theType);
            var returnValue = theType.GetMethod("HelloMethod").Invoke(instance, new string[] { "Adam"});

            return (T)Activator.CreateInstance(typeBuilder.CreateType());

            //typeBuilder.SetParent(typeof(T));            
        }



        public void EmptyMethod()
        {

        }
    }
}
