using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace XVM.Runtime.XVM.Runtime.Execution.Internal
{
	internal static class TypedReferenceHelpers
	{
		private delegate void Cast(TypedRefPtr typedRef);

		private unsafe delegate void Make(void* ptr, TypedRefPtr typedRef);

		private delegate void Unbox(object box, TypedRefPtr typedRef);

		private delegate void Set(object value, TypedRefPtr typedRef);

		private delegate void FieldAdr(TypedRefPtr value, TypedRefPtr typedRef);

		private static Hashtable castHelpers = new Hashtable();

		private static Hashtable makeHelpers = new Hashtable();

		private static Hashtable unboxHelpers = new Hashtable();

		private static Hashtable setHelpers = new Hashtable();

		private static Hashtable fieldAddrHelpers = new Hashtable();

		private static FieldInfo typedPtrField = typeof(TypedRefPtr).GetFields()[0];

		public unsafe static void CastTypedRef(TypedRefPtr typedRef, Type targetType)
		{
			Type targetType2 = TypedReference.GetTargetType(*(TypedReference*)(void*)typedRef);
			KeyValuePair<Type, Type> keyValuePair = new KeyValuePair<Type, Type>(targetType2, targetType);
			object obj = castHelpers[keyValuePair];
			if (obj == null)
			{
				lock (castHelpers)
				{
					obj = castHelpers[keyValuePair];
					if (obj == null)
					{
						obj = BuildCastHelper(targetType2, targetType);
						castHelpers[keyValuePair] = obj;
					}
				}
			}
			((Cast)obj)(typedRef);
		}

		public unsafe static void MakeTypedRef(void* ptr, TypedRefPtr typedRef, Type targetType)
		{
			object obj = makeHelpers[targetType];
			if (obj == null)
			{
				lock (makeHelpers)
				{
					obj = makeHelpers[targetType];
					if (obj == null)
					{
						obj = BuildMakeHelper(targetType);
						makeHelpers[targetType] = obj;
					}
				}
			}
			((Make)obj)(ptr, typedRef);
		}

		public static void UnboxTypedRef(object box, TypedRefPtr typedRef)
		{
			UnboxTypedRef(box, typedRef, box.GetType());
			if (box is IValueTypeBox)
			{
				CastTypedRef(typedRef, ((IValueTypeBox)box).GetValueType());
			}
		}

		public static void UnboxTypedRef(object box, TypedRefPtr typedRef, Type boxType)
		{
			object obj = unboxHelpers[boxType];
			if (obj == null)
			{
				lock (unboxHelpers)
				{
					obj = unboxHelpers[boxType];
					if (obj == null)
					{
						obj = BuildUnboxHelper(boxType);
						unboxHelpers[boxType] = obj;
					}
				}
			}
			((Unbox)obj)(box, typedRef);
		}

		public unsafe static void SetTypedRef(object value, TypedRefPtr typedRef)
		{
			Type targetType = TypedReference.GetTargetType(*(TypedReference*)(void*)typedRef);
			object obj = setHelpers[targetType];
			if (obj == null)
			{
				lock (setHelpers)
				{
					obj = setHelpers[targetType];
					if (obj == null)
					{
						obj = BuildSetHelper(targetType);
						setHelpers[targetType] = obj;
					}
				}
			}
			((Set)obj)(value, typedRef);
		}

		public unsafe static void GetFieldAddr(VMContext context, object obj, FieldInfo field, TypedRefPtr typedRef)
		{
			object obj2 = fieldAddrHelpers[field];
			if (obj2 == null)
			{
				lock (fieldAddrHelpers)
				{
					obj2 = fieldAddrHelpers[field];
					if (obj2 == null)
					{
						obj2 = BuildAddrHelper(field);
						fieldAddrHelpers[field] = obj2;
					}
				}
			}
			TypedReference typedReference = default(TypedReference);
			if (obj == null)
			{
				typedReference = default(TypedReference);
			}
			else if (obj is IReference)
			{
				((IReference)obj).ToTypedReference(context, &typedReference, field.DeclaringType);
			}
			else
			{
				typedReference = __makeref(obj);
				CastTypedRef(&typedReference, obj.GetType());
			}
			((FieldAdr)obj2)(&typedReference, typedRef);
		}

		private static Cast BuildCastHelper(Type sourceType, Type targetType)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), new Type[1] { typeof(TypedRefPtr) }, typeof(TypedReferenceHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 0);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Dup);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, typeof(TypedReference));
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Refanyval, sourceType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, targetType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, typeof(TypedReference));
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (Cast)dynamicMethod.CreateDelegate(typeof(Cast));
		}

		private unsafe static Make BuildMakeHelper(Type targetType)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), new Type[2]
			{
				typeof(void*),
				typeof(TypedRefPtr)
			}, typeof(TypedReferenceHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 1);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, targetType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, typeof(TypedReference));
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (Make)dynamicMethod.CreateDelegate(typeof(Make));
		}

		private static Unbox BuildUnboxHelper(Type boxType)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), new Type[2]
			{
				typeof(object),
				typeof(TypedRefPtr)
			}, typeof(TypedReferenceHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 1);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Unbox, boxType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, boxType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, typeof(TypedReference));
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (Unbox)dynamicMethod.CreateDelegate(typeof(Unbox));
		}

		private static Set BuildSetHelper(Type refType)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), new Type[2]
			{
				typeof(object),
				typeof(TypedRefPtr)
			}, typeof(TypedReferenceHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 1);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, typeof(TypedReference));
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Refanyval, refType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarg_0);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Unbox_Any, refType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, refType);
			iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			return (Set)dynamicMethod.CreateDelegate(typeof(Set));
		}

		private static FieldAdr BuildAddrHelper(FieldInfo field)
		{
			DynamicMethod dynamicMethod = new DynamicMethod("", typeof(void), new Type[2]
			{
				typeof(TypedRefPtr),
				typeof(TypedRefPtr)
			}, typeof(TypedReferenceHelpers).Module, true);
			ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
			if (field.IsStatic)
			{
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 1);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldsflda, field);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, field.FieldType);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, typeof(TypedReference));
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			}
			else
			{
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 1);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldarga, 0);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldfld, typedPtrField);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, typeof(TypedReference));
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Refanyval, field.DeclaringType);
				if (!field.DeclaringType.IsValueType)
				{
					iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldobj, field.DeclaringType);
				}
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ldflda, field);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Mkrefany, field.FieldType);
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Stobj, typeof(TypedReference));
				iLGenerator.Emit(System.Reflection.Emit.OpCodes.Ret);
			}
			return (FieldAdr)dynamicMethod.CreateDelegate(typeof(FieldAdr));
		}
	}
}
