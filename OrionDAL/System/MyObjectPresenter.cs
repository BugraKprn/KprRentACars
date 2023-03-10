using System;
using System.Collections.Generic;
using System.Text;

namespace System
{
    public class MOP : MyObjectPresenter { /* kısayol olsun diye yapıldı */}

    public class MyObjectPresenter
    {
        public object Value { get; set; }

        /// <summary>
        /// Value objesinin hangi property sinin, ToString olarak döneceğiniz belirtir.
        /// </summary>
        public string DisplayMember { get; set; }

        /// <summary>
        /// Eğer set edilmişse, ToString metodu 'DisplayMember' yerine bu değeri kullanır.
        /// </summary>
        public string DisplayText { get; set; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(DisplayText))
            {
                return DisplayText;
            }

            if(string.IsNullOrEmpty(DisplayMember)
                || Value==null
                || Value==DBNull.Value) return "";

            object displayValue = Value.GetType().GetProperty(DisplayMember).GetValue(Value, null);

            return displayValue == null ? "" : displayValue.ToString();
        }

        public static Dictionary<string, MyObjectPresenter> PresenterCache = new Dictionary<string, MyObjectPresenter>();
        public static MyObjectPresenter GetPresenter(string presenterKey)
        {
            if (PresenterCache.ContainsKey(presenterKey))
                return PresenterCache[presenterKey];
            else
                return null;
        }

        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == DBNull.Value) obj = null;
            if (obj != null)
            {
                if (obj.GetType() == typeof(string))
                {
                    return this.DisplayText == (string)obj;
                }
                else
                {
                    MyObjectPresenter presenter = (MyObjectPresenter)obj;

                    if (Value == null)
                    {
                        return presenter.Value == null;
                    }
                    return Value.Equals(presenter.Value);
                }
            }
            else
            {
                return Value == null;
            }
        }

    }
}
