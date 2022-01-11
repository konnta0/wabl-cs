using UseCase.Core;

namespace UseCase.Departments.List;

internal partial class ListDepartmentsUseCaseHandler : InternalUseCaseHandler<IDepartmentsInputData, IDepartmentsOutputData>, IInternalUseCaseHandler<ListDepartmentsInputData, ListDepartmentsOutputData>
{
    public override IDepartmentsOutputData Invoke(IDepartmentsInputData request, Func<IDepartmentsInputData, IDepartmentsOutputData> next)
    {
        if (request is not ListDepartmentsInputData data)
        {
            return next(request);
        }

        return Handle(data);
    }

    public ListDepartmentsOutputData Handle(ListDepartmentsInputData inputData)
    {
        return new ListDepartmentsOutputData();
    }
}