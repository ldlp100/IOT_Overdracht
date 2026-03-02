
using IoTEx.WaternetIoT.Model.DTOs.API;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using static IoTEx.WaternetIoT.Model.DTOs.API.APIRequestDTO;
using static IoTEx.WaternetIoT.Model.DTOs.API.APIRequestDTO.FilterDesc;

namespace IoTEx.Waternet.API
{
    /// <summary>
    /// This class is the generic class to manage any API Request managing Sorting and Filtering and translate request in LinQ request.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="DTO"></typeparam>
    public class APIRequester<T, DTO>
    {
        /// <summary>
        /// manage the data transformation 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IEnumerable<T> DT(APIRequestDTO request, IQueryable<T> db)
        {

            if (request != null)
            {

                if (request.Filters != null)
                    if (request.Filters.Count > 0)
                        db = db.Where(myQuery<T>(request)).AsQueryable<T>();

                if (request.Sorts != null)
                    if (request.Sorts.Count > 0)
                        db = db.OrderByColumns<T>(request);



                if (request.Page != null)
                    db = db.Skip((int)request.Page * (int)request.PageSize).Take((int)request.PageSize);


            }



            return db;
        }
        /// <summary>
        /// Data Transformation for a Kendo Grid answer
        /// </summary>
        /// <param name="request"></param>
        /// <param name="db"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static GridResult<DTO> DTGrid(APIRequestDTO request, IQueryable<T> db, Func<T, DTO> selector)
        {
            GridResult<DTO> result = new GridResult<DTO>();
            if (request != null)
            {


                if (request.Filters.Count > 0)
                    db = db.Where(myQuery<T>(request)).AsQueryable<T>();//.OrderByColumns<T>(request);
                if (request.Sorts.Count > 0)
                    db = db.OrderByColumns<T>(request);
                try
                {
                    result.Length = db.Count();
                }
                catch (Exception ex)
                {

                }
                if (request.Page != null)
                    db = db.Skip((int)request.Page * (int)request.PageSize).Take((int)request.PageSize);

                result.Data = db.Select(selector);

                return result;
            }

            result.Data = db.Select(selector);
            result.Length = db.Count();
            return result;
        }
        /// <summary>
        /// Extract Value  
        /// </summary>
        /// <param name="srcData"></param>
        /// <param name="exp"></param>
        /// <returns></returns>
        private static object GetValue(JsonElement srcData, Expression exp)
        {
            switch (srcData.ValueKind)
            {
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.Number:
                    if (exp.Type.Name == "Double")
                        return srcData.GetDouble();
                    else if (exp.Type.Name == "Single")
                        return srcData.GetSingle();
                    else if (exp.Type.Name == "Int32")
                        return srcData.GetInt32();
                    else if (exp.Type.Name == "Int16")
                        return srcData.GetInt16();
                    else if (exp.Type.Name == "Int64")
                        return srcData.GetInt64();
                    break;
                case JsonValueKind.False:
                    return false;
                case JsonValueKind.True:
                    return true;
                case JsonValueKind.Undefined:
                    return null;
                case JsonValueKind.String:
                    if (exp.Type.FullName.IndexOf("DateTime") > -1)
                        return srcData.GetDateTime();
                    else if (exp.Type.FullName.IndexOf("Guid") > -1)
                        return srcData.GetGuid();
                    else
                        return srcData.GetString();
            }
            return null;
        }
        /// <summary>
        /// generate Linq Query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Func<T, bool> myQuery<T>(APIRequestDTO request)
        {
            var type = typeof(T);
            var pe = Expression.Parameter(type, "p");

            Expression selectLeft = null;
            Expression selectRight = null;
            Expression filterExpression = null;
            Expression<Func<T, bool>> predicate = null;

            //MethodInfo METHOD = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            for (int i = 0; i < request.Filters.Count; i++)
            {
                Expression body = pe;
                string propertyName = request.Filters[i].Member.Substring(0, 1).ToUpper() + request.Filters[i].Member.Substring(1);
                foreach (var member in propertyName.Split('.'))
                {
                    body = Expression.PropertyOrField(body, member);
                }


                Expression left = body;
                //convert Null Date to date
                if (body.Type.FullName.IndexOf("DateTime") > -1)
                {
                    left = Expression.Convert(left, typeof(DateTime));
                }
                else if (body.Type.FullName.IndexOf("Guid") > -1)
                {
                    left = Expression.Convert(left, typeof(Guid));
                }

                Expression methodCallExpression = null;
                object value = GetValue(request.Filters[i].Value, body);

                //if (value.GetType().isnu)
                Expression right = Expression.Constant(value);
                Expression comparison = null;

                if (request.Filters[i].Operator == FilterOperator.Eq)
                {
                    try
                    {
                        comparison = Expression.Equal(left, right);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (request.Filters[i].Operator == FilterOperator.NotEq)
                {
                    comparison = Expression.NotEqual(left, right);
                }
                else if (request.Filters[i].Operator == FilterOperator.Contains)
                {
                    Expression comparisonNull = Expression.NotEqual(left, Expression.Constant(null));

                    MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    comparison = Expression.Call(left, method, right);
                    comparison = Expression.AndAlso(comparisonNull, comparison);
                    //continue;
                }
                else if (request.Filters[i].Operator == FilterOperator.EndWith)
                {
                    Expression comparisonNull = Expression.NotEqual(left, Expression.Constant(null));
                    MethodInfo method = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
                    comparison = Expression.Call(left, method, right);
                    comparison = Expression.AndAlso(comparisonNull, comparison);
                    //continue;
                }
                else if (request.Filters[i].Operator == FilterOperator.Greater)
                {
                    comparison = Expression.GreaterThan(left, right);
                }
                else if (request.Filters[i].Operator == FilterOperator.GreaterEqual)
                {

                    comparison = Expression.GreaterThanOrEqual(left, right);
                }
                else if (request.Filters[i].Operator == FilterOperator.Lower)
                {
                    comparison = Expression.LessThan(left, right);
                }
                else if (request.Filters[i].Operator == FilterOperator.LowerEqual)
                {
                    comparison = Expression.LessThanOrEqual(left, right);
                }
                else if (request.Filters[i].Operator == FilterOperator.StartWith)
                {
                    Expression comparisonNull = Expression.NotEqual(left, Expression.Constant(null));
                    MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                    comparison = Expression.Call(left, method, right);
                    comparison = Expression.AndAlso(comparisonNull, comparison);
                    //continue;
                }
                else if (request.Filters[i].Operator == FilterOperator.IsNull)
                {
                    comparison = Expression.Equal(left, null);
                }
                else if (request.Filters[i].Operator == FilterOperator.IsNotNull)
                {
                    comparison = Expression.NotEqual(left, null);
                }


                if (selectLeft == null)
                {
                    selectLeft = comparison;
                    filterExpression = selectLeft;
                    continue;
                }
                if (selectRight == null)
                {
                    selectRight = comparison;
                    filterExpression = Expression.AndAlso(selectLeft, selectRight);
                    continue;
                }

                filterExpression = Expression.AndAlso(filterExpression, comparison);

            }
            return Expression.Lambda<Func<T, bool>>(filterExpression, pe).Compile();
        }
        /// <summary>
        /// Convert Operator to String
        /// </summary>
        /// <param name="op"></param>
        /// <returns></returns>
        private static string ConvertOperatorToString(FilterOperator op)
        {
            switch (op)
            {
                case FilterOperator.Eq:
                    return "=";
                case FilterOperator.NotEq:
                    return "!=";
                default:
                    return "";
            }
        }
    }
    public static class QueryableExtensions
    {
        /// <summary>
        /// Manage the Linq Ordering
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IQueryable<T> OrderByColumns<T>(this IQueryable<T> query, APIRequestDTO request)
        {
            var type = typeof(T);
            var pe = Expression.Parameter(type, "p");


            bool firstTime = true;

            for (int i = 0; i < request.Sorts.Count; i++)
            {
                Expression body = pe;
                string propertyName = request.Sorts[i].Member;
                foreach (var member in propertyName.Split('.'))
                {
                    body = Expression.PropertyOrField(body, member);
                }
                //Expression prop = Expression.Property(pe, request.Sorts[i].Member);
                Expression exp = Expression.Lambda(body, pe);
                string method = String.Empty;

                if (firstTime)
                {
                    method = request.Sorts[i].Direction == SortDesc.SortDirection.ASC
                        ? "OrderBy"
                        : "OrderByDescending";

                    firstTime = false;
                }
                else
                {
                    method = request.Sorts[i].Direction == SortDesc.SortDirection.ASC
                        ? "ThenBy"
                        : "ThenByDescending";
                }
                Type[] types = new Type[] { query.ElementType, body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types,
                    query.Expression, exp);
                query = query.Provider.CreateQuery<T>(mce);
            }
            return query;
        }
    }
    /// <summary>
    /// generic class to manage kendo UI grid
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GridResult<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int Length { get; set; }
    }
}
