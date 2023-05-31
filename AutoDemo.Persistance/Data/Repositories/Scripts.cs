namespace AutoDemo.Persistance.Data.Repositories;

internal static class Scripts
{
    internal const string GetTopVendorsScript = @"
select
    s.name,
    count(*) as offersCount
from Suppliers s
join Offers o on s.Id = o.SupplierId
group by s.name
order by count(*) desc
limit 3";
}
