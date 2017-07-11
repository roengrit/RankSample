using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RankSample
{
    class Program
    {
        static void Main(string[] args)
        {
                          
            Dictionary<string, decimal> DictVal = new Dictionary<string, decimal>();

            DictVal.Add("0001", 100.5m);
            DictVal.Add("0002", 95.5m);
            DictVal.Add("0003", 100.5m);
            DictVal.Add("0004", 70.5m);
            DictVal.Add("0005", 90m);

            var Result = DictVal.GroupBy(x => x.Value).
                            OrderByDescending(x => x.Key).
                            Select((p, i) => new { Order = 1 + i, Participant = p }).
                            SelectMany(g => g.Participant.Select(p => new
                            {
                                Amount = p.Value,
                                Rank = g.Order,
                                Code = p.Key

                            }))
                            //.OrderBy(x=>x.Code) // เรียงตามเดิม เอา Comment ออก
                            ;

        }
    }
}
