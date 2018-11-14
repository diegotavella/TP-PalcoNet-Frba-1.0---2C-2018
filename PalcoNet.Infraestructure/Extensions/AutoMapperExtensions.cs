using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Infraestructure.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddProfilesFromAssemblyOf<T>(this IMapperConfiguration expression)
        {
            expression.AddProfilesFromAssemblyOf(typeof(T));
        }

        public static void AddProfilesFromAssemblyOf(this IMapperConfiguration expression, Type type)
        {
            var assembly = type.Assembly;

            assembly
                .GetTypes()
                .Where(t => t.Is<Profile>() && t.IsConcreteClass())
                .Each(t => expression.AddProfile(t.CreateAs<Profile>()));
        }

        //public static IMappingExpression<TSource, TDestination> IgnoreMember<TSource, TDestination, TMember>(this IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TDestination, TMember>> destinationMember)
        //{
        //    return mappingExpression.ForMember(destinationMember, o => o.Ignore());
        //}
    }
}
