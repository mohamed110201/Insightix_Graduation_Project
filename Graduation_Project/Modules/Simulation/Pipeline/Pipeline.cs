namespace Graduation_Project.Modules.Simulation;

public class Pipeline<T>
{
    private readonly List<IPipelineStep<T>> _steps = new();

    public Pipeline<T> AddStep(IPipelineStep<T> step)
    {
        _steps.Add(step);
        return this;
    }

    public async Task<T> ExecuteAsync(T input)
    {
        foreach (var step in _steps)
        {
            input = await step.Process(input);
        }
        return input;
    }
}
