using Serenity.Services;
using MyRequest = Serenity.Services.SaveRequest<Serene2.hospital.PatientsRow>;
using MyResponse = Serenity.Services.SaveResponse;
using MyRow = Serene2.hospital.PatientsRow;

namespace Serene2.hospital;

public interface IPatientsSaveHandler : ISaveHandler<MyRow, MyRequest, MyResponse> { }

public class PatientsSaveHandler : SaveRequestHandler<MyRow, MyRequest, MyResponse>, IPatientsSaveHandler
{
    public PatientsSaveHandler(IRequestContext context)
        : base(context)
    {
    }

    protected override void BeforeSave()
    {
        base.BeforeSave();

        if (Row.Age.HasValue)
        {
            Row.Age = Row.Age.Value + 2;
        }
    }
}