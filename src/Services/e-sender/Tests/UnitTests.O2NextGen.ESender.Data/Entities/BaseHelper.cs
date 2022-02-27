using System;
using System.Linq;

namespace UnitTests.O2NextGen.ESender.Data.Entities
{
    public static class BaseHelper<TClass>
    {
        public static bool It_CheckExistProperty(string nameProperty)
        {
            return typeof(TClass)
                .GetProperties()
                .SingleOrDefault(p => p.Name == nameProperty) != null;
        }

        public static bool It_CheckExistPropertyOfType(string nameProperty, Type type)
        {
            return type ==
                   typeof(TClass).GetProperties().SingleOrDefault(p => p.Name == nameProperty)?.PropertyType;
        }
    }
}