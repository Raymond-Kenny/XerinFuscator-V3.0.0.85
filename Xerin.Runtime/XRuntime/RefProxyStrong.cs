using System;
using System.Reflection;
using System.Reflection.Emit;

namespace XRuntime
{
	public static class RefProxyStrong
	{
		public static void Initialize(RuntimeFieldHandle field, byte opKey)
		{
			FieldInfo fieldFromHandle = FieldInfo.GetFieldFromHandle(field);
			byte[] array = fieldFromHandle.Module.ResolveSignature(fieldFromHandle.MetadataToken);
			int num = array.Length;
			int metadataToken = fieldFromHandle.GetOptionalCustomModifiers()[0].MetadataToken;
			metadataToken += (fieldFromHandle.Name[Mutation.KeyI0] ^ array[--num]) << Mutation.KeyI4;
			metadataToken += (fieldFromHandle.Name[Mutation.KeyI1] ^ array[--num]) << Mutation.KeyI5;
			metadataToken += (fieldFromHandle.Name[Mutation.KeyI2] ^ array[--num]) << Mutation.KeyI6;
			num--;
			metadataToken += (fieldFromHandle.Name[Mutation.KeyI3] ^ array[--num]) << Mutation.KeyI7;
			int num2 = Mutation.Placeholder(metadataToken);
			num2 *= fieldFromHandle.GetCustomAttributes(false)[0].GetHashCode();
			MethodBase methodBase = fieldFromHandle.Module.ResolveMethod(num2);
			Type fieldType = fieldFromHandle.FieldType;
			if (methodBase.IsStatic)
			{
				fieldFromHandle.SetValue(null, Delegate.CreateDelegate(fieldType, (MethodInfo)methodBase));
				return;
			}
			DynamicMethod dynamicMethod = null;
			Type[] array2 = null;
			MethodInfo[] methods = fieldFromHandle.FieldType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.DeclaringType == fieldType)
				{
					ParameterInfo[] parameters = methodInfo.GetParameters();
					array2 = new Type[parameters.Length];
					for (int j = 0; j < array2.Length; j++)
					{
						array2[j] = parameters[j].ParameterType;
					}
					Type declaringType = methodBase.DeclaringType;
					dynamicMethod = new DynamicMethod("", methodInfo.ReturnType, array2, declaringType.IsInterface || declaringType.IsArray ? fieldType : declaringType, true);
					break;
				}
			}
			DynamicILInfo dynamicILInfo = dynamicMethod.GetDynamicILInfo();
			dynamicILInfo.SetLocalSignature(new byte[2] { 7, 0 });
			byte[] array3 = new byte[7 * array2.Length + 6];
			int num3 = 0;
			ParameterInfo[] parameters2 = methodBase.GetParameters();
			int num4 = !methodBase.IsConstructor ? -1 : 0;
			for (int k = 0; k < array2.Length; k++)
			{
				array3[num3++] = 14;
				array3[num3++] = (byte)k;
				Type type = num4 == -1 ? methodBase.DeclaringType : parameters2[num4].ParameterType;
				if (type.IsClass && !type.IsPointer && !type.IsByRef)
				{
					int tokenFor = dynamicILInfo.GetTokenFor(type.TypeHandle);
					array3[num3++] = 116;
					array3[num3++] = (byte)tokenFor;
					array3[num3++] = (byte)(tokenFor >> 8);
					array3[num3++] = (byte)(tokenFor >> 16);
					array3[num3++] = (byte)(tokenFor >> 24);
				}
				else
				{
					num3 += 5;
				}
				num4++;
			}
			array3[num3++] = (byte)((byte)fieldFromHandle.Name[Mutation.KeyI8] ^ opKey);
			int tokenFor2 = dynamicILInfo.GetTokenFor(methodBase.MethodHandle);
			array3[num3++] = (byte)tokenFor2;
			array3[num3++] = (byte)(tokenFor2 >> 8);
			array3[num3++] = (byte)(tokenFor2 >> 16);
			array3[num3++] = (byte)(tokenFor2 >> 24);
			array3[num3] = 42;
			dynamicILInfo.SetCode(array3, array2.Length + 1);
			fieldFromHandle.SetValue(null, dynamicMethod.CreateDelegate(fieldType));
		}
	}
}
