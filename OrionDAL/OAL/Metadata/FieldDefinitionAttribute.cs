using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace OrionDAL.OAL.Metadata
{
    [global::System.AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = false)]
    public sealed class FieldDefinitionAttribute : Attribute
    {
        public FieldDefinitionAttribute()
        {
        }

        public FieldDefinitionAttribute(Type[] validations)
        {
            this.validations = validations;
        }

        public FieldDefinitionAttribute(PropertyInfo property)
        {
            this.instanceProperty = property;
        }

        private PropertyInfo instanceProperty;

        public PropertyInfo InstanceProperty
        {
            get { return instanceProperty; }
            set { instanceProperty = value; }
        }

        public string Name
        {
            get { return InstanceProperty.Name; }
        }

        private bool isPersistent = true;

        public bool IsPersistent
        {
            get { return isPersistent; }
            set { isPersistent = value; }
        }

        private bool isUnique = false;

        /// <summary>
        /// Bir veya daha fazla alana index koymak i�in kullan�l�r.
        /// Burda verilen isim index'in ad� olur.
        /// </summary>
        public string NonUniqueIndexGroup { get; set; }

        /// <summary>
        /// Bir veya daha fazla alana index koymak i�in kullan�l�r.
        /// Burda verilen isim index'in ad� olur.
        /// </summary>
        public string UniqueIndexGroup { get; set; }

        private bool isFiltered = true;

        public bool IsFiltered
        {
            get { return isFiltered; }
            set { isFiltered = value; }
        }

        private string typeName;

        public string TypeName
        {
            get
            {
                if (!string.IsNullOrEmpty(typeName)) return typeName;
                if (InstanceProperty != null)
                {
                    string mappedType = PersistenceStrategyProvider
                        .FindStrategyFor(InstanceProperty.DeclaringType)
                        .MapProperty(InstanceProperty);
                    return mappedType;
                    //--if (InstanceProperty.PropertyType.IsEnum) return typeof(string).Name;
                    //--return InstanceProperty.PropertyType.Name;
                }
                return null;
            }
            set { typeName = value; }
        }

        private int length = 100; //Default de�eri 100 olacak.

        public int Length
        {
            get { return length; }
            set { length = value; }
        }

        private int precision = 18; //Default de�er 18.

        public int Precision
        {
            get { return precision; }
            set { precision = value; }
        }

        private int scale = 4; //Default de�er 2.

        public int Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        private string text;

        public string Text
        {
            get { return text ?? shortText ?? (InstanceProperty != null ? InstanceProperty.Name : null); }
            set { text = value; }
        }

        private string shortText;

        public string ShortText
        {
            get { return shortText ?? text ?? (InstanceProperty != null ? InstanceProperty.Name : null); }
            set { shortText = value; }
        }

        private bool isRequired;

        public bool IsRequired
        {
            get { return isRequired; }
            set { isRequired = value; }
        }

        private Type[] validations;

       
        public Type[] Validations
        {
            get { return validations; }
            set { validations = value; }
        }

        public string GetInputClass()
        {
            return TypeName;
        }
    }
}