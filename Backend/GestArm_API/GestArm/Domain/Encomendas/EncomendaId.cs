using GestArm.Domain.Shared;
using Newtonsoft.Json;

namespace GestArm.Domain.Encomendas;

public class EncomendaId : EntityId
{
    [JsonConstructor]
    public EncomendaId(string value) : base(value)
    {
    }

    public EncomendaId(Guid value) : base(value)
    {
    }

    override
        protected object createFromString(string text)
    {
        return new Guid(text);
    }

    override
        public string AsString()
    {
        var obj = (Guid)ObjValue;
        return obj.ToString();
    }

    public Guid AsGuid()
    {
        return (Guid)ObjValue;
    }
}