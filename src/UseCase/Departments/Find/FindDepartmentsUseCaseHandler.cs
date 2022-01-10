using MessagePipe;

namespace UseCase.Departments.Find;

public class FindDepartmentsUseCaseHandler : IRequestHandler<FindDepartmentsInputData, FindDepartmentsOutputData>
{
    public FindDepartmentsOutputData Invoke(FindDepartmentsInputData request)
    {
        return new FindDepartmentsOutputData();
    }
}