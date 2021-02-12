using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RevxToJsonService.Extensions
{
    internal static class FieldCopyHelper
    {
        /// <summary>
        /// 指定オブジェクトから同じ名前のプロパティがあれば値をコピーする
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="self"></param>
        /// <param name="from"></param>
        public static void CopyFieldsFrom<T1, T2>(this T1 self, T2 from) where T1 : class where T2 : class
        {
            var fromFields = from.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
            var selfFields = self.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

            foreach (var selfField in selfFields)
            {
                var fromField = fromFields.FirstOrDefault(x => x.Name == selfField.Name);
                if (selfField != null && selfField.CanWrite) {
                    selfField.SetValue(self, fromField.GetValue(from, null), null);
                }
            }
        }
    }
}
