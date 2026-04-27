using Domain.Inventory.Repositories;

using Flunt.Notifications;
using Flunt.Validations;
using Shared.Abstractions;

namespace Domain.Inventory.Entities;

public class UnitOfMeasure : BaseEntity
{
    public UnitOfMeasure(string code, string name, bool allowDecimals = false)
    {
        Code = code;
        Name = name;
        AllowDecimals = allowDecimals;

        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(
                Code,
                "Sigla/Código",
                "A sigla da unidade de medida é obrigatória."
            )
            .IsNotUrlOrEmpty(
                Name,
                "Nome da unidade de medida",
                "Nome da unidade de medida é obrigatório."
            );
        AddNotifications(contract.Notifications);
    }

    protected UnitOfMeasure() { }

    public string Code { get; set; }
    
    public string Name { get; set; }
    
    public bool AllowDecimals { get; set; }

    public void ChangeAllowDecimals(bool allowDecimals)
    {
        AllowDecimals = allowDecimals;
        RegisterUpdate();
    }

    public async Task<bool> CodeExists(IUnitOfMeasureRepository uomRepository, string requestCode)
    {
        var result = await uomRepository.FindAsync(uom => uom.Code == requestCode);
        if (!result.Any()) return false;
        AddNotification("Sigla", "Sigla já existe.");
        return true;
    }
}
