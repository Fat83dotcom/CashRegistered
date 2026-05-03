using Infrastructure.Utils.Interfaces;

namespace Infrastructure.Utils;

public class SqlUtils : ISqlUtils
{
    public string SqlLikeContains(string term)
    {
        return $"%{term}%";
    }
}