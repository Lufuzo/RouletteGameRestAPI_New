using _Entities.Models;
using _Repository.Extensions.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Repository.Extensions
{
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Bet> FilterBets(this IQueryable<Bet> bets, uint minValue, uint maxValue) =>
            bets.Where(e => (e.BetValue >= minValue && e.BetValue <= maxValue));

        public static IQueryable<Bet> Search(this IQueryable<Bet> bets, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return bets;

            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return bets.Where(e => e.BetOn.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Bet> Sort(this IQueryable<Bet> bets, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return bets.OrderBy(e => e.BetOn);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Bet>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return bets.OrderBy(e => e.BetOn);

            return bets.OrderBy(e => orderQuery);
        }
    }
}
