using MessagePipe;

namespace UseCase.Departments.Find;

public interface IFindDepartmentsUseCase : IRequestHandler<IDepartmentsInputData, IDepartmentsOutputData>
{
    TOutput Handle<TInput, TOutput>(TInput input) where TInput : IDepartmentsInputData
        where TOutput : IDepartmentsOutputData;
}