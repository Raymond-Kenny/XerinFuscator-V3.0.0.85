using dnlib.DotNet;
using XCore.Utils;

namespace XF
{
	internal class tP
	{
		public static bool VU(TypeDef typeDef_0)
		{
			if (!(typeDef_0.FullName == "TrinityAttribute"))
			{
				if (!(typeDef_0.Namespace == "Costura"))
				{
					if (!typeDef_0.Name.StartsWith("<"))
					{
						if (typeDef_0.IsGlobalModuleType)
						{
							return false;
						}
						if (!typeDef_0.IsInterface)
						{
							if (typeDef_0.IsForwarder)
							{
								return false;
							}
							if (typeDef_0.IsSerializable)
							{
								return false;
							}
							if (typeDef_0.IsEnum)
							{
								return false;
							}
							if (typeDef_0.IsRuntimeSpecialName)
							{
								return false;
							}
							if (!typeDef_0.IsSpecialName)
							{
								if (typeDef_0.IsWindowsRuntime)
								{
									return false;
								}
								if (!typeDef_0.IsNestedFamilyOrAssembly)
								{
									if (!typeDef_0.IsNestedFamilyAndAssembly)
									{
										return true;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool Lk(EventDef eventDef_0)
		{
			if (eventDef_0.IsSpecialName)
			{
				return false;
			}
			if (eventDef_0.IsRuntimeSpecialName)
			{
				return false;
			}
			return true;
		}

		public static bool Ka(TypeDef typeDef_0, PropertyDef propertyDef_0)
		{
			if (propertyDef_0.DeclaringType.Implements("System.ComponentModel.INotifyPropertyChanged"))
			{
				return false;
			}
			if (!typeDef_0.Namespace.String.Contains(".Properties"))
			{
				if (!propertyDef_0.DeclaringType.Name.String.Contains("AnonymousType"))
				{
					if (propertyDef_0.IsRuntimeSpecialName)
					{
						return false;
					}
					if (propertyDef_0.IsEmpty)
					{
						return false;
					}
					if (!propertyDef_0.IsSpecialName)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool t0(object object_0, FieldDef fieldDef_0)
		{
			if (fieldDef_0.DeclaringType.IsSerializable && !fieldDef_0.IsNotSerialized)
			{
				return false;
			}
			if (fieldDef_0.DeclaringType.BaseType.Name.Contains("Delegate"))
			{
				return false;
			}
			if (fieldDef_0.Name.StartsWith("<"))
			{
				return false;
			}
			if (!fieldDef_0.IsLiteral || !fieldDef_0.DeclaringType.IsEnum)
			{
				if (!fieldDef_0.IsFamilyOrAssembly)
				{
					if (!fieldDef_0.IsSpecialName)
					{
						if (!fieldDef_0.IsRuntimeSpecialName)
						{
							if (fieldDef_0.IsFamily)
							{
								return false;
							}
							if (fieldDef_0.DeclaringType.IsEnum)
							{
								return false;
							}
							if (!fieldDef_0.DeclaringType.BaseType.Name.Contains("Delegate"))
							{
								return true;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool XQ(object object_0, object object_1)
		{
			if (((MethodDef)object_0).DeclaringType.IsComImport() && !((IHasCustomAttribute)object_0).HasAttribute("System.Runtime.InteropServices.DispIdAttribute"))
			{
				return false;
			}
			if (((MethodDef)object_0).HasBody && ((MethodDef)object_0).Body.HasInstructions)
			{
				if (((MethodDef)object_0).DeclaringType.BaseType != null && ((MethodDef)object_0).DeclaringType.BaseType.Name.Contains("Delegate"))
				{
					return false;
				}
				if (((MethodDef)object_0).DeclaringType.IsDelegate())
				{
					return false;
				}
				if (((MethodDef)object_0).DeclaringType.FullName == "System.Windows.Forms.Binding" && ((MethodDef)object_0).Name.String == ".ctor")
				{
					return false;
				}
				if (((MethodDef)object_0).DeclaringType.FullName == "System.Windows.Forms.ControlBindingsCollection")
				{
					return false;
				}
				if (((MethodDef)object_0).DeclaringType.FullName == "System.Windows.Forms.BindingsCollection")
				{
					return false;
				}
				if (((MethodDef)object_0).DeclaringType.FullName == "System.Windows.Forms.DataGridViewColumn")
				{
					return false;
				}
				if (((MethodDef)object_0).Name == "Invoke")
				{
					return false;
				}
				if (!((MethodDef)object_0).IsSetter && !((MethodDef)object_0).IsGetter)
				{
					if (((MethodDef)object_0).IsSpecialName)
					{
						return false;
					}
					if (!((MethodDef)object_0).IsFamilyAndAssembly)
					{
						if (!((MethodDef)object_0).IsFamily)
						{
							if (!((MethodDef)object_0).IsRuntime)
							{
								if (((MethodDef)object_0).IsRuntimeSpecialName)
								{
									return false;
								}
								if (((MethodDef)object_0).IsConstructor)
								{
									return false;
								}
								if (((MethodDef)object_0).IsNative)
								{
									return false;
								}
								if (!((MethodDef)object_0).IsPinvokeImpl && !((MethodDef)object_0).IsUnmanaged && !((MethodDef)object_0).IsUnmanagedExport)
								{
									if (object_0 != null)
									{
										if (((MethodDef)object_0).Name.StartsWith("<"))
										{
											return false;
										}
										if (((MethodDef)object_0).Overrides.Count <= 0)
										{
											if (((MethodDef)object_0).IsStaticConstructor)
											{
												return false;
											}
											if (((MethodDef)object_0).DeclaringType.IsGlobalModuleType)
											{
												return false;
											}
											if (!((MethodDef)object_0).DeclaringType.IsForwarder)
											{
												if (((MethodDef)object_0).IsVirtual)
												{
													return false;
												}
												if (((MethodDef)object_0).HasImplMap)
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
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool cr(TypeDef typeDef_0, Parameter parameter_0)
		{
			if (typeDef_0.FullName == "<Module>")
			{
				return false;
			}
			if (!parameter_0.IsHiddenThisParameter)
			{
				if (parameter_0.Name == string.Empty)
				{
					return false;
				}
				return true;
			}
			return false;
		}
	}
}
