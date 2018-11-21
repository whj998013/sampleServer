﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SG.Interface
{
    public interface ICovertToSon
    {

    }
    public static class IFToS
    {
        public static S ToSon<F, S>(this F ObjF) where F : ICovertToSon where S : F, new()
        {
            if (ObjF == null) return default(S);
            S son = new S();
            Type t = typeof(F);
            FieldInfo[] finfos = t.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            foreach (FieldInfo finfo in finfos)
            {
                finfo.SetValue(son, finfo.GetValue(ObjF));
            }
            return son;
        }
    }
}
