using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Text;
using MobileShop.Models;
using MobileShop.Models.Attributes;
using System.Text.RegularExpressions;

namespace MobileShop.ViewModels
{
    public class GoodsFeaturesMapper
    {
        public IEnumerable<string> GetSummaryList(Goods goods)
        {
            Type type = goods.GetType().BaseType;//родитель класса ef
            IEnumerable<PropertyInfo> properties = type.GetProperties(
                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            Regex propRegex = new Regex(@"\{(\w+)\}");
            List<string> summaryList = new List<string>();
            goods.SummaryFormatString.ToList().ForEach(str =>
            {
                bool allPropertiesNull = true;
                string summaryStr = propRegex.Replace(str, delegate (Match m)
                {
                    PropertyInfo prop = type.GetProperty(m.Groups[1].Value);
                    object value = prop.GetValue(goods);
                    FeatureAttribute attr = prop.GetCustomAttribute<FeatureAttribute>();
                    if (value?.ToString() == null || attr == null) return "";
                    allPropertiesNull = false;

                    string replaceStr;
                    if (value.GetType() == typeof(bool))
                        replaceStr = attr.Name;
                    else
                    {
                        replaceStr = value.ToString();
                        if (attr.UnitOfMeasurement != null)
                            replaceStr += " " + attr.UnitOfMeasurement;
                    }
                    return replaceStr;
                });
                if (!allPropertiesNull)
                {
                    summaryList.Add(summaryStr);
                }
            });
            return summaryList;
        }
        public string GetSummary(Goods goods)
        {
            IEnumerable<string> summaryList = GetSummaryList(goods);
            return string.Join(", ", summaryList);
        }
        public IEnumerable<FeaturesCategoryVM> GetFeatures(Goods goods)
        {
            List<FeaturesCategoryVM> featureCategories = new List<FeaturesCategoryVM>();
            Type type = goods.GetType().BaseType;//родитель класса ef
            IEnumerable<PropertyInfo> properties = type.GetProperties(
                BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);
            return properties
                .Select(p => new { Attribute = p.GetCustomAttribute<FeatureAttribute>(), Value = p.GetValue(goods) })
                .Where(p => p.Attribute != null && p.Value?.ToString() != null)
                .GroupBy(o => o.Attribute.Category,
                (category, props) => new FeaturesCategoryVM
                {
                    Name = category,
                    Features = props
                    .GroupBy(p => p.Attribute.Name,
                    (fname, fvalues) =>
                        fvalues.Aggregate(new FeatureVM { Name = fname }, (vm, prop) =>
                        {
                            if (prop.Value.GetType() == typeof(bool))
                                vm.Flag = (bool?)prop.Value;
                            else
                            {
                                vm.Value = prop.Value.ToString();
                                if (prop.Attribute.UnitOfMeasurement != null)
                                    vm.Value += " " + prop.Attribute.UnitOfMeasurement;
                            }
                            return vm;
                        }))
                });
        }
    }
}
