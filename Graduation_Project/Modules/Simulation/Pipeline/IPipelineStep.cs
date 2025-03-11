namespace Graduation_Project.Modules.Simulation;

public interface IPipelineStep<T>
{
    Task<T> Process(T input);
}