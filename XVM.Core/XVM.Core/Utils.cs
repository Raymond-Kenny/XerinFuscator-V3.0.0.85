using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using XVM.Core.AST.IR;
using XVM.Core.VM;

namespace XVM.Core
{
	public static class Utils
	{
		public static readonly char[] hexCharset;

		public static ModuleWriterOptions ExecuteModuleWriterOptions;

		public static void AssemblyReferencesAdder(this ModuleDef moduleDef_0)
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver
			{
				EnableTypeDefCache = true
			};
			ModuleContext context = (assemblyResolver.DefaultModuleContext = new ModuleContext(assemblyResolver));
			moduleDef_0.Context = context;
			foreach (AssemblyRef assemblyRef in moduleDef_0.GetAssemblyRefs())
			{
				try
				{
					if (assemblyRef != null)
					{
						AssemblyDef assemblyDef = assemblyResolver.Resolve(assemblyRef.FullName, moduleDef_0);
						if (assemblyDef != null)
						{
							((AssemblyResolver)moduleDef_0.Context.AssemblyResolver).AddToCache(assemblyDef);
						}
					}
				}
				catch
				{
				}
			}
		}

		public static void AddListEntry<TKey, TValue>(this IDictionary<TKey, List<TValue>> idictionary_0, TKey FIa, TValue yIU)
		{
			if (FIa == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!idictionary_0.TryGetValue(FIa, out var value))
			{
				List<TValue> list = (idictionary_0[FIa] = new List<TValue>());
				value = list;
			}
			value.Add(yIU);
		}

		public static IList<T> RemoveWhere<T>(this IList<T> ilist_0, Predicate<T> predicate_0)
		{
			for (int num = ilist_0.Count - 1; num >= 0; num--)
			{
				if (predicate_0(ilist_0[num]))
				{
					ilist_0.RemoveAt(num);
				}
			}
			return ilist_0;
		}

		public static void AddRange<T>(this IList<T> ilist_0, IList<T> ilist_1)
		{
			for (int i = 0; i < ilist_1.Count; i++)
			{
				ilist_0.Add(ilist_1[i]);
			}
		}

		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary_0, TKey wIh, TValue gIP = default(TValue))
		{
			if (dictionary_0.TryGetValue(wIh, out var value))
			{
				return value;
			}
			return gIP;
		}

		public static TValue GetValueOrDefaultLazy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary_0, TKey GIF, Func<TKey, TValue> func_0)
		{
			if (dictionary_0.TryGetValue(GIF, out var value))
			{
				return value;
			}
			return func_0(GIF);
		}

		public static StrongNameKey smethod_0(string string_0, string string_1)
		{
			if (string_0 == null)
			{
				return null;
			}
			try
			{
				if (string_1 != null)
				{
					X509Certificate2 x509Certificate = new X509Certificate2();
					x509Certificate.Import(string_0, string_1, X509KeyStorageFlags.Exportable);
					if (x509Certificate.PrivateKey is RSACryptoServiceProvider rSACryptoServiceProvider)
					{
						return new StrongNameKey(rSACryptoServiceProvider.ExportCspBlob(includePrivateParameters: true));
					}
					throw new ArgumentException("RSA key does not present in the certificate.", "path");
				}
				return new StrongNameKey(string_0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static string ToHexString(this string string_0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] array = bytes;
			foreach (byte b in array)
			{
				stringBuilder.Append(b.ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		public static string ToHexString(this byte[] byte_0)
		{
			char[] array = new char[byte_0.Length * 2];
			int num = 0;
			foreach (byte b in byte_0)
			{
				array[num++] = hexCharset[b >> 4];
				array[num++] = hexCharset[b & 0xF];
			}
			return new string(array);
		}

		public static void Increment<T>(this Dictionary<T, int> dictionary_0, T bIv)
		{
			if (!dictionary_0.TryGetValue(bIv, out var value))
			{
				value = 0;
			}
			value = (dictionary_0[bIv] = value + 1);
		}

		public static void Replace<T>(this List<T> list_0, int int_0, IEnumerable<T> ienumerable_0)
		{
			list_0.RemoveAt(int_0);
			list_0.InsertRange(int_0, ienumerable_0);
		}

		public static void Replace(this List<IRInstruction> list_0, int int_0, IEnumerable<IRInstruction> ienumerable_0)
		{
			IRInstruction iRInstruction = list_0[int_0];
			list_0.RemoveAt(int_0);
			foreach (IRInstruction item in ienumerable_0)
			{
				item.ILAST = iRInstruction.ILAST;
			}
			list_0.InsertRange(int_0, ienumerable_0);
		}

		public static bool IsGPR(this VMRegisters vmregisters_0)
		{
			if (vmregisters_0 >= VMRegisters.R0 && vmregisters_0 <= VMRegisters.R7)
			{
				return true;
			}
			return false;
		}

		public static TypeSig ResolveType(this GenericArguments genericArguments_0, TypeSig typeSig_0)
		{
			switch (typeSig_0.ElementType)
			{
			case ElementType.Pinned:
				return new PinnedSig(genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.Module:
				return new ModuleSig(((ModuleSig)typeSig_0).Index, genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.Ptr:
				return new PtrSig(genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.ByRef:
				return new ByRefSig(genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.Array:
			{
				ArraySig arraySig = (ArraySig)typeSig_0;
				return new ArraySig(genericArguments_0.ResolveType(typeSig_0.Next), arraySig.Rank, arraySig.Sizes, arraySig.LowerBounds);
			}
			case ElementType.GenericInst:
			{
				GenericInstSig genericInstSig = (GenericInstSig)typeSig_0;
				List<TypeSig> list = new List<TypeSig>();
				foreach (TypeSig genericArgument in genericInstSig.GenericArguments)
				{
					list.Add(genericArguments_0.ResolveType(genericArgument));
				}
				return new GenericInstSig(genericInstSig.GenericType, list);
			}
			case ElementType.ValueArray:
				return new ValueArraySig(genericArguments_0.ResolveType(typeSig_0.Next), ((ValueArraySig)typeSig_0).Size);
			default:
				if (typeSig_0.IsTypeDefOrRef)
				{
					TypeDefOrRefSig typeDefOrRefSig = (TypeDefOrRefSig)typeSig_0;
					if (typeDefOrRefSig.TypeDefOrRef is TypeSpec)
					{
						throw new NotSupportedException();
					}
				}
				return typeSig_0;
			case ElementType.SZArray:
				return new SZArraySig(genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.Var:
			case ElementType.MVar:
				return genericArguments_0.Resolve(typeSig_0);
			case ElementType.CModReqd:
				return new CModReqdSig(((CModReqdSig)typeSig_0).Modifier, genericArguments_0.ResolveType(typeSig_0.Next));
			case ElementType.CModOpt:
				return new CModOptSig(((CModOptSig)typeSig_0).Modifier, genericArguments_0.ResolveType(typeSig_0.Next));
			}
		}

		public static int EncryptInt(this int int_0, double double_0)
		{
			byte[] bytes = BitConverter.GetBytes(double_0);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int[] array = new int[8];
			for (int i = 0; i < 8; i++)
			{
				array[i] = (bytes[i] % (i + 1)) ^ int_0 ^ (i + 1) ^ int_0;
			}
			for (int j = 0; j < 8; j++)
			{
				int num5 = (int)Math.Log10(array[j]);
				num ^= array[j] ^ ((array[j] ^ num5) * j >> (int)((float)j * 0.25f));
				num2 += array[j] >> ((array[j] ^ num5) * j << (int)((float)(short)j + 0.58f));
				num3 -= array[j] << ((array[j] ^ num5) * j >> (int)((float)j * 0.41f));
				num4 ^= array[j] + ((array[j] ^ num5) * j << (int)((float)j - 0.99f));
			}
			return num ^ int_0 ^ (num2 ^ int_0) ^ (num3 ^ int_0) ^ num4;
		}

		static Utils()
		{
			hexCharset = "0123456789ABCDEF".ToCharArray();
		}
	}
}
