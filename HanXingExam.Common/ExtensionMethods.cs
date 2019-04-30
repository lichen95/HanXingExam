using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;

namespace HanXingExam.Common
{
    /// <summary>
    /// Copyright (C) 2015-2018 LiChen
    /// 将List转换成DataTable类
    /// QQ 594281739
    /// Email 594281739@qq.com
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }

        /// <summary>
        /// DataTable转泛型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            //获取类
            Type t = typeof(T);
            //反射 using System.Reflection;
            //获取当前Type的公共属性
            PropertyInfo[] propertys = t.GetProperties();
            List<T> list = new List<T>();
            //字段名称
            string typeName = string.Empty;
            //遍历DataTable每行
            foreach (DataRow dr in dt.Rows)
            {
                //创建实体
                T entity = new T();
                //遍历实体的公共属性
                foreach (PropertyInfo pi in propertys)
                {
                    //将字段名称赋值
                    typeName = pi.Name;
                    if (dt.Columns.Contains(typeName))
                    {
                        //获取一个值,该值指定此属性是否可写 set 
                        if (!pi.CanWrite) continue;
                        //根据字段名称获取对应值
                        object value = dr[typeName];
                        //若不存在 则跳出
                        if (value == DBNull.Value) continue;
                        //获取此属性的类型是否是string类型
                        if (pi.PropertyType == typeof(string))
                        {
                            //PropertyInfo.SetValue()三个参数
                            //第一个 将设置其属性值的对象。
                            //第二个 新的属性值。
                            //第三个 索引化属性的可选索引值。 对于非索引化属性，该值应为 null。
                            pi.SetValue(entity, value.ToString(), null);
                        }
                        else if (pi.PropertyType == typeof(int))
                        {
                            //写入
                            pi.SetValue(entity, int.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(DateTime))
                        {
                            //写入
                            pi.SetValue(entity, DateTime.Parse(value.ToString()), null);
                        }
                        else
                        {
                            pi.SetValue(entity, value, null);
                        }
                    }
                }
                //加入泛型末尾
                list.Add(entity);
            }
            return list;
        }
    }
}