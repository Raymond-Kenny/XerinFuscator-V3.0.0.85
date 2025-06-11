using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using XCore.Generator;

namespace XCore.Utils
{
	public static class Utils
	{
		[Serializable]
		[CompilerGenerated]
		private sealed class Et8
		{
			public static readonly Et8 Tta;

			public static Func<string, char> WtX;

			static Et8()
			{
				Tta = new Et8();
			}

			internal char ttZ(string string_0)
			{
				return string_0[rnd.Next(string_0.Length)];
			}
		}

		public static Random rnd;

		public static int Complexity;

		public static string b_d(this string string_0)
		{
			byte[] bytes = Convert.FromBase64String(string_0);
			return Encoding.UTF8.GetString(bytes);
		}

		public static string e_e(this string string_0)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(string_0);
			return Convert.ToBase64String(bytes);
		}

		public static bool isAssemblyDotNet(string string_0)
		{
			try
			{
				AssemblyName.GetAssemblyName(string_0);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static byte[] RandomByteArr(int int_0)
		{
			byte[] array = new byte[int_0];
			rnd.NextBytes(array);
			return array;
		}

		public static bool smethod_0(MethodDef methodDef_0)
		{
			if (methodDef_0.HasBody)
			{
				if (!methodDef_0.HasGenericParameters)
				{
					if (!methodDef_0.IsPinvokeImpl)
					{
						if (methodDef_0.IsUnmanagedExport)
						{
							return false;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static Code GetCode(bool bool_0 = false)
		{
			Code[] array = new Code[5]
			{
				Code.Add,
				Code.And,
				Code.Xor,
				Code.Sub,
				Code.Or
			};
			if (bool_0)
			{
				array = new Code[3]
				{
					Code.Add,
					Code.Sub,
					Code.Xor
				};
			}
			return array[rnd.Next(0, array.Length)];
		}

		public static FieldDefUser CreateField(FieldSig fieldSig_0)
		{
			return new FieldDefUser(MethodsRenamig(), fieldSig_0, dnlib.DotNet.FieldAttributes.Public | dnlib.DotNet.FieldAttributes.Static);
		}

		public static MethodDefUser CreateBoolMethod(ModuleDef moduleDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(MethodsRenamig(), MethodSig.CreateStatic(moduleDef_0.CorLibTypes.Boolean), dnlib.DotNet.MethodImplAttributes.IL, dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.Static)
			{
				Body = new CilBody()
			};
			methodDefUser.Body.Instructions.Add(OpCodes.Ldc_I4_1.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			moduleDef_0.GlobalType.Methods.Add(methodDefUser);
			methodDefUser.excludeMethod(moduleDef_0);
			return methodDefUser;
		}

		public static MethodDefUser CreateIntMethod(ModuleDef moduleDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(MethodsRenamig(), MethodSig.CreateStatic(moduleDef_0.CorLibTypes.Int32), dnlib.DotNet.MethodImplAttributes.IL, dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.Static)
			{
				Body = new CilBody()
			};
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			moduleDef_0.GlobalType.Methods.Add(methodDefUser);
			methodDefUser.excludeMethod(moduleDef_0);
			methodDefUser.DeclaringType = null;
			return methodDefUser;
		}

		public static MethodDefUser CreateMethod(ModuleDef moduleDef_0)
		{
			MethodDefUser methodDefUser = new MethodDefUser(MethodsRenamig(), MethodSig.CreateStatic(moduleDef_0.CorLibTypes.Void), dnlib.DotNet.MethodImplAttributes.IL, dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.Static)
			{
				Body = new CilBody()
			};
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			moduleDef_0.GlobalType.Methods.Add(methodDefUser);
			methodDefUser.excludeMethod(moduleDef_0);
			return methodDefUser;
		}

		public static MethodDefUser CreateMethod(ModuleDef moduleDef_0, int int_0, string string_0)
		{
			MethodDefUser methodDefUser = null;
			for (int i = 0; i < int_0; i++)
			{
				methodDefUser = new MethodDefUser(MethodsRenamig(), MethodSig.CreateStatic(moduleDef_0.CorLibTypes.Void), dnlib.DotNet.MethodImplAttributes.IL, dnlib.DotNet.MethodAttributes.Public | dnlib.DotNet.MethodAttributes.Static | dnlib.DotNet.MethodAttributes.HideBySig)
				{
					Body = new CilBody()
				};
				methodDefUser.Body.Instructions.Add(OpCodes.Ldstr.ToInstruction(string_0));
				methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
				moduleDef_0.GlobalType.Methods.Add(methodDefUser);
			}
			return methodDefUser;
		}

		public static int smethod_1()
		{
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			byte[] array = new byte[4];
			rNGCryptoServiceProvider.GetBytes(array);
			int num = BitConverter.ToInt32(array, 0);
			if (num < 0)
			{
				num *= -1;
			}
			return num;
		}

		public static int GetRandomInt32(int int_0, int int_1)
		{
			return GetRandomInt32() % (int_1 - int_0 + 1) + int_0;
		}

		public static int GetRandomInt32()
		{
			List<int[]> list = new List<int[]>();
			for (int i = 0; i < Complexity; i++)
			{
				int[] array = new int[Complexity];
				for (int j = 0; j < Complexity; j++)
				{
					array[j] = smethod_1();
				}
				list.Add(array);
			}
			return list[smethod_1() % Complexity][smethod_1() % Complexity];
		}

		public static int RandomTinyInt32()
		{
			return rnd.Next(2, 25);
		}

		public static int RandomSmallInt32()
		{
			return rnd.Next(15, 40);
		}

		public static int smethod_2()
		{
			return rnd.Next(100, 300);
		}

		public static int RandomInt322()
		{
			return rnd.Next(10000, 100000);
		}

		public static int RandomBigInt32()
		{
			return rnd.Next();
		}

		public static bool RandomBoolean()
		{
			return Convert.ToBoolean(rnd.Next(0, 2));
		}

		public static void MethodRenamig(MethodDef methodDef_0)
		{
			methodDef_0.Name = GGeneration.GenerateGuidStartingWithLetter();
		}

		public static void MethodRenamig(MethodDef[] methodDef_0)
		{
			foreach (MethodDef methodDef in methodDef_0)
			{
				methodDef.Name = GGeneration.GenerateGuidStartingWithLetter();
			}
		}

		public static void MethodsRenamig(IDnlibDef idnlibDef_0)
		{
			idnlibDef_0.Name = GGeneration.GenerateGuidStartingWithLetter();
		}

		public static string MethodsRenamig()
		{
			return GGeneration.GenerateGuidStartingWithLetter();
		}

		public static string RandomString(int int_0)
		{
			return new string((from string_0 in Enumerable.Repeat("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", int_0)
				select string_0[rnd.Next(string_0.Length)]).ToArray());
		}

		static Utils()
		{
			rnd = new Random();
			Complexity = 100;
		}
	}
}
