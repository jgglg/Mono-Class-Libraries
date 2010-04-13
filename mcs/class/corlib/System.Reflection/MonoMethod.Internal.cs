//
// System.Reflection/MonoMethod.cs
// The class used to represent methods from the mono runtime.
//
// Author:
//   Paolo Molaro (lupus@ximian.com)
//
// (C) 2001 Ximian, Inc.  http://www.ximian.com
// Copyright (C) 2004-2005 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Security;
using System.Threading;
using System.Text;

namespace System.Reflection
{
	 partial struct MonoMethodInfo
	{
#pragma warning restore 649		
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		static extern void get_method_info (IntPtr handle, out MonoMethodInfo info);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		static extern ParameterInfo[] get_parameter_info (IntPtr handle, MemberInfo member);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		static extern UnmanagedMarshal get_retval_marshal (IntPtr handle);

	}
	 partial class MonoMethod
	{
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		internal static extern string get_name (MethodBase method);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		internal static extern MonoMethod get_base_method (MonoMethod method, bool definition);
		
		/*
		* InternalInvoke() receives the parameters correctly converted by the 
		* binder to match the types of the method signature.
		*/
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		internal extern Object InternalInvoke (Object obj, Object[] parameters, out Exception exc);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		internal static extern DllImportAttribute GetDllImportAttribute (IntPtr mhandle);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern MethodInfo MakeGenericMethod_impl (Type [] types);
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		public override extern Type [] GetGenericArguments ();
		
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		extern MethodInfo GetGenericMethodDefinition_impl ();
		
		public override extern bool IsGenericMethodDefinition {
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		get;
		}
		
		public override extern bool IsGenericMethod {
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		get;
		}

	}
	 partial class MonoCMethod
	{
		
		/*
		* InternalInvoke() receives the parameters corretcly converted by the binder
		* to match the types of the method signature.
		*/
		[MethodImplAttribute(MethodImplOptions.InternalCall)]
		internal extern Object InternalInvoke (Object obj, Object[] parameters, out Exception exc);

	}
}
