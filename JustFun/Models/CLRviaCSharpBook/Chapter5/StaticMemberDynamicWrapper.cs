﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JustFun.Models.CLRviaCSharpBook.Chapter5
{
    internal sealed class StaticMemberDynamicWrapper : DynamicObject
    {
        private readonly TypeInfo m_type;

        public StaticMemberDynamicWrapper(Type type)
        {
            this.m_type = type.GetTypeInfo();
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return m_type.DeclaredMembers.Select(mi => mi.Name);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;

            var field = FindField(binder.Name);
            if (field != null)
            {
                result = field.GetValue(null);
                return true;
            }

            var prop = FindProperty(binder.Name, true);

            if (prop != null)
            {
                result = prop.GetValue(null, null);
                return true;
            }

            return false;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            var field = FindField(binder.Name);
            if (field != null)
            {
                field.SetValue(null, value);
                return true;
            }
            var prop = FindProperty(binder.Name, false);
            if (prop != null)
            {
                prop.SetValue(null, value, null);
                return true;
            }
            return false;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Type[] paramTypes = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                paramTypes[i] = args[i].GetType();
            }

            MethodInfo method = FindMethod(binder.Name, paramTypes);
            if (method == null)
            {
                result = null;
                return false;
            }
            result = method.Invoke(null, args);
            return true;
        }

        private MethodInfo FindMethod(String name, Type[] paramTypes)
        {
            return m_type.DeclaredMethods.FirstOrDefault(mi => mi.Name == name && mi.IsPublic && mi.IsStatic && ParametersMatch(mi.GetParameters(), paramTypes));
        }

        private Boolean ParametersMatch(ParameterInfo[] parameters, Type[] paramTypes)
        {
            if (parameters.Length != paramTypes.Length)
            {
                return false;
            }

            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i].ParameterType != paramTypes[i])
                {
                    return false;
                }
            }
            return true;
        }

        private FieldInfo FindField(string name)
        {
            return m_type.DeclaredFields.FirstOrDefault(fi => fi.IsPublic && fi.IsStatic && fi.Name == name);
        }

        private PropertyInfo FindProperty(String name, Boolean get)
        {
            if (get)
            {
                return m_type.DeclaredProperties.FirstOrDefault(pi => pi.Name == name && pi.GetMethod != null && pi.GetMethod.IsPublic && pi.GetMethod.IsStatic);
            }

            return m_type.DeclaredProperties.FirstOrDefault(pi => pi.Name == name && pi.SetMethod != null && pi.SetMethod.IsPublic && pi.SetMethod.IsStatic);
        }
    }
}
